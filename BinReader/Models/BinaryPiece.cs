using System.Text;

namespace BinReader.Models
{
    public class BinaryPiece
    {
        public byte[] RawBytes { get; }

        public string Text => System.Text.Encoding.GetEncoding(932).GetString(RawBytes);

        public BinaryPiece(byte[] bytes)
        {
            RawBytes = bytes;
        }
    }
}