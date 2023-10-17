using System.Collections.ObjectModel;
using System.Linq;
using BinReader.Models;
using Prism.Mvvm;

namespace BinReader.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string searchPattern = string.Empty;

        public string Title => "Binary Reader";

        public string SearchPattern { get => searchPattern; set => SetProperty(ref searchPattern, value); }

        public ObservableCollection<BinaryPiece> BinaryPieces { get; private set; }

        public void LoadBinary(byte[] bytes)
        {
            var pattern = HexConverter.ToByteArray(SearchPattern).ToList();
            BinaryPieces = new ObservableCollection<BinaryPiece>(BinarySplitter.Split(bytes, pattern));
            RaisePropertyChanged(nameof(BinaryPieces));
        }
    }
}