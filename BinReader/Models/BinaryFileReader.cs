using System;
using System.IO;

namespace BinReader.Models
{
    public class BinaryFileReader
    {
        private int matchedCount;
        private int counterFromMatched;
        private bool matched;

        public void Edit(byte[] pattern, byte[] bytes)
        {
            foreach (var b in bytes)
            {
                if (IsMatched(pattern, b))
                {
                    matched = true;
                    counterFromMatched = 0;
                }

                if (matched)
                {
                    if (counterFromMatched % 4 == 0)
                    {
                        System.Diagnostics.Debug.WriteLine($"");
                        System.Diagnostics.Debug.WriteLine($"BinaryFileReader (26) : binary = {b}");
                        System.Diagnostics.Debug.WriteLine($"BinaryFileReader (27) : counterfm = {counterFromMatched}");
                        System.Diagnostics.Debug.WriteLine($"");
                    }
                    
                    counterFromMatched++;
                }

                System.Diagnostics.Debug.WriteLine($"BinaryFileReader (14) : {b}");
            }
        }
        
        /// <summary>
        /// pattern に完全に一致する順番で value が入力されたとき、 true を返し、それ以外の場合は false を返します。
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="value"></param>
        /// <returns>pattern と value が一致したかどうかを返す</returns>
        public bool IsMatched(byte[] pattern, byte value)
        {
            if (pattern[matchedCount] != value)
            {
                matchedCount = 0;
                if (pattern[matchedCount] == value)
                {
                    matchedCount++;
                }

                return false;
            }

            matchedCount++;
            if (matchedCount >= pattern.Length)
            {
                matchedCount = 0;
                return true;
            }

            return false;
        }

        public byte[] Read(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);

            int fileSize = (int)fs.Length; // ファイルのサイズ
            byte[] buf = new byte[fileSize]; // データ格納用配列

            int remain = fileSize; // 読み込むべき残りのバイト数
            int bufPos = 0; // データ格納用配列内の追加位置

            while (remain > 0)
            {
                var readSize = fs.Read(buf, bufPos, Math.Min(1024, remain)); // Readメソッドで読み込んだバイト数
                bufPos += readSize;
                remain -= readSize;
            }

            fs.Dispose();
            return buf;
        }
    }
}