using System;
using System.Runtime.InteropServices;

namespace NativeMethods
{
    public static partial class AdvApi32
    {
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
        [DllImport(AssemblyName, SetLastError = true)]
        public static extern bool AdjustTokenPrivileges(IntPtr TokenHandle, bool DisableAllPrivileges, ref TOKEN_PRIVILEGES NewState, int BufferLength, IntPtr PreviousState, IntPtr ReturnLength);
    }
}
