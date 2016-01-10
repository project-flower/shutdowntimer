using System.Runtime.InteropServices;
using Win32API.WinUser;

namespace Win32API
{
    static class User32
    {
        /// <summary>
        /// user32.dllのファイル名
        /// </summary>
        const string fileName = "user32.dll";

        /// <summary>
        /// Logs off the interactive user, shuts down the system, or shuts down and restarts the system. It sends the WM_QUERYENDSESSION message to all applications to determine if they can be terminated.
        /// </summary>
        /// <param name="uFlags">The shutdown type. This parameter must include one of the following values.</param>
        /// <param name="dwReason">
        /// The reason for initiating the shutdown.This parameter must be one of the system shutdown reason codes.
        /// <para>If this parameter is zero, the SHTDN_REASON_FLAG_PLANNED reason code will not be set and therefore the default action is an undefined shutdown that is logged as "No title for this reason could be found". By default, it is also an unplanned shutdown. Depending on how the system is configured, an unplanned shutdown triggers the creation of a file that contains the system state information, which can delay shutdown. Therefore, do not use zero for this parameter.</para>
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero. Because the function executes asynchronously, a nonzero return value indicates that the shutdown has been initiated. It does not indicate whether the shutdown will succeed. It is possible that the system, the user, or another application will abort the shutdown.
        /// <para>If the function fails, the return value is zero.To get extended error information, call GetLastError.</para>
        /// </returns>
        [DllImport(fileName, SetLastError = true)]
        public static extern bool ExitWindowsEx(EWX uFlags, int dwReason);
    }
}
