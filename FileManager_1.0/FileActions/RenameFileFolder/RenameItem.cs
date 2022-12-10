using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_1._0.FileActions.RenameFileFolder
{
    internal static class RenameItem
    {
        public static RenameFile RenameFile(string filePath, string newName)
        {
            return new RenameFile(filePath, newName);
        }
        public static RenameFolder RenameFolder(string filePath, string newName)
        {
            return new RenameFolder(filePath, newName);
        }
    }
}
