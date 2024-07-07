using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Foundation;

namespace hook;

static class Hooks
{
    public static unsafe delegate* unmanaged[Stdcall]<HANDLE, byte*, uint, uint*, NativeOverlapped*, BOOL> OrigWriteFile = null;

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    public static unsafe BOOL HookedWriteFile(HANDLE hFile, byte* lpBuffer, uint nNumberOfBytesToWrite,
        uint* lpNumberOfBytesWritten, NativeOverlapped* lpOverlapped)
    {
        Trace.WriteLine("HookedWriteFile");
        return OrigWriteFile(hFile, lpBuffer, nNumberOfBytesToWrite, lpNumberOfBytesWritten, lpOverlapped);
    }
}
