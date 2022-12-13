using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_1._0.FileActions.OpenFileClasses
{
    internal class XMLFile : IFile
    {
        string fullFilePath = string.Empty;
        public XMLFile(string fullFilePath)
        {
            this.fullFilePath = fullFilePath;
        }
        void IFile.startProcess()
        {
            Process.Start(@"TextEditor\TextEditor_1.0.exe", fullFilePath);
        }
    }
}
