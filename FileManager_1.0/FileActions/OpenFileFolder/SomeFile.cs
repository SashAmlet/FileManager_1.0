﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_1._0.FileActions.OpenFileClasses
{
    internal class SomeFile : IFile
    {
        string fullFilePath = string.Empty;
        public SomeFile(string fullFilePath)
        {
            this.fullFilePath = fullFilePath;
        }
        void IFile.startProcess()
        {
            return;
            //Process.Start(@"E:\Proga\C#\TextEditor_1.0\TextEditor_1.0\bin\Debug\net6.0-windows\TextEditor_1.0.exe", fullFilePath);
        }
    }
}
