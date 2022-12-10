using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_1._0.FileActions.OpenFileClasses
{
    internal class OpenFile
    {
        string itemName, filePath;
        public OpenFile(string itemName, string filePath)
        {
            this.filePath = filePath;
            this.itemName = itemName;
        }
        private string ExtensionSearch(string fullName)
        {
            var arr = fullName.Split('.');
            return arr[arr.Length - 1];
        }
        public void Open()
        {
            var extension = ExtensionSearch(itemName);
            var fullFilePath = filePath + itemName;
            IFile openedFile;
            if (extension == "txt")
            {
                openedFile = new TXTFile(fullFilePath);
            }
            else if (extension == "xml")
            {
                openedFile = new XMLFile(fullFilePath);
            }
            else
            {
                openedFile = new SomeFile(fullFilePath);
            }
            openedFile.startProcess();

            /*string baseKey = @"Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\." + ext;

            List<string> progPathes = new List<string>();



            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey(baseKey + @"\OpenWithList"))
            {
                if (rk != null)
                {
                    string mruList = (string)rk.GetValue("MRUList");
                    if (mruList != null)
                    {
                        foreach (char c in mruList.ToString())
                            progPathes.Add(rk.GetValue(c.ToString()).ToString());
                    }
                }
            }

            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey(baseKey + @"\OpenWithProgids"))
            {
                if (rk != null)
                {
                    foreach (string item in rk.GetValueNames())
                        progPathes.Add(item);
                }
            }
            var program_files_folder = Environment.Is64BitProcess
                                     ? Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)
                                     : Environment.GetEnvironmentVariable("ProgramW6432");
            var program_files_x86_folder = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
            var txFile = program_files_folder + "\\" + progPathes[1]; //"C:\Program Files\WindowsApps\Microsoft.WindowsNotepad_11.2209.6.0_x64__8wekyb3d8bbwe\Notepad\Notepad.exe"
            Process.Start(txFile);*/
            /*using (RegistryKey rk = Registry.CurrentUser.OpenSubKey(baseKey + @"\OpenWithList"))
            {
                    string mruList = (string)rk.GetValue("MRUList");
                    if (mruList != null)
                    {
                        int i = 0;
                        foreach (char c in mruList.ToString())
                        {
                            progPathes.Add(rk.GetValue(c.ToString()).ToString());
                            var fullFilePath = filePath + "\\" + listView.SelectedItems[0].Text;
                            try
                            {
                                System.Diagnostics.Process.Start(progPathes[i], fullFilePath);
                                return;
                            }
                            catch { i++; }
                        }
                        MessageBox.Show("Unfortunately, we can't read such an extensions(((");

                    }
                
            }*/
        }
    }
}
