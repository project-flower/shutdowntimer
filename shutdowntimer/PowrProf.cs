using System.Runtime.InteropServices;

namespace Win32API
{
    static class PowrProf
    {
        [DllImport(fileName, SetLastError = true)]
        public static extern bool SetSuspendState(bool Hibernate, bool ForceCritical, bool DisableWakeEvent);

        /// <summary>
        /// powrprof.dllのファイル名
        /// </summary>
        const string fileName = "powrprof.dll";
    }
}
