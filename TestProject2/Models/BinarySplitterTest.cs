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
            var target = new byte[] { 0, 1, 2, 3, 4,};
            var splitAddresses = new List<int> { 1, 3, };

            var results = splitter.SplitArray(target, splitAddresses).ToList();
            
            Assert.That(results.Count(), Is.EqualTo(3));
            
            CollectionAssert.AreEqual(results[0], new byte[] { 0, });
            CollectionAssert.AreEqual(results[1], new byte[] { 1, 2, });
            CollectionAssert.AreEqual(results[2], new byte[] { 3, 4, });
        }
    }
}