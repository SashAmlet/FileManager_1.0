using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_1._0.FileActions.CreateFile
{
    internal class CreateFolder : ICreateItem
    {
        string filePath;
        public CreateFolder(string filePath)
        {
            this.filePath = filePath;
        }
        public void Create()
        {
            while (true)
            {
                try
                {

                    if (Directory.Exists(filePath))// 
                        throw new Exception("Such a folder is already exists.");
                    Directory.CreateDirectory(filePath);
                    return;
                }
                catch (Exception ex1)
                {
                    var excMessArr = ex1.Message.Split(" ");
                    var exLastTwoWords = excMessArr[excMessArr.Length - 2] + " " + excMessArr[excMessArr.Length - 1];
                    if (exLastTwoWords == "already exists.")
                    {
                        filePath = filePath.TrimEnd('\\') + "-copied\\";
                    }
                    else
                    {
                        MessageBox.Show("createFolder():: " + ex1.Message);
                        return;
                    }
                }
            }
        }
    }
}
