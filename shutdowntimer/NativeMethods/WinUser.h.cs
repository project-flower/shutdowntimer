using System.Runtime.InteropServices;

namespace NativeMethods
{
    /// <summary>
    /// winuser.h
    /// </summary>
    public enum EWX
    {
        /// <summary>
        /// Shuts down all processes running in the logon session of the process that called the ExitWindowsEx function. Then it logs the user off.
        /// This flag can be used only by processes running in an interactive user's logon session.
        /// </summary>
        LOGOFF = 0x00000000,
        /// <summary>
        /// Shuts down the system to a point at which it is safe to turn off the power. All file buffers have been flushed to disk, and all running processes have stopped.
        /// The calling process must have the SE_SHUTDOWN_NAME privilege. For more information, see the following Remarks section.
        /// Specifying this flag will not turn off the power even if the system supports the power-off feature. You must specify EWX_POWEROFF to do this.
        /// Windows XP with SP1:  If the system supports the power-off feature, specifying this flag turns off the power.
        /// </summary>
        SHUTDOWN = 0x00000001,
        /// <summary>
        /// Shuts down the system and then restarts the system.
        /// The calling process must have the SE_SHUTDOWN_NAME privilege. For more information, see the following Remarks section.
        /// </summary>
        REBOOT = 0x00000002,
        /// <summary>
        /// This flag has no effect if terminal services is enabled. Otherwise, the system does not send the WM_QUERYENDSESSION message. This can cause applications to lose data. Therefore, you should only use this flag in an emergency.
        /// </summary>
        FORCE = 0x00000004,
        /// <summary>
        /// Shuts down the system and turns off the power. The system must support the power-off feature.
        /// The calling process must have the SE_SHUTDOWN_NAME privilege. For more information, see the following Remarks section.
        /// </summary>
        POWEROFF = 0x00000008,
        /// <summary>
        /// Forces processes to terminate if they do not respond to the WM_QUERYENDSESSION or WM_ENDSESSION message within the timeout interval. For more information, see the Remarks.
        /// </summary>
        FORCEIFHUNG = 0x00000010,
        /// <summary>
        /// Shuts down the system and then restarts it, as well as any applications that have been registered for restart using the RegisterApplicationRestart function. These application receive the WM_QUERYENDSESSION message with lParam set to the ENDSESSION_CLOSEAPP value. For more information, see Guidelines for Applications.
        /// </summary>
        RESTARTAPPS = 0x00000040,
        /// <summary>
        /// Beginning with Windows 8:  You can prepare the system for a faster startup by combining the EWX_HYBRID_SHUTDOWN flag with the EWX_SHUTDOWN flag. 
        /// </summary>
        HYBRID_SHUTDOWN = 0x00400000,
        BOOTOPTIONS = 0x01000000
    }

    public static partial class User32
    {
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
        [DllImport(AssemblyName, SetLastError = true)]
        public static extern bool ExitWindowsEx(EWX uFlags, int dwReason);
    }
}
