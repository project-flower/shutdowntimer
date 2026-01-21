using System.Runtime.InteropServices;

namespace NativeMethods
{
    public static partial class AdvApi32
    {
        /// <summary>
        /// 指定されたシステムで使われているローカル一意識別子（LUID）を取得し、指定された特権名をローカルで表現します。
        /// </summary>
        /// <param name="lpSystemName">特権名の検索に使うシステムの名前を指定する、NULL で終わる文字列へのポインタを指定します。NULL 文字列が指定された場合、この関数は特権名をローカルシステムで検索します。</param>
        /// <param name="lpName">WINNT.H ヘッダーファイル内で定義されている特権名を表す、NULL で終わる文字列を受け取るバッファへのポインタを指定します。たとえば、このパラメータに SE_SECURITY_NAME 定数や、それに対応する "SeSecurityPrivilege" 文字列を指定できます。</param>
        /// <param name="lpLuid">lpSystemName パラメータによって指定された、特権が既知となっているシステムを表す LUID を受け取る変数へのポインタを指定します。</param>
        /// <returns>
        /// 関数が成功すると、0 以外の値が返ります。
        /// 関数が失敗すると、0 が返ります。拡張エラー情報を取得するには、GetLastError関数を使います。
        /// </returns>
        [DllImport(AssemblyName, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool LookupPrivilegeValue(string lpSystemName, string lpName, out long lpLuid);
    }
}
