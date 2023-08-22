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

            if (lastIndex < list.Count - 1)
            {
                results.Add(list.GetRange(lastIndex, list.Count - lastIndex).ToArray());
            }

            return results;
        }
    }
}