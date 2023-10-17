using System.Collections.Generic;
using System.Linq;

namespace BinReader.Models
{
    public class BinarySplitter
    {
        /// <summary>
        /// 指定したリストを splitIndexes に応じて、分割し、配列のリストを作成して返します。
        /// </summary>
        /// <param name="targets">切り分ける byte のリストを入力します。</param>
        /// <param name="splitIndexes">切り分ける位置（インデックス）のリストを入力します。
        /// 切り分けの位置は、インデックスが示す要素の手前となります。
        /// </param>
        /// <returns></returns>
        public IEnumerable<byte[]> SplitArray(IEnumerable<byte> targets, IEnumerable<int> splitIndexes)
        {
            var list = targets.ToList();
            var results = new List<byte[]>();
            var lastIndex = 0;

            foreach (var i in splitIndexes)
            {
                results.Add(list.GetRange(lastIndex, i - lastIndex).ToArray());
                lastIndex = i;
            }

            // 上記のループでは、splitIndexes の最後のインデックスから list の末尾までの要素が取り出されない。
            // 下記の処理で、最後の部分を results に加える。
            results.Add(list.GetRange(lastIndex, list.Count - lastIndex).ToArray());

            return results;
        }

        public static List<BinaryPiece> Split(IEnumerable<byte> targets, List<byte> pattern)
        {
            if (pattern == null || pattern.Count == 0)
            {
                return new List<BinaryPiece>() { new BinaryPiece(targets.ToArray()), };
            }

            var list = new List<BinaryPiece>();
            var bytes = new List<byte>();
            var matchedCount = 0;
            var address = 0;

            foreach (var b in targets)
            {
                bytes.Add(b);
                address++;

                if (b == pattern[matchedCount])
                {
                    matchedCount++;
                    if (matchedCount >= pattern.Count)
                    {
                        var p = new BinaryPiece(bytes.ToArray())
                        {
                            Address = address - bytes.Count,
                        };

                        list.Add(p);
                        bytes = new List<byte>();
                        matchedCount = 0;
                    }

                    continue;
                }

                matchedCount = 0;
            }

            if (bytes.Count > 0)
            {
                var p = new BinaryPiece(bytes.ToArray())
                {
                    Address = address - bytes.Count,
                };

                list.Add(p);
            }

            return list;
        }
    }
}