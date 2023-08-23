using System.Collections.Generic;

namespace BinReader.Models
{
    public class BinaryChecker
    {
        private int matchedCount;
        private byte[] searchPattern;

        public byte[] SearchPattern
        {
            get => searchPattern;
            set
            {
                matchedCount = 0;
                searchPattern = value;
            }
        }

        public int CheckedCount { get; private set; }

        public List<int> MatchedHeaderAddress { get; } = new List<int>();

        public List<int> MatchedFooterAddress { get; } = new List<int>();

        /// <summary>
        /// pattern に完全に一致する順番で value が入力されたとき、 true を返し、それ以外の場合は false を返します。
        /// </summary>
        /// <param name="value"></param>
        /// <returns>pattern と value が一致したかどうかを返す</returns>
        public bool IsMatched(byte value)
        {
            CheckedCount++;

            if (SearchPattern.Length == 0)
            {
                return false;
            }

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
            MatchedHeaderAddress.Add(CheckedCount - SearchPattern.Length);
            MatchedFooterAddress.Add(CheckedCount - 1);
            return true;
        }
    }
}