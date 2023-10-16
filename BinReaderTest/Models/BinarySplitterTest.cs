using System.Collections.Generic;
using System.Linq;
using BinReader.Models;
using NUnit.Framework;

namespace TestProject2.Models
{
    [TestFixture]
    public class BinarySplitterTest
    {
        [Test]
        public void SplitArrayTest()
        {
            var splitter = new BinarySplitter();
            var target = new byte[] { 0, 1, 2, 3, 4, };
            var splitAddresses = new List<int> { 1, 3, };

            var results = splitter.SplitArray(target, splitAddresses).ToList();

            Assert.That(results.Count(), Is.EqualTo(3));

            CollectionAssert.AreEqual(results[0], new byte[] { 0, });
            CollectionAssert.AreEqual(results[1], new byte[] { 1, 2, });
            CollectionAssert.AreEqual(results[2], new byte[] { 3, 4, });
        }

        [Test]
        public void SplitArrayTest_2()
        {
            var splitter = new BinarySplitter();
            var target = new byte[] { 0, 1, 2, 3, 4, };
            var splitAddresses = new List<int> { 1, 3, 4, };

            var results = splitter.SplitArray(target, splitAddresses).ToList();

            Assert.That(results.Count(), Is.EqualTo(4));

            CollectionAssert.AreEqual(results[0], new byte[] { 0, });
            CollectionAssert.AreEqual(results[1], new byte[] { 1, 2, });
            CollectionAssert.AreEqual(results[2], new byte[] { 3, });
            CollectionAssert.AreEqual(results[3], new byte[] { 4, });
        }

        [Test]
        public void SplitTest()
        {
            var target = new byte[] { 0, 1, 2, 3, 4, };
            var pattern = new List<byte>() { 1, 2, };
            var result = BinarySplitter.Split(target, pattern);

            CollectionAssert.AreEqual(result[0].RawBytes, new byte[] { 0, 1, 2, });
            CollectionAssert.AreEqual(result[1].RawBytes, new byte[] { 3, 4, });
        }

        [Test]
        public void SplitTest_複数回分割()
        {
            var target = new byte[] { 0, 1, 2, 3, 1, 2, };
            var pattern = new List<byte>() { 1, 2, };
            var result = BinarySplitter.Split(target, pattern);

            CollectionAssert.AreEqual(result[0].RawBytes, new byte[] { 0, 1, 2, });
            CollectionAssert.AreEqual(result[1].RawBytes, new byte[] { 3, 1, 2, });
        }

        [Test]
        public void SplitTest_パターン一桁()
        {
            var target = new byte[] { 0, 1, 2, 0, 1, 2, };
            var pattern = new List<byte>() { 0, };
            var result = BinarySplitter.Split(target, pattern);

            CollectionAssert.AreEqual(result[0].RawBytes, new byte[] { 0, });
            CollectionAssert.AreEqual(result[1].RawBytes, new byte[] { 1, 2, 0, });
            CollectionAssert.AreEqual(result[2].RawBytes, new byte[] { 1, 2, });
        }

        [Test]
        public void SplitTest_パターン無し()
        {
            var target = new byte[] { 0, 1, 2, 0, 1, 2, };

            var patternZero = new List<byte>();
            var patternNull = new List<byte>();
            CollectionAssert.AreEqual(target, BinarySplitter.Split(target, patternZero).First().RawBytes);
            CollectionAssert.AreEqual(target, BinarySplitter.Split(target, patternNull).First().RawBytes);
        }
    }
}