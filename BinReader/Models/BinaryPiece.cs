namespace BinReader.Models
{
    public class BinaryPiece
    {
        public byte[] RawBytes { get; }

        public long Address { get; set; }

        public string Text => System.Text.Encoding.GetEncoding(932).GetString(RawBytes);

        public BinaryPiece(byte[] bytes)
        {
            RawBytes = bytes;
        }
    }
}