using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Foundation;

using PInvokeWin32 = Windows.Win32.PInvoke;
using PInvokeDetours = Microsoft.Detours.PInvoke;
using hook;
using System.Diagnostics;

namespace testdll;

public static class Exports
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)], EntryPoint = "InitHooks")]
    internal static void InitHooks()
    {
        unsafe
        {
            var kernel32Handle = GetModuleHandle("kernel32.dll");
            if (kernel32Handle == 0 || !NativeLibrary.TryGetExport(kernel32Handle, "WriteFile", out var funcAddress))
            {
                Trace.WriteLine($"Error resolving test function address (hmodule: 0x{kernel32Handle:x})");
                return;
            }

            var origFuncPtr = (void*)funcAddress;
            delegate* unmanaged[Stdcall]<HANDLE, byte*, uint, uint*, NativeOverlapped*, BOOL> hookedFunc = &Hooks.HookedWriteFile;

            PInvokeDetours.DetourRestoreAfterWith();

            ThrowIfError(PInvokeDetours.DetourTransactionBegin());
            ThrowIfError(PInvokeDetours.DetourUpdateThread(PInvokeWin32.GetCurrentThread()));
            ThrowIfError(PInvokeDetours.DetourAttach(&origFuncPtr, hookedFunc));
            ThrowIfError(PInvokeDetours.DetourTransactionCommit());

            Hooks.OrigWriteFile = (delegate* unmanaged[Stdcall]<HANDLE, byte*, uint, uint*, NativeOverlapped*, BOOL>)origFuncPtr;
        }

        static unsafe nint GetModuleHandle(string moduleName)
        {
            var moduleNamePtr = Marshal.StringToHGlobalUni(moduleName);
            try
            {
                return PInvokeWin32.GetModuleHandle(new PCWSTR((char*)moduleNamePtr));
            }
            finally
            {
                Marshal.FreeHGlobal(moduleNamePtr);
            }
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)], EntryPoint = "RemoveHooks")]
    internal static void RemoveHooks()
    {
        unsafe
        {
            var origFuncPtr = (void*)Hooks.OrigWriteFile;
            Hooks.OrigWriteFile = null;

            delegate* unmanaged[Stdcall]<HANDLE, byte*, uint, uint*, NativeOverlapped*, BOOL> hookedFunc = &Hooks.HookedWriteFile;

            ThrowIfError(PInvokeDetours.DetourTransactionBegin());
            ThrowIfError(PInvokeDetours.DetourUpdateThread(PInvokeWin32.GetCurrentThread()));
            ThrowIfError(PInvokeDetours.DetourDetach(&origFuncPtr, hookedFunc));
            ThrowIfError(PInvokeDetours.DetourTransactionCommit());
        }
    }

    static void ThrowIfError(int err)
    {
        if (err != (int)WIN32_ERROR.NO_ERROR)
        {
            throw new System.ComponentModel.Win32Exception(err);
        }
    }

}
