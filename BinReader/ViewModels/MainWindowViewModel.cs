using System.Collections.Generic;
using BinReader.Models;
using Prism.Mvvm;

namespace BinReader.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public string Title => "Binary Reader";

        public List<BinaryPiece> BinaryPieces { get; private set; } = new List<BinaryPiece>();

        public void SetBinary(byte[] bytes)
        {
            BinaryPieces.Add(new BinaryPiece(bytes));
        }
    }
}
