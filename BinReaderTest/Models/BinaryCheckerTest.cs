using BinReader.Models;
using NUnit.Framework;

namespace TestProject2.Models
{
    [TestFixture]
    public class BinaryCheckerTest
    {
        [Test]
        public void IsMatchedTest_正常系()
        {
            var checker = new BinaryChecker
            {
                SearchPattern = new byte[] { 02, 03, },
            };

            Assert.That(checker.IsMatched(1), Is.False);
            Assert.That(checker.IsMatched(2), Is.False);
            Assert.That(checker.IsMatched(3), Is.True, "2,3 のパターンが出現したので true");
            Assert.That(checker.IsMatched(2), Is.False);
            Assert.That(checker.IsMatched(3), Is.True, "2,3 のパターンが出現したので 再び true");
            Assert.That(checker.IsMatched(4), Is.False);
        }

        [Test]
        public void IsMatchedTest_パターン空白()
        {
            var checker = new BinaryChecker
            {
                SearchPattern = new byte[] { },
            };

            Assert.That(checker.IsMatched(1), Is.False, "チェック可能だが、常に false");
            Assert.That(checker.IsMatched(2), Is.False, "チェック可能だが、常に false");
        }

        [Test]
        public void マッチしたアドレスの記録のチェック()
        {
            var checker = new BinaryChecker
            {
                SearchPattern = new byte[] { 02, 03, },
            };

            checker.IsMatched(1); // address = 0

            checker.IsMatched(2); // address = 1
            checker.IsMatched(3); // address = 2
            checker.IsMatched(4); // address = 3

            checker.IsMatched(2); // address = 4
            checker.IsMatched(3); // address = 5
            checker.IsMatched(4); // address = 6

            Assert.That(2, Is.EqualTo(checker.MatchedFooterAddress[0]));
            Assert.That(5, Is.EqualTo(checker.MatchedFooterAddress[1]));

            Assert.That(1, Is.EqualTo(checker.MatchedHeaderAddress[0]));
            Assert.That(4, Is.EqualTo(checker.MatchedHeaderAddress[1]));
        }
    }
}