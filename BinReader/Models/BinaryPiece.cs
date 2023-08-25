namespace BinReader.Models
{
    public class BinaryPiece
    {
        public byte[] RawBytes { get; }

        public BinaryPiece(byte[] bytes)
        {
            RawBytes = bytes;
        }
    }
}