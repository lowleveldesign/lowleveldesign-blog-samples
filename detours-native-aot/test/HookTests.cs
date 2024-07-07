using System.Runtime.InteropServices;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.Security;
using Windows.Win32.System.Memory;
using Windows.Win32.System.SystemServices;
using Windows.Win32.System.ProcessStatus;
using Windows.Win32.System.Threading;
using System.Reflection.PortableExecutable;
using System.ComponentModel;
using System.Text;

namespace test;

public static class HookTests
{
    const uint processId = 0;

    const PROCESS_ACCESS_RIGHTS AccessRightsForCreatingRemoteThread = PROCESS_ACCESS_RIGHTS.PROCESS_CREATE_THREAD |
            PROCESS_ACCESS_RIGHTS.PROCESS_QUERY_INFORMATION | PROCESS_ACCESS_RIGHTS.PROCESS_VM_OPERATION |
            PROCESS_ACCESS_RIGHTS.PROCESS_VM_WRITE | PROCESS_ACCESS_RIGHTS.PROCESS_VM_READ;

    [Test]
    public static void SetHook()
    {
        // find a process to hook
        var processHandle = PInvoke.OpenProcess(AccessRightsForCreatingRemoteThread, false, processId);

        bool isWow64 = IsWow64(processHandle);

        string systemDirectory = isWow64 ? Environment.GetFolderPath(Environment.SpecialFolder.SystemX86) : Environment.SystemDirectory;

        // load a hook dll
        var hookDllName = isWow64 ? "hook_x86.dll" : "hook_x64.dll";
        var hookDllPath = Path.Combine(AppContext.BaseDirectory, hookDllName);
        var allocAddr = AllocAndWriteData(processHandle, Encoding.Unicode.GetBytes(hookDllPath + "\0").AsSpan());
        try
        {
            Assert.That(GetModuleInfo(processHandle, isWow64, "kernel32.dll") is var (kernel32Handle, _) && kernel32Handle != 0);

            var kernel32Path = Path.Combine(systemDirectory, "kernel32.dll");
            var fnLoadLibraryW = kernel32Handle + (nint)GetModuleExportOffset(kernel32Path, "LoadLibraryW");
            CallFunctionInRemoteProcess(processHandle, fnLoadLibraryW, allocAddr);
        }
        finally
        {
            FreeMemory(processHandle, allocAddr);
        }

        // set hooks
        Assert.That(GetModuleInfo(processHandle, isWow64, hookDllName) is var (hookDllHandle, _) && hookDllHandle != 0);
        var fnInitHooks = hookDllHandle + (nint)GetModuleExportOffset(hookDllPath, "InitHooks");
        CallFunctionInRemoteProcess(processHandle, fnInitHooks);
    }

    [Test]
    public static void UnsetHook()
    {
        var processHandle = PInvoke.OpenProcess(AccessRightsForCreatingRemoteThread, false, processId);

        bool isWow64 = IsWow64(processHandle);
        
        var hookDllName = isWow64 ? "hook_x86.dll" : "hook_x64.dll";
        var hookDllPath = Path.Combine(AppContext.BaseDirectory, hookDllName);

        // unset hooks
        Assert.That(GetModuleInfo(processHandle, isWow64, hookDllName) is var (hookDllHandle, _) && hookDllHandle != 0);
        var fnInitHooks = hookDllHandle + (nint)GetModuleExportOffset(hookDllPath, "RemoveHooks");
        CallFunctionInRemoteProcess(processHandle, fnInitHooks);
    }


    static bool IsWow64(HANDLE processHandle)
    {
        BOOL isWow64 = !Environment.Is64BitProcess;
        unsafe
        {
            if (Environment.Is64BitProcess && !PInvoke.IsWow64Process(processHandle, &isWow64))
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }
        return isWow64;
    }

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern unsafe nint CreateRemoteThread(
        nint hProcess,
        SECURITY_ATTRIBUTES* lpThreadAttributes,
        nuint dwStackSize,
        nint lpStartAddress,
        nint lpParameter,
        uint dwCreationFlags,
        uint* lpThreadId
    );

    static void CallFunctionInRemoteProcess(HANDLE processHandle, nint fnAddress, nint arg0 = 0)
    {
        unsafe
        {
            if ((HANDLE)CreateRemoteThread(processHandle, null, 0, fnAddress, arg0, 0, null) is var remoteThreadHandle &&
                remoteThreadHandle == (HANDLE)0)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            try
            {
                if (PInvoke.WaitForSingleObject(remoteThreadHandle, 5000) is var err && err == WAIT_EVENT.WAIT_TIMEOUT)
                {
                    throw new Win32Exception((int)WIN32_ERROR.ERROR_TIMEOUT);
                }
                else if (err == WAIT_EVENT.WAIT_FAILED)
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }
            }
            finally
            {
                PInvoke.CloseHandle(remoteThreadHandle);
            }
        }
    }

    static nint AllocAndWriteData(HANDLE remoteProcessHandle, Span<byte> data)
    {
        unsafe
        {
            var allocAddr = PInvoke.VirtualAllocEx(remoteProcessHandle, null, (nuint)data.Length,
                VIRTUAL_ALLOCATION_TYPE.MEM_RESERVE | VIRTUAL_ALLOCATION_TYPE.MEM_COMMIT, PAGE_PROTECTION_FLAGS.PAGE_READWRITE);
            if (allocAddr != null)
            {
                // VirtualAllocEx initializes memory to 0
                fixed (void* dataPtr = data)
                {
                    if (!PInvoke.WriteProcessMemory(remoteProcessHandle, allocAddr, dataPtr, (nuint)data.Length, null))
                    {
                        throw new Win32Exception(Marshal.GetLastWin32Error());
                    }
                }
                return (nint)allocAddr;
            }
            else
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }
    }

    static void FreeMemory(HANDLE remoteProcessHandle, nint allocAddr)
    {
        unsafe
        {
            PInvoke.VirtualFreeEx(remoteProcessHandle, (void*)allocAddr, 0, VIRTUAL_FREE_TYPE.MEM_RELEASE);
        }
    }

    static unsafe (HMODULE, string moduleFullPath) GetModuleInfo(HANDLE processHandle, bool isWow64, string moduleName)
    {
        const uint MaxModulesNumber = 256;

        var moduleHandles = stackalloc HMODULE[(int)MaxModulesNumber];
        uint cb = MaxModulesNumber * (uint)Marshal.SizeOf<HMODULE>();
        uint cbNeeded = 0;

        PInvoke.EnumProcessModulesEx(processHandle, moduleHandles, cb, &cbNeeded,
            isWow64 ? ENUM_PROCESS_MODULES_EX_FLAGS.LIST_MODULES_32BIT : ENUM_PROCESS_MODULES_EX_FLAGS.LIST_MODULES_64BIT);

        if (cb >= cbNeeded)
        {
            moduleName = Path.DirectorySeparatorChar + moduleName.ToUpper();
            var nameBuffer = stackalloc char[(int)PInvoke.MAX_PATH];
            foreach (var iterModuleHandle in new Span<HMODULE>(moduleHandles, (int)(cbNeeded / Marshal.SizeOf<HMODULE>())))
            {
                if (PInvoke.GetModuleFileNameEx(processHandle, iterModuleHandle, nameBuffer,
                        PInvoke.MAX_PATH) is var iterModuleNameLength && iterModuleNameLength > moduleName.Length)
                {
                    var iterModuleNameSpan = new Span<char>(nameBuffer, (int)iterModuleNameLength);
                    if (IsTheRightModule(iterModuleNameSpan))
                    {
                        return (iterModuleHandle, new string(iterModuleNameSpan));
                    }
                }
            }
        }

        return ((HMODULE)nint.Zero, "");

        bool IsTheRightModule(ReadOnlySpan<char> m)
        {
            var moduleNameSpan = moduleName.AsSpan();
            for (int i = 0; i < moduleNameSpan.Length; i++)
            {
                if (char.ToUpper(m[i + m.Length - moduleNameSpan.Length]) != moduleNameSpan[i])
                {
                    return false;
                }
            }
            return true;
        }
    }

    static unsafe uint GetModuleExportOffset(string modulePath, string procedureName)
    {
        using var pereader = new PEReader(File.OpenRead(modulePath));

        var exportsDirEntry = pereader.PEHeaders.PEHeader!.ExportTableDirectory;
        var exportsDir = (IMAGE_EXPORT_DIRECTORY*)pereader.GetSectionData(exportsDirEntry.RelativeVirtualAddress).Pointer;

        var functionNamesRvas = new Span<uint>(pereader.GetSectionData((int)exportsDir->AddressOfNames).Pointer,
                                                (int)exportsDir->NumberOfNames);
        var functionNamesOrdinals = new Span<ushort>(pereader.GetSectionData((int)exportsDir->AddressOfNameOrdinals).Pointer,
                                                        (int)exportsDir->NumberOfNames);
        var addressOfFunctions = pereader.GetSectionData((int)exportsDir->AddressOfFunctions).Pointer;

        for (int i = 0; i < functionNamesRvas.Length; i++)
        {
            var name = Marshal.PtrToStringAnsi((nint)pereader.GetSectionData((int)functionNamesRvas[i]).Pointer);
            var index = functionNamesOrdinals[i];

            if (name == procedureName)
            {
                return *(uint*)(addressOfFunctions + index * sizeof(uint));
            }
        }

        return 0;
    }
}