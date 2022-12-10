using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_1._0.FileActions.RenameFileFolder
{
    internal class RenameFolder: IRenameItem
    {
        string filePath, newName;
        public RenameFolder(string filePath, string newName)
        {
            this.filePath = filePath;
            this.newName = newName;

        }
        public void Rename()
        {
            var oldPathItemArr = filePath.Split('\\');
            oldPathItemArr = oldPathItemArr.SkipLast(2).ToArray();
            var newPath = string.Join("\\", oldPathItemArr) + '\\' + newName + "\\";
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
