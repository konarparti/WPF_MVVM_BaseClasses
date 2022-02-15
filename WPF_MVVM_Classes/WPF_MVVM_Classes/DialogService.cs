using Microsoft.Win32;
using System.Windows;

namespace WPF_MVVM_Classes
{
    public static class DialogService 
    {
        public static void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public static bool OpenFileDialog(string filter, out string filePath)
        {
            bool isSucceeded;
            var openFileDialog = new OpenFileDialog
            {
                Filter = filter
            };
            var dialogResult = openFileDialog.ShowDialog();
            if (dialogResult is true)
            {
                filePath = openFileDialog.FileName;
                isSucceeded = true;
            }
            else
            {
                filePath = string.Empty;
                isSucceeded = false;
            }
            return isSucceeded;

        }

        public static bool SaveFileDialog(string filter, out string filePath)
        {
            bool isSucceeded;
            var saveFileDialog = new SaveFileDialog
            {
                Filter = filter
            };
            var dialogResult = saveFileDialog.ShowDialog();
            if (dialogResult is true)
            {
                filePath = saveFileDialog.FileName;
                isSucceeded = true;
            }
            else
            {
                filePath = string.Empty;
                isSucceeded = false;
            }
            return isSucceeded;
        }
    }
}
