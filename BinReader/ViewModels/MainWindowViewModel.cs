using System.Collections.ObjectModel;
using System.Linq;
using BinReader.Models;
using Prism.Mvvm;

namespace BinReader.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public string Title => "Binary Reader";

        public string SearchPattern { get; set; } = string.Empty;
        
        public ObservableCollection<BinaryPiece> BinaryPieces { get; private set; }

        /// <summary>
        /// this.SearchPattern に入力されているテキストを元に、入力値から BinaryPieces のリストを生成。
        /// BinaryPieces にセットします。
        /// this.SearchPattern に不正な値が入力されている場合は処理中断します。
        /// </summary>
        /// <param name="bytes">BinaryPieces の元となる byte の配列</param>
        public void SetBinaries(byte[] bytes)
        {
            if (!HexConverter.CanConvert(SearchPattern))
            {
                return;
            }
            
            var checker = new BinaryChecker();
            checker.SearchPattern = HexConverter.ToByteArray(SearchPattern);
            foreach (var b in bytes)
            {
                checker.IsMatched(b);
            }
            
            var matches = checker.MatchedHeaderAddress;

            var splitter = new BinarySplitter();
            BinaryPieces = new ObservableCollection<BinaryPiece>(
                splitter.SplitArray(bytes, matches).Select(b => new BinaryPiece(b)));
        }
    }
}
