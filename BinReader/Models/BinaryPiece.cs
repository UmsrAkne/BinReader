using System.Linq;

namespace BinReader.Models
{
    public class BinaryPiece
    {
        public byte[] RawBytes { get; }

        public string ByteArrayString
        {
            get
            {
                var s = RawBytes.Select(b => b.ToString( "X2"));
                return string.Join(" ", s);
            }
        }

        public long Address { get; set; }

        public string Text => System.Text.Encoding.GetEncoding(932).GetString(RawBytes);

        public BinaryPiece(byte[] bytes)
        {
            RawBytes = bytes;
        }
    }
}