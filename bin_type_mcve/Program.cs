using System;
using System.Runtime.InteropServices;

namespace bin_type_mcve
{
    class Program
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetBinaryTypeW([MarshalAs(UnmanagedType.LPWStr)] string path, out UInt32 result);

        [DllImport("kernel32.dll")]
        private static extern uint GetLastError();

        static void Main(string[] args)
        {
            if (!GetBinaryTypeW("target.exe", out UInt32 result))
                Console.WriteLine($"GetBinaryTypeW failed.  Errno = {GetLastError()}");
            else
                Console.WriteLine($"GetBinaryTypeW succeeded.  Type = {result}");
        }
    }
}
