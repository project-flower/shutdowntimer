using System;
using System.Runtime.InteropServices;

namespace Win32API
{
    static class Kernel32
    {
        /// <summary>
        /// kernel32.dllのファイル名
        /// </summary>
        const string fileName = "kernel32.dll";

        /// <summary>
        /// Closes an open object handle.
        /// </summary>
        /// <param name="hObject">A valid handle to an open object.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// <para>If the function fails, the return value is zero.To get extended error information, call GetLastError.</para>
        /// <para>If the application is running under a debugger, the function will throw an exception if it receives either a handle value that is not valid or a pseudo-handle value. This can happen if you close a handle twice, or if you call CloseHandle on a handle returned by the FindFirstFile function instead of calling the FindClose function.</para>
        /// </returns>
        [DllImport(fileName, SetLastError = true)]
        public static extern bool CloseHandle(IntPtr hObject);

        /// <summary>
        /// 現在のプロセスに対応する疑似ハンドルを取得します。
        /// </summary>
        /// <returns>現在のプロセスの疑似ハンドルが返ります。</returns>
        [DllImport(fileName, SetLastError = true)]
        public static extern IntPtr GetCurrentProcess();
    }
}
