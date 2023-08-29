using BinReader.ViewModels;
using NUnit.Framework;

namespace TestProject2.ViewModels
{
    [TestFixture]
    public class MainWindowViewModelTest
    {
        [Test]
        public void SetBinariesTest()
        {
            var vm = new MainWindowViewModel
            {
                SearchPattern = "01 02",
            };

            vm.SetBinaries(new byte[] { 0x0, 0x1, 0x2, 0x3, });
            CollectionAssert.AreEqual(vm.BinaryPieces[0].RawBytes, new byte[] { 0x0, });
            CollectionAssert.AreEqual(vm.BinaryPieces[1].RawBytes, new byte[] { 0x1, 0x2, 0x3, });
        }
    }
}