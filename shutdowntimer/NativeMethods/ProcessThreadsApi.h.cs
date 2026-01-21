using System;
using System.Runtime.InteropServices;

namespace NativeMethods
{
    public static partial class AdvApi32
    {
        /// <summary>
        /// プロセスに関連付けられているアクセストークンを開きます。
        /// </summary>
        /// <param name="ProcessHandle">開くアクセストークンを保持するプロセスを識別します。</param>
        /// <param name="DesiredAccess">アクセストークンの要求アクセスタイプを指定するアクセスマスクを指定します。これらの要求アクセスタイプをトークンの DACL（随意アクセス制御リスト）と比較して、どのアクセスが許可され、どのアクセスが拒否されるかを決定します。</param>
        /// <param name="TokenHandle">この関数から制御が戻ったときに、新しく開かれたアクセストークンを識別するハンドルへのポインタを指定します。</param>
        /// <returns>
        /// 関数が成功すると、0 以外の値が返ります。
        /// 関数が失敗すると、0 が返ります。拡張エラー情報を取得するには、GetLastError関数を使います。
        /// </returns>
        [DllImport(AssemblyName, SetLastError = true)]
        public static extern bool OpenProcessToken(IntPtr ProcessHandle, TOKEN DesiredAccess, out IntPtr TokenHandle);
    }

    public static partial class Kernel32
    {
        /// <summary>
        /// 現在のプロセスに対応する疑似ハンドルを取得します。
        /// </summary>
        /// <returns>現在のプロセスの疑似ハンドルが返ります。</returns>
        [DllImport(AssemblyName, SetLastError = true)]
        public static extern IntPtr GetCurrentProcess();
    }
}
