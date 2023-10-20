using System.Linq;

namespace BinReader.Models
{
    public class BinaryPiece
    {
        private readonly int headerLength;
        private readonly int footerLength;

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

        public byte[] Header =>
            RawBytes.Length <= headerLength ? RawBytes : RawBytes.Take(headerLength).ToArray();

        public byte[] Footer =>
            RawBytes.Length <= footerLength ? RawBytes : RawBytes.Skip(RawBytes.Length - footerLength).ToArray();

        public BinaryPiece(byte[] bytes)
        {
            RawBytes = bytes;
        }

        public BinaryPiece(byte[] bytes, int headerLength, int footerLength)
        {
            RawBytes = bytes;
            this.headerLength = headerLength;
            this.footerLength = footerLength;
        }
    }
}