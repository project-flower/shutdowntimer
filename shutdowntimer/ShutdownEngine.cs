using System;
using NativeMethods;

namespace shutdowntimer
{
    static class ShutdownEngine
    {
        #region Public Classes

        public enum ShutDownSwitch
        {
            PowerOff,
            Reboot,
            Logoff,
            StandBy,
            Hibernate
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// コンピューターを強制的にシャットダウン・再起動・ログオフ・スタンバイ・休止状態にします。
        /// </summary>
        /// <param name="shutdownSwitch"></param>
        public static void DoShutdown(ShutDownSwitch shutdownSwitch)
        {
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                AdjustToken();
            }

            EWX ewx = EWX.FORCE;

            switch (shutdownSwitch)
            {
                case ShutDownSwitch.PowerOff:
                    ewx |= EWX.POWEROFF;
                    break;

                case ShutDownSwitch.Reboot:
                    ewx |= EWX.REBOOT;
                    break;

                case ShutDownSwitch.Logoff:
                    ewx |= EWX.LOGOFF;
                    break;

                case ShutDownSwitch.StandBy:
                case ShutDownSwitch.Hibernate:
                    PowrProf.SetSuspendState((shutdownSwitch == ShutDownSwitch.Hibernate), true, true);
                    return;

                default:
                    throw new ArgumentException();
            }

            User32.ExitWindowsEx(ewx, 0);
        }

        #endregion

        #region Private Methods

        private static void AdjustToken()
        {
            IntPtr processhandle = Kernel32.GetCurrentProcess();
            AdvApi32.OpenProcessToken(processhandle, (TOKEN.ADJUST_PRIVILEGES | TOKEN.QUERY), out IntPtr tokenHandle);
            var newState = new TOKEN_PRIVILEGES();
            newState.Privileges.Attributes = SE.PRIVILEGE_ENABLED;
            newState.PrivilegeCount = 1;
            AdvApi32.LookupPrivilegeValue(null, SE.SHUTDOWN_NAME, out newState.Privileges.Luid);
            AdvApi32.AdjustTokenPrivileges(tokenHandle, false, ref newState, 0, IntPtr.Zero, IntPtr.Zero);
            Kernel32.CloseHandle(tokenHandle);
        }

        #endregion
    }
}
