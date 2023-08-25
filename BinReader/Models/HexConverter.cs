using System;
using System.Linq;

namespace BinReader.Models
{
    public class HexConverter
    {
        /// <summary>
        /// 指定した16進数を表す文字列が、実際に変換可能かどうかを取得します。
        /// </summary>
        /// <param name="hexString">16進数を表す文字列。
        /// このメソッドは、アプリの仕様上、文字数が奇数の場合は必ず false を返す。
        /// </param>
        /// <returns>指定した文字列が、数値に変換できるかを返す。</returns>
        public static bool CanConvert(string hexString)
        {
            var str = hexString.Replace(" ", "");

            if (str.Length % 2 == 1)
            {
                return false;
            }

            return str.All(Uri.IsHexDigit);
        }
    }
}