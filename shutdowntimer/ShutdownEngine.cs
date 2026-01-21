using System;
using NativeMethods;

namespace shutdowntimer
{
    static class ShutdownEngine
    {
        public enum ShutDownSwitch
        {
            PowerOff,
            Reboot,
            LogOff,
            StandBy,
            Hibernate
        }

        /// <summary>
        /// コンピューターを強制的にシャットダウン・再起動・ログオフ・スタンバイ・休止状態にします。
        /// </summary>
        /// <param name="shutDownSwitch"></param>
        public static void ShutDown(ShutDownSwitch shutDownSwitch)
        {
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                adjustToken();
            }

            EWX ewx = EWX.FORCE;

            switch (shutDownSwitch)
            {
                case ShutDownSwitch.PowerOff:
                    ewx |= EWX.POWEROFF;
                    break;

                case ShutDownSwitch.Reboot:
                    ewx |= EWX.REBOOT;
                    break;

                case ShutDownSwitch.LogOff:
                    ewx |= EWX.LOGOFF;
                    break;

                case ShutDownSwitch.StandBy:
                case ShutDownSwitch.Hibernate:
                    bool hibernate = (shutDownSwitch == ShutDownSwitch.Hibernate);
                    PowrProf.SetSuspendState(hibernate, true, true);
                    return;

                default:
                    throw new ArgumentException();
            }

            User32.ExitWindowsEx(ewx, 0);
        }

        static void adjustToken()
        {
            IntPtr processhandle = Kernel32.GetCurrentProcess();
            IntPtr tokenHandle;
            AdvApi32.OpenProcessToken(processhandle, (TOKEN.ADJUST_PRIVILEGES | TOKEN.QUERY), out tokenHandle);
            var newState = new TOKEN_PRIVILEGES();
            newState.Privileges.Attributes = SE.PRIVILEGE_ENABLED;
            newState.PrivilegeCount = 1;
            AdvApi32.LookupPrivilegeValue(null, SE.SHUTDOWN_NAME, out newState.Privileges.Luid);
            AdvApi32.AdjustTokenPrivileges(tokenHandle, false, ref newState, 0, IntPtr.Zero, IntPtr.Zero);
            Kernel32.CloseHandle(tokenHandle);
        }
    }
}
