using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_1._0.FileActions.RenameFileFolder
{
    internal class RenameFile: IRenameItem
    {
        string filePath, newName;
        public RenameFile(string filePath, string newName)
        {
            this.filePath = filePath;
            this.newName = newName;
        }
        public void Rename()
        {
            var oldPathItemArr = filePath.Split('\\');
            oldPathItemArr[oldPathItemArr.Length - 1] = null;
            var newPath = string.Join("\\", oldPathItemArr) + newName;
            try
            {
                Microsoft.VisualBasic.FileSystem.Rename(filePath, newPath);
            }
            catch (Exception ex0)
            {
                MessageBox.Show("Файл з таким ім'ям вже існує");
            }
        }
    }
}
