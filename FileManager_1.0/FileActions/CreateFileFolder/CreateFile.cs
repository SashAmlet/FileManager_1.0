using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_1._0.FileActions.CreateFile
{
    internal class CreateFile : ICreateItem
    {
        string filePath;
        public CreateFile(string filePath)
        {
            this.filePath = filePath;
        }
        public void Create()
        {
            while (true)
            {
                try
                {
                    FileStream file = new FileStream(filePath, FileMode.CreateNew);
                    file.Close();
                    return;
                }
                catch (Exception ex1)
                {
                    var excMessArr = ex1.Message.Split(" ");
                    var exLastTwoWords = excMessArr[excMessArr.Length - 2] + " " + excMessArr[excMessArr.Length - 1];
                    if (exLastTwoWords == "already exists.")
                    {
                        var splitedName = filePath.Split('.');
                        splitedName[0] += "-copied";
                        filePath = splitedName[0] + "." + splitedName[1];
                    }
                    else
                    {
                        MessageBox.Show("createFile():: " + ex1.Message);
                        return;
                    }
                }
            }
        }
    }
}
