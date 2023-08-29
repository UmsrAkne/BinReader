using BinReader.Models;
using NUnit.Framework;

namespace TestProject2.Models
{
    [TestFixture]
    public class BinaryPieceTest
    {
        [Test]
        public void TextTest()
        {
            var bp = new BinaryPiece(new byte[] { 0x61, 0x62, });
            Assert.That("ab", Is.EqualTo(bp.Text), "0x61, 0x62 は Shift-Jis でそれぞれ a, b を表す");
        }
    }
}