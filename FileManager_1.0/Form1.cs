using FileManager_1._0.FileActions.CreateFile;
using FileManager_1._0.FileActions.OpenFileClasses;
using FileManager_1._0.FileActions.RenameFileFolder;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using System;
using System.Configuration;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.LinkLabel;

namespace FileManager_1._0
{
    public partial class FileManagerForm : Form
    {
        // // // Initialization part // // //

        private string _filePathLeft;// = "D:\\";
        private string _filePathRight;// = "E:\\";
        private string filePathLeft
        { 
            get { return _filePathLeft;}
            set { _filePathLeft = value; Rebuild(value); }
        }
        private string filePathRight 
        { 
            get { return _filePathRight; }
            set { _filePathRight = value; Rebuild(value); }
        }

        // // // 
        public FileManagerForm()
        {
            InitializeComponent();
        }
        // // // Open disk (with Dialog) // // //
        private void openButtonClick(TreeView treeView, ListView listView, string side)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Select your path" })
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    filePathLeft = side == "LEFT" ? fbd.SelectedPath : filePathLeft;
                    filePathRight = side == "LEFT" ? filePathRight : fbd.SelectedPath;
                    comboBoxUpdate();
                }
                else
                    return;
            }
            HelperClass.LoadFilesAndDirectories(treeView, listView, side == "LEFT" ? filePathLeft : filePathRight);
        }
        private void openLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openButtonClick(treeViewLeft, listViewLeft, "LEFT");
        }
        private void openRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openButtonClick(treeViewRight, listViewRight, "RIGHT");
        }
        // // // Update File Manager // // // 
        void updateFileManagerFunc()
        {
            if (filePathLeft != null)
            {
                HelperClass.LoadFilesAndDirectories(treeViewLeft, listViewLeft, filePathLeft);
            }
            if (filePathRight != null)
            {
                HelperClass.LoadFilesAndDirectories(treeViewRight, listViewRight, filePathRight);
            }
            comboBoxUpdate();

        }
        private void treeViewLeft_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (!filePathLeft[filePathLeft.Length - 1].Equals('\\'))
                    filePathLeft += "\\";
                filePathLeft += treeViewLeft.SelectedNode.Text + "\\";
                updateFileManagerFunc();
            }
            catch (Exception e1)
            {
                MessageBox.Show("treeViewLeft_MouseDoubleClick:: " + e1.Message);
                return;
            }

            copyItem.destinationFilePath = comboBoxLeftLink.Text;
        }
        private void treeViewRight_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (!filePathRight[filePathRight.Length - 1].Equals('\\'))
                    filePathRight += "\\";
                filePathRight += treeViewRight.SelectedNode.Text + "\\";
                updateFileManagerFunc();
            }
            catch(Exception ex)
            {
                MessageBox.Show("treeViewRight_MouseDoubleClick:: " + ex.Message);
                return;
            }

            copyItem.destinationFilePath = comboBoxRightLink.Text;
        }
        // // // Undo button click // // //
        private void buttonLeftLeft_Click(object sender, EventArgs e)
        {
            filePathLeft = HelperClass.RemoveLastTag(filePathLeft);
            copyItem.destinationFilePath = filePathLeft;
            updateFileManagerFunc();
        }
        private void buttonRightLeft_Click(object sender, EventArgs e)
        {
            filePathRight = HelperClass.RemoveLastTag(filePathRight);
            copyItem.destinationFilePath = filePathRight;
            updateFileManagerFunc();
        }
        // // // Combo box// // //
        private void comboBoxUpdate()
        {
            if (filePathLeft != null)
            {
                comboBoxLeftLink.Text = filePathLeft;
                comboBoxLeftLink.Items.Add(filePathLeft);
            }
            if (filePathRight != null)
            {
                comboBoxRightLink.Text = filePathRight;
                comboBoxRightLink.Items.Add(filePathRight);
            }
        }
        private void comboBoxClick( string comboBoxText, string _comboBox)
        {
            string _left = filePathLeft, _right = filePathRight;
            try
            {
                if (_comboBox == "LEFT")
                {
                    filePathLeft = comboBoxText;
                    updateFileManagerFunc();

                }
                else if (_comboBox == "RIGHT")
                {
                    filePathRight = comboBoxText;
                    updateFileManagerFunc();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("comboBoxClick:: " + ex.Message);
                filePathLeft = _left;
                filePathRight= _right;
                comboBoxUpdate();
                return;
            }
        }
        private void comboBoxRightLink_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ((char)Keys.Enter))
            {
                comboBoxClick(comboBoxRightLink.Text, "RIGHT");
            }
        }
        private void comboBoxLeftLink_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ((char)Keys.Enter))
            {
                comboBoxClick(comboBoxLeftLink.Text, "LEFT");
            }
        }
        
        // // // Update my data // // //
        void Rebuild(string filePath)
        {
            //оновлюю дан≥ на екран≥, коли зм≥нюють зм≥ст папок через пров≥дничок
            if (filePathLeft != null)
            {
                UpdateFileManager updateFileManagerLeft = new(filePathLeft, this)
                {
                    _updateFileManager = updateFileManagerFunc
                };
            }
            if (filePathRight != null)
            {
                UpdateFileManager updateFileManagerRight = new(filePathRight, this)
                {
                    _updateFileManager = updateFileManagerFunc
                };
            }
        }
        // // // Open file // // //
        private void OpenSomething(string side)
        {
            try
            {
                var oldPath = copyItem.selectedItemFilePathes[0];
                OpenFile openFile;
                if (side == "LEFT")
                {
                    openFile = new OpenFile(listViewLeft.SelectedItems[0].Text, filePathLeft);
                }
                else //if (item == "FOLDER")
                {
                    openFile = new OpenFile(listViewRight.SelectedItems[0].Text, filePathRight);
                }
                openFile.Open();
            }
            catch (Exception ex1)
            {
                MessageBox.Show("OpenSomething():: " + ex1.Message);
            }
        }
        private void listViewLeft_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            OpenSomething("LEFT");
        }
        private void listViewRight_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenSomething("RIGHT");
        }
        // // // Copy something // // //
        CopyItem copyItem;
        private void copyAllItems(ListView listView, string filePath)
        {
            copyItem.copiedItemFilePathes = copyItem.selectedItemFilePathes;

        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copyItem.copiedItemFilePathes = copyItem.selectedItemFilePathes;
        }
        // // // Select something// // //
        private void selectAllItems(ListView listView, string filePath)
        {
            int i = 0;
            copyItem.selectedItemFilePathes = new List<string>();
            foreach (var item in listView.SelectedItems)
            {
                copyItem.selectedItemFilePathes.Add(filePath + listView.SelectedItems[i++].Text);
            }
        }
        private void treeViewLeft_MouseClick(object sender, EventArgs e)
        {

            if (treeViewLeft.SelectedNode != null)
            {
                copyItem.selectedItemFilePathes = new List<string>();
                copyItem.selectedItemFilePathes.Add(filePathLeft + treeViewLeft.SelectedNode.Text + "\\");
                copyItem.destinationFilePath = copyItem.selectedItemFilePathes[0];
            }
        }
        private void treeViewLeft_AfterSelect(object sender, TreeViewEventArgs e)
        {
            treeViewLeft_MouseClick(sender,e);
        }
        private void listViewLeft_Click(object sender, EventArgs e)
        {
            if (listViewLeft.SelectedItems[0] != null)
                selectAllItems(listViewLeft, filePathLeft);
        }
        private void treeViewRight_MouseClick(object sender, EventArgs e)
        {
            if (treeViewRight.SelectedNode != null)
            {
                copyItem.selectedItemFilePathes = new List<string>();
                copyItem.selectedItemFilePathes.Add(filePathRight + treeViewRight.SelectedNode.Text + "\\");
                copyItem.destinationFilePath = copyItem.selectedItemFilePathes[0];
            }
        }
        private void treeViewRight_AfterSelect(object sender, TreeViewEventArgs e)
        {
            treeViewRight_MouseClick(sender, e);
        }
        private void listViewRight_Click(object sender, EventArgs e)
        {
            if (listViewRight.SelectedItems[0] != null)
                selectAllItems(listViewRight, filePathRight);
        }
        // // // Paste click // // //
        private void pasteClick()
        {
            try
            {
                int i = 0;
                copyItem.fullFilePathes = new List<string>();
                copyItem.cashCopiedItemFilePathes = copyItem.copiedItemFilePathes;
                while (true)
                {
                    try
                    {
                        foreach (var copiedItemFilePath in copyItem.copiedItemFilePathes)
                        {
                            var desArr = copiedItemFilePath.Split('\\');
                            copyItem.fullFilePathes.Add(copyItem.destinationFilePath  + desArr[desArr.Length - 1]);
                            System.IO.File.Copy(copiedItemFilePath, copyItem.fullFilePathes[i++] );
                            if (copyItem.fullFilePathes.Count > i)
                                copyItem.fullFilePathes.RemoveAt(i);
                        }
                        copyItem.copiedItemFilePathes = copyItem.cashCopiedItemFilePathes;
                        if (isCutted)
                        {
                            isCutted = false;
                            removeClick(copyItem.copiedItemFilePathes);
                        }
                        return;
                    }
                    catch (Exception ex1)
                    {
                        var excMessArr = ex1.Message.Split(" ");
                        var exLastTwoWords = excMessArr[excMessArr.Length - 2] + " " + excMessArr[excMessArr.Length - 1];
                        if (exLastTwoWords == "already exists.")
                        {
                            copyItem.existingName(--i);
                            if (i != 0)
                            {
                                copyItem.copiedItemFilePathes.RemoveRange(0, i);
                                copyItem.fullFilePathes.RemoveRange(0, i);
                                i = 0;
                            }
                            //i = 0;
                            
                        }
                        else if (exLastTwoWords == "is denied." || exLastTwoWords == "a file." || excMessArr[0] == "Could") // друга умова - not a file
                            {
                            var pathArr = copyItem.copiedItemFilePathes[0].Split("\\");
                            var fullPath = copyItem.destinationFilePath + pathArr[pathArr.Length-2];
                            HelperClass.CopyDirectory(copyItem.copiedItemFilePathes[0], fullPath, true);
                            if (isCutted)
                            {
                                isCutted = false;
                                removeClick(copyItem.copiedItemFilePathes);
                            }
                            return;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("pasteClick()::" + ex.Message);
            }

        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pasteClick();
        }
        // // // Cut click // // //
        bool isCutted = false;
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copyToolStripMenuItem_Click(sender,e);
            isCutted = true;
        }
        // // // Remove click // // //
        private void removeClick(List<string> filePathes)
        {
            try
            {
                foreach (var filePath in filePathes)
                {
                    System.IO.File.Delete(filePath);
                }
            }
            catch(Exception ex)
            {
                try
                {
                    System.IO.Directory.Delete(filePathes[0], true);
                }
                catch(Exception ex1)
                {
                    MessageBox.Show("removeClick():: " + ex1.Message);
                }
            }
        }
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string selectedItems = string.Empty;
            foreach (var itemPath in copyItem.selectedItemFilePathes)
            {
                var itemPathElArr = itemPath.Split("\\");
                selectedItems += itemPathElArr[itemPathElArr.Length - 1] == string.Empty? itemPathElArr[itemPathElArr.Length - 2]: itemPathElArr[itemPathElArr.Length - 1] + '\n';
            }
            DialogResult dialogResult = MessageBox.Show("¬и впевнен≥, що хочете видалити вибран[ий\\i] об'Їкт[и]?:\n" + selectedItems, "¬идаленн€", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                removeClick(copyItem.selectedItemFilePathes);
            }
        }
        // // // Search file[s] click // // //
        private void searchTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

            /*if (e.KeyChar == ((char)Keys.Enter))
            {
                searchFunc(searchTextBox.Text);
            }*/
        }
        private void leftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelperClass.SearchFunc(listViewLeft, searchTextBox.Text);
            selectAllItems(listViewLeft, filePathLeft);
        }
        private void rightToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            HelperClass.SearchFunc(listViewRight, searchTextBox.Text);
            selectAllItems(listViewRight, filePathRight);
        }
        // // // Create new {Folder\File} click // /// //
        private void CreateSomething(string item)
        {
            try
            {
                if (copyItem.isFolder(copyItem.selectedItemFilePathes[0]))
                {
                    var newFilePath = copyItem.selectedItemFilePathes[0] + ((searchTextBox.Text != string.Empty) ? searchTextBox.Text : ((item == "FILE") ? "newFile.txt" : "newFolder\\"));
                    ICreateItem newItem;
                    if (item == "FILE")
                    {
                        newItem = CreateItem.CreateFile(newFilePath);
                    }
                    else //if (item == "FOLDER")
                    {
                        newItem = CreateItem.CreateFolder(newFilePath);
                    }
                    newItem.Create();

                }
                else
                {
                    MessageBox.Show("Select some folder, not file");
                    return;
                }
            }
            catch (Exception ex1)
            {
                MessageBox.Show("createToolStripMenuItem_Click" + ex1.Message);
            }
        }
        private void fileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateSomething("FILE");
        }
        private void folderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateSomething("FOLDER");
        }
        // // // Rename {Folder\File} click // // //
        private void RenameSomething(string item)
        {
            if (searchTextBox.Text == string.Empty)
            {
                MessageBox.Show("ўоб пере≥менувати об'Їкт, треба ввести нове ≥м'€ у тексбокс");
                return;
            }

            try
            {
                var oldPath = copyItem.selectedItemFilePathes[0];
                IRenameItem renamedItem;
                if (item == "FILE")
                {
                    renamedItem = RenameItem.RenameFile(oldPath, searchTextBox.Text);
                }
                else //if (item == "FOLDER")
                {
                    renamedItem = RenameItem.RenameFolder(oldPath, searchTextBox.Text);
                }
                renamedItem.Rename();
            }
            catch (Exception ex1)
            {
                MessageBox.Show("renameSomeItem():: " + ex1.Message);
            }
        }
        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var a = copyItem.selectedItemFilePathes[0].Split(".");
            if (a.Length > 1)
                RenameSomething("FILE");
            else if (a.Length == 1)
                RenameSomething("FOLDER");
        }
    }
}