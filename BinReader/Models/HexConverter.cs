using System;
using System.Collections.Generic;
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

        public static byte[] ToByteArray(string hexString)
        {
            var str = hexString.Replace(" ", "");

            var subStrings = new List<string>();
            for (int i = 0; i < str.Length / 2; i++)
            {
                subStrings.Add(str.Substring(i * 2 , 2));
            }

            return subStrings.Select(s => Convert.ToByte(s, 16)).ToArray();
        }
    }
}