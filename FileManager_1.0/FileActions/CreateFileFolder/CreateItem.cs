using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_1._0.FileActions.CreateFile
{
    internal static class CreateItem
    {
        public static CreateFolder CreateFolder(string filePath)
        {
            return new CreateFolder(filePath);
        }
        public static CreateFile CreateFile(string filePath)
        {
            return new CreateFile(filePath);
        }
    }
}
