using System;
using System.IO;
using BinReader.Models;
using NUnit.Framework;

namespace TestProject2.Models
{
    [TestFixture]
    public class TestBinaryFileReader
    {
        private readonly string sampleFileName = "test.txt";

        [Test]
        public void Readテスト1()
        {
            var reader = new BinaryFileReader();

            // test と書かれたテキストファイルを読み込む。
            // 先頭４つが test の文字を表し、末尾の２文字は改行コードを表している。

            var bs = reader.Read(sampleFileName);
            var exceptBs = new []
            {
                Convert.ToByte("74", 16),
                Convert.ToByte("65", 16),
                Convert.ToByte("73", 16),
                Convert.ToByte("74", 16),
                Convert.ToByte("0d", 16),
                Convert.ToByte("0a", 16),
            };

            CollectionAssert.AreEqual(bs, exceptBs);
        }

        [SetUp]
        public void SetUp()
        {
            System.Diagnostics.Debug.WriteLine($"");
            System.Diagnostics.Debug.WriteLine($"TestBinaryFileReader (26) : テストファイルを作成しました。 -----------------");
            StreamWriter sw = File.CreateText(sampleFileName);
            sw.WriteLine("test");
            sw.Close();
        }

        [TearDown]
        public void TearDown()
        {
            System.Diagnostics.Debug.WriteLine($"TestBinaryFileReader (35) : テストファイルを削除しました。------------------");
            System.Diagnostics.Debug.WriteLine($"");
            File.Delete(sampleFileName);
        }
    }
}