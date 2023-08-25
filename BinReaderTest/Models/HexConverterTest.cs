using BinReader.Models;
using NUnit.Framework;

namespace TestProject2.Models
{
    [TestFixture]
    public class HexConverterTest
    {
        [Test]
        public void CanConvertTest()
        {
            Assert.IsTrue(HexConverter.CanConvert("0a"));
            Assert.IsTrue(HexConverter.CanConvert("0aff"));
            Assert.IsTrue(HexConverter.CanConvert("0a ff"), "スペースを含む入力");
            Assert.IsTrue(HexConverter.CanConvert(" 0a ff "), "スペースを含む入力2");
            Assert.IsTrue(HexConverter.CanConvert(string.Empty), "入力が空文字でも問題は起こらないので true");
            
            Assert.IsFalse(HexConverter.CanConvert("1"), "文字数奇数なので不可");
            Assert.IsFalse(HexConverter.CanConvert("0af"), "文字数奇数なので不可");
        }

        [Test]
        public void ToByteArrayTest()
        {
            CollectionAssert.AreEqual(new byte[] { 0xa, }, HexConverter.ToByteArray("0a"));
            CollectionAssert.AreEqual(new byte[] { 0, 0xa, }, HexConverter.ToByteArray("00 0a"));
        }
    }
}