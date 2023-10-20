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

        [Test]
        [TestCase(new byte[] { }, 0, new byte[] { })]
        [TestCase(new byte[] { }, 1, new byte[] { })]
        [TestCase(new byte[] { 0x0, 0x1, 0x2, }, 0, new byte[] { })]
        [TestCase(new byte[] { 0x0, 0x1, 0x2, }, 1, new byte[] { 0x0, })]
        [TestCase(new byte[] { 0x0, 0x1, 0x2, }, 2, new byte[] { 0x0, 0x1, })]
        public void HeaderTest(byte[] bytes, int length, byte[] except)
        {
            var bp = new BinaryPiece(bytes, length, 0);
            CollectionAssert.AreEqual(except, bp.Header);
        }

        [Test]
        [TestCase(new byte[] { }, 0, new byte[] { })]
        [TestCase(new byte[] { }, 1, new byte[] { })]
        [TestCase(new byte[] { 0x0, 0x1, 0x2, }, 0, new byte[] { })]
        [TestCase(new byte[] { 0x0, 0x1, 0x2, }, 1, new byte[] { 0x2, })]
        [TestCase(new byte[] { 0x0, 0x1, 0x2, }, 2, new byte[] { 0x1, 0x2, })]
        public void FooterTest(byte[] bytes, int length, byte[] except)
        {
            var bp = new BinaryPiece(bytes, 0, length);
            CollectionAssert.AreEqual(except, bp.Footer);
        }
    }
}