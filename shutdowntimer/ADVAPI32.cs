using System;
using System.Runtime.InteropServices;
using Win32API.WinNT;

namespace Win32API
{
    static class ADVAPI32
    {
        /// <summary>
        /// advapi32.dllのファイル名
        /// </summary>
        const string fileName = "advapi32.dll";

        /// <summary>
        /// 指定したアクセストークン内の特権を有効または無効にします。TOKEN_ADJUST_PRIVILEGES アクセス権が必要です。
        /// </summary>
        /// <param name="TokenHandle">変更したい特権を保持するアクセストークンを指定します。このハンドルは、トークンに対する TOKEN_ADJUST_PRIVILEGES アクセス権を備えていなければなりません。PreviousState パラメータが NULL ではない場合、このハンドルは TOKEN_QUERY アクセス権も必要です。</param>
        /// <param name="DisableAllPrivileges">トークンのすべての特権を無効にするかどうかを指定します。この値が TRUE の場合、関数はすべての特権を無効にし、NewState パラメータを無視します。FALSE の場合、この関数は NewState パラメータが指す情報に基づいて特権に変更を加えます。</param>
        /// <param name="NewState">
        /// 特権とその属性からなる配列を TOKEN_PRIVILEGES 構造体へのポインタを指定します。DisableAllPrivileges パラメータが FALSE の場合、AdjustTokenPrivileges 関数は配列内の値に従って、トークンの特権を有効または無効にします。ある特権の SE_PRIVILEGE_ENABLED 属性をセットしておくと、その特権が有効になります。属性をクリアしておくと、特権が無効になります。
        /// DisableAllPrivileges が TRUE の場合、関数はこのパラメータを無視します。 
        /// </param>
        /// <param name="BufferLength">PreviousState パラメータが指すバッファのサイズをバイト単位で指定します。PreviousState パラメータが NULL の場合、このパラメータは 0 でもかまいません。</param>
        /// <param name="PreviousState">
        /// この関数の変更対象となる特権の、従来の状態を保持する TOKEN_PRIVILEGES 構造体を受け取るバッファへのポインタを指定します。このパラメータは、NULL でもかまいません。
        /// 指定したバッファが小さすぎて、変更後の特権の完全なリストを受け取れない場合、関数は失敗し、どの特権も調整されません。その場合、ReturnLength パラメータが指す変数の値は、変更後の特権の完全なリストを保持するために必要なバイト数に設定されます。 </param>
        /// <param name="ReturnLength">PreviousState パラメータが指すバッファが必要とするバイト数を受け取る変数へのポインタを指定します。PreviousState が NULL の場合、このパラメータは NULL でもかまいません。</param>
        /// <returns>
        /// 関数が成功すると、0 以外の値が返ります。
        /// 関数が失敗すると、0 が返ります。拡張エラー情報を取得するには、GetLastError関数を使います。
        /// </returns>
        [System.Runtime.InteropServices.DllImport(fileName, SetLastError = true)]
        public static extern bool AdjustTokenPrivileges(IntPtr TokenHandle, bool DisableAllPrivileges, ref TOKEN_PRIVILEGES NewState, int BufferLength, IntPtr PreviousState, IntPtr ReturnLength);

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
        [DllImport(fileName, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool LookupPrivilegeValue(string lpSystemName, string lpName, out long lpLuid);

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
        [DllImport(fileName, SetLastError = true)]
        public static extern bool OpenProcessToken(IntPtr ProcessHandle, TOKEN DesiredAccess, out IntPtr TokenHandle);
    }
}
