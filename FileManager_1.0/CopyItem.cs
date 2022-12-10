using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_1._0
{
    internal struct CopyItem
    {
        public List<string> copiedItemFilePathes { get; set; }
        public List<string> cashCopiedItemFilePathes { get; set; }
        public List<string> selectedItemFilePathes { get; set; }
        public string destinationFilePath { get; set; }
        public List<string> fullFilePathes { get; set; }
        public void existingName(int i)
        {
            var splitedName = fullFilePathes[i].Split('.');
            splitedName[0] += "-copied";
            fullFilePathes[i] = splitedName[0] + "." + splitedName[1];
        }
        public bool isFolder(string filePath)
        {
            var ext = filePath.Split(".");
            if (ext.Length > 1)
                return false;
            return true;
        }

    }
}
