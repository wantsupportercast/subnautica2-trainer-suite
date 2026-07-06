using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Subnautica2Trainer
{
    public static class MemoryHelper
    {
        [DllImport("kernel32.dll")]
        private static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int nSize, out int lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        private static extern bool CloseHandle(IntPtr hObject);

        private const uint PROCESS_VM_WRITE = 0x0020;
        private const uint PROCESS_VM_OPERATION = 0x0008;

        public static bool WriteMemory(int pid, IntPtr address, byte[] data)
        {
            IntPtr hProcess = OpenProcess(PROCESS_VM_WRITE | PROCESS_VM_OPERATION, false, pid);
            if (hProcess == IntPtr.Zero)
                return false;

            bool success = WriteProcessMemory(hProcess, address, data, data.Length, out _);
            CloseHandle(hProcess);
            return success;
        }

        public static int FindProcessId(string processName)
        {
            Process[] procs = Process.GetProcessesByName(processName);
            return procs.Length > 0 ? procs[0].Id : -1;
        }
    }
}