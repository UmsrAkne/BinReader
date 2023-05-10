using System;
using System.IO;

namespace BinReader.Models
{
    public class BinaryFileReader
    {
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