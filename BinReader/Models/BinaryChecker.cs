using System.Collections.Generic;

namespace BinReader.Models
{
    public class BinaryChecker
    {
        private int matchedCount;

        public byte[] SearchPattern { get; set; } = { };
        
        /// <summary>
        /// pattern に完全に一致する順番で value が入力されたとき、 true を返し、それ以外の場合は false を返します。
        /// </summary>
        /// <param name="value"></param>
        /// <returns>pattern と value が一致したかどうかを返す</returns>
        public bool IsMatched(byte value)
        {
            if (SearchPattern[matchedCount] != value)
            {
                matchedCount = 0;
                
                // カウンターがリセットされた状態で、0番目の番号と一致するか確認する。
                if (SearchPattern[matchedCount] == value)
                {
                    matchedCount++;
                }

                return false;
            }

            matchedCount++;
            
            if (matchedCount < SearchPattern.Length)
            {
                return false;
            }

            matchedCount = 0;
            return true;
        }
    }
}