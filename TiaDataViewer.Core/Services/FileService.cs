using System.Windows.Forms;

namespace TiaDataViewer.Core.Services
{
    // Service to access local files
    public class FileService : IFileService
    {
        public string OpenFile()
        {
            using OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = "TIA files (*.tia)|*.tia";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog.FileName;
            }
            return string.Empty;
        }
    }
}
