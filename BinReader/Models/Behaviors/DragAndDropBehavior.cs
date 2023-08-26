using System.IO;
using System.Linq;
using System.Windows;
using Microsoft.Xaml.Behaviors;
using BinReader.ViewModels;

namespace BinReader.Models.Behaviors
{
    public class DragAndDropBehavior : Behavior<Window>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            // ファイルをドラッグしてきて、コントロール上に乗せた際の処理
            AssociatedObject.PreviewDragOver += AssociatedObject_PreviewDragOver;

            // ファイルをドロップした際の処理
            AssociatedObject.Drop += AssociatedObject_Drop;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.PreviewDragOver -= AssociatedObject_PreviewDragOver;
            AssociatedObject.Drop -= AssociatedObject_Drop;
        }

        private void AssociatedObject_Drop(object sender, DragEventArgs e)
        {
            // ファイルパスの一覧の配列
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            var vm = ((Window)sender).DataContext as MainWindowViewModel;

            if (files != null && Path.GetExtension(files.First()) == ".txt")
            {
                // vm?.Load();

                using (var fs = new FileStream(files.First(), FileMode.Open, FileAccess.Read))
                {
                    var bs = new byte[fs.Length];
                    var _ = fs.Read(bs, 0, bs.Length);
                    vm?.SetBinary(bs);
                    fs.Close();
                }
            }
        }

        private void AssociatedObject_PreviewDragOver(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Copy;
            e.Handled = e.Data.GetDataPresent(DataFormats.FileDrop);
        }
    }
}