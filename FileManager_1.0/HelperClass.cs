using FileManager_1._0.FileActions.OpenFileClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileManager_1._0
{
    internal static class HelperClass
    {
        public static void LoadFilesAndDirectories(TreeView treeView, ListView listView, string filePath)
        {
            DirectoryInfo fileList;
            try
            {
                fileList = new DirectoryInfo(filePath);
                FileInfo[] files = fileList.GetFiles();
                DirectoryInfo[] dires = fileList.GetDirectories();

                treeView.BeginUpdate();
                treeView.Nodes.Clear();
                foreach (DirectoryInfo dire in dires)
                {
                    treeView.Nodes.Add(dire.Name);
                }
                treeView.EndUpdate();

                listView.BeginUpdate();
                listView.Items.Clear();
                foreach (FileInfo file in files)
                {
                    listView.Items.Add(file.Name);
                }
                listView.EndUpdate();

            }
            catch (Exception e)
            {
                MessageBox.Show("loadFilesAndDirectories:: " + e.Message);
                throw new Exception( "No such directory exists");
            }

        }
        public static void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
        {
            // Get information about the source directory
            var dir = new DirectoryInfo(sourceDir);
            var desDir = new DirectoryInfo(destinationDir);

            // Check if the source directory exists
            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

            // Cache directories before we start copying
            DirectoryInfo[] dirs = dir.GetDirectories();
            // the same name check
            if (desDir.Exists)
            {
                CopyDirectory(sourceDir, destinationDir + "-copied", recursive);
                return;
            }
            // Create the destination directory
            Directory.CreateDirectory(destinationDir);

            // Get the files in the source directory and copy to the destination directory
            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
            }

            // If recursive and copying subdirectories, recursively call this method
            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestinationDir, true);
                }
            }
        }
        private static void ClearSelection(ListView listView)
        {
            foreach (ListViewItem item in listView.Items)
            {
                item.Selected = false;
            }
        }
        public static void SearchFunc(ListView listView, string searchedText)
        {
            // Шукаю у listView файлики, що містять в імені searchedText, і виділяю їх
            ClearSelection(listView);
            if (searchedText != string.Empty)
            {
                foreach (ListViewItem _item in listView.Items)
                {
                    Regex regex = new Regex(searchedText);
                    var matches = regex.Matches(_item.Text);
                    if (matches.Count > 0)
                    {
                        _item.Selected = true;
                        listView.Focus();// = true;
                    }

                }
            }
            else
                MessageBox.Show("Fill in the text field");
        }
        public static string RemoveLastTag(string filePath)
        {
            // Прибираю останній елемент в посиланні (C:\a\b\c\ -> C:\a\b\)
            string[] filePathArr = filePath.Split("\\").Length > 2 ? filePath.Split("\\").SkipLast(2).ToArray() : new string[] { filePath.TrimEnd('\\') };
            filePath = filePathArr.Length > 1 ? string.Join("\\", filePathArr) + "\\" : filePathArr[0] + "\\";
            return filePath;
        }
    }
}
