using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FileManager_1._0
{
    public partial class FileManagerForm : Form
    {
        // // // Initialization part // // //
        private const string discCfilePath = "discCdataBase.xml";
        private const string discDfilePath = "discDdataBase.xml";
        Tuple<TreeNode, Folder> TreeViewInitRecFunction(XmlTextReader xmlReader, TreeNode myNode, Folder myFolder)
        {
            // Аналіз мого документа за допомогую SAX (бо мені не треба нічого знаходити,
            // просто послідовно записувати). Заповнюю я одразу дві речі: мій TreeNode,
            // щоб у подальшому без проблем заповнити мої TreeView-шечкі; та мою ієрархію
            // класів myFolder, бо мені потрібно зберегти кудись усю структуру, щоб у
            // подальшому спокійно робити щось із структурними одиницями (копіювати/вирізати).
            while (xmlReader.Read())
            {
                switch (xmlReader.NodeType)
                {
                    case XmlNodeType.XmlDeclaration:
                        break;
                    case XmlNodeType.Element:
                        if (xmlReader.Name == "folder")
                        {
                            string _name = xmlReader.GetAttribute(0);
                            Folder myChildFolder = new Folder(_name);

                            if (myNode == null)
                            {
                                myNode = new TreeNode(_name);
                                myFolder = new Folder(_name);
                                myNode.Tag = myFolder;
                                TreeViewInitRecFunction(xmlReader, myNode, myFolder);
                            }
                            else
                            {
                                myNode.Nodes.Add(_name);
                                myFolder.Add(myChildFolder);
                                myNode.LastNode.Tag = myChildFolder;
                            }

                            TreeViewInitRecFunction(xmlReader, myNode.LastNode, myChildFolder);
                        }
                        else if (xmlReader.Name == "document")
                        {
                            myFolder.Add(new File(xmlReader.GetAttribute(0)));
                        }
                        break;
                    case XmlNodeType.EndElement:
                        if (xmlReader.Name == "folder")
                        {

                            return Tuple.Create(myNode, myFolder);
                        }
                        break;
                    case XmlNodeType.Comment:
                        break;
                    case XmlNodeType.Text:
                        break;
                }
            }
            return Tuple.Create(myNode, myFolder); // повертаю одразу два параметри
        }
        void TreeViewInitialization(string filePath, System.Windows.Forms.TreeView treeView)
        {
            //Для перевірки на відкритість\закритість папок
            List<Tuple<bool, string>> openFolder;
            if (treeView.Nodes.Count != 0)
                openFolder = HelperClass.OpenFolderCheck(treeView.Nodes);
            else
                openFolder = new List<Tuple<bool, string>>();
            //

            treeView.Nodes.Clear();
            if (System.IO.File.Exists(filePath))
            {
                var xmlReader = new XmlTextReader(filePath);
                treeView.ImageList = treeViewImageList;
                var tupleForTree = TreeViewInitRecFunction(xmlReader, null, null);
                treeView.Nodes.Add(tupleForTree.Item1);

                //myFolder = tupleForTree.Item2;
                xmlReader.Close();
            }

            //Для перевірки на відкритість\закритість папок
            if (openFolder.Count != 0)
                HelperClass.OpenOrCloseFolder(openFolder, 0, treeView.Nodes);
            //
        }
        // // // 
        public FileManagerForm()
        {
            InitializeComponent();
            TreeViewInitialization(discCfilePath, treeViewLeft);
            TreeViewInitialization(discDfilePath, treeViewRight);

        }

        // // // ListView Filling (after selecting some TreeView item) // // //
        private void listViewFilling(System.Windows.Forms.ListView listView, System.Windows.Forms.TreeView treeView, string filePath)
        {
            // За допомогою DOM та xPath відбираю усі ноди (тобо текстові файли),
            // що лежать у тій самій папці, на яку тикнули (текстові файли дочірніх
            // до нашого класів не виводяться, щоб це змінити, треба поставити у
            // xpath перед document ще один слешик)

            listView.Items.Clear();
            XmlDocument xml = new XmlDocument();
            xml.Load(filePath);
            var myNode = treeView.SelectedNode;
            string xpath = HelperClass.xPathFinding(myNode, "/document");
            if (xpath == null)
            {
                MessageBox.Show("ERROR_2:listViewFillingFunction");
                return;
            }
            var files = xml.SelectNodes(xpath);

            Folder myNodeClass = (Folder)myNode.Tag;
            var fileAndFolderList = myNodeClass.Get();
            List<File> fileList = new List<File>();
            foreach (var _item in fileAndFolderList)//утворюємо лист тільки із файлів
            {
                if (_item is File)
                {
                    fileList.Add((File)_item);
                }
            }

            int i = 0;
            foreach (XmlNode file in files)
            {
                if (i>fileList.Count-1)
                {
                    MessageBox.Show("ERROR:OutOfRange (listViewFilling-function)");
                    return;
                }
                listView.Items.Add(file.Attributes.GetNamedItem("DOCUMENT").Value);
                listView.Items[i].Tag = fileList[i++];
            }
        }
        
        // // // Setting images on TreeView items// // //
        private bool errorCheck(TreeNode _node, string _message)
        {
            if (_node == null)
            {
                MessageBox.Show(_message);
                return false;
            }
            return true;
        }
        private void openFolder(TreeNode _node)
        {
            _node.ImageIndex = 1;
            _node.SelectedImageIndex = 1;
        }
        private void closeFolder(TreeNode _node)
        {
            _node.ImageIndex = 0;
            _node.SelectedImageIndex = 0;
        }
        private void treeViewLeft_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (errorCheck(e.Node, "ERROR3:treeViewLeft_BeforeExpandFunction"))
                openFolder(e.Node);
        }
        private void treeViewLeft_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            if (errorCheck(e.Node, "ERROR4:treeViewLeft_BeforeCollapseFunction"))
                closeFolder(e.Node);

        }
        private void treeViewRight_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (errorCheck(e.Node, "ERROR3.1:treeViewRight_BeforeExpandFunction"))
                openFolder(e.Node);
        }
        private void treeViewRight_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            if (errorCheck(e.Node, "ERROR4.1:treeViewRight_BeforeCollapseFunction"))
                closeFolder(e.Node);
        }

        // // // ComboBox functions // // //
        private void FindAndSelectListViewNode(string link,System.Windows.Forms.TreeView treeView, System.Windows.Forms.ListView listView)
        {
            var myNodes = link.Split('\\');
            HelperClass.FindAndOpenTreeViewNode(treeView.Nodes, myNodes, 0, treeView);
            HelperClass.SelectListViewItem(myNodes[myNodes.Length - 1], listView);
        }
        private void comboBoxClick(KeyPressEventArgs e, string comboBoxText, string _comboBox)
        {
            if (e.KeyChar == ((char)Keys.Enter))
            {
                if (_comboBox == "LEFT")
                {
                    FindAndSelectListViewNode(comboBoxText,treeViewLeft,listViewLeft);
                    comboBoxLeftLink.Items.Add(comboBoxText);

                }
                else if (_comboBox == "RIGHT")
                {
                    FindAndSelectListViewNode(comboBoxText, treeViewRight, listViewRight);
                    comboBoxRightLink.Items.Add(comboBoxText);
                }
                else
                    MessageBox.Show("ERROR5:comboBoxClick-function");
            }
        }
        private void comboBoxLeftLink_KeyPress(object sender, KeyPressEventArgs e)
        {
            comboBoxClick(e, comboBoxLeftLink.Text, "LEFT");
        }
        private void comboBoxRightLink_KeyPress(object sender, KeyPressEventArgs e)
        {
            comboBoxClick(e, comboBoxRightLink.Text,"RIGHT");
        }
        // // // SELECT: select some component (treeVewLeft folder or listView right file or ...)// // //
        private Tuple<Component, string> selectedItem; // <{Folder,File}, {LEFT/RIGHT}>
        private string newFolderNodePath;
        private void selectedItemSelect(Tuple<Component, string> selectedItem)
        {
            if (selectedItem != null)
                this.selectedItem = selectedItem;
        }
        private void treeViewLeft_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (System.IO.File.Exists(discCfilePath))
            {
                listViewFilling(listViewLeft,treeViewLeft, discCfilePath);
            }
            selectedItemSelect(Tuple.Create((Component)e.Node.Tag, "LEFT"));
            newFolderNodePath = treeViewLeft.SelectedNode.FullPath;
        }
        private void treeViewLeft_Click(object sender, EventArgs e)
        {
            selectedItemSelect(treeViewLeft.SelectedNode != null? Tuple.Create((Component)treeViewLeft.SelectedNode.Tag, "LEFT"):null);
            newFolderNodePath = treeViewLeft.SelectedNode != null ? treeViewLeft.SelectedNode.FullPath : string.Empty;
        }
        private void treeViewRight_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (System.IO.File.Exists(discDfilePath))
            {
                listViewFilling(listViewRight,treeViewRight,discDfilePath);
            }
            selectedItemSelect(Tuple.Create((Component)e.Node.Tag, "RIGHT"));
            newFolderNodePath = treeViewRight.SelectedNode.FullPath;
        }
        private void treeViewRight_Click(object sender, EventArgs e)
        {
            selectedItemSelect(treeViewRight.SelectedNode != null? Tuple.Create((Component)treeViewRight.SelectedNode.Tag, "RIGHT"):null);
            newFolderNodePath = treeViewRight.SelectedNode != null ? treeViewRight.SelectedNode.FullPath : string.Empty;
        }
        private void listViewLeft_MouseClick(object sender, MouseEventArgs e)
        {
            if (listViewLeft.SelectedItems.Count > 0)
                selectedItemSelect(Tuple.Create((Component)listViewLeft.SelectedItems[0].Tag, "LEFT"));
        }
        private void listViewLeft_Enter(object sender, EventArgs e)
        {
            if (listViewLeft.SelectedItems.Count > 0) 
            {
                selectedItemSelect(Tuple.Create((Component)listViewLeft.SelectedItems[0].Tag, "LEFT"));
            }            
        }
        private void listViewRight_MouseClick(object sender, MouseEventArgs e)
        {
            if (listViewRight.SelectedItems.Count >0)
                selectedItemSelect(Tuple.Create((Component)listViewRight.SelectedItems[0].Tag, "RIGHT"));
        }
        private void listViewRight_Enter(object sender, EventArgs e)
        {
            if (listViewRight.SelectedItems.Count > 0)
                selectedItemSelect(Tuple.Create((Component)listViewRight.SelectedItems[0].Tag, "RIGHT"));
        }
        
        // // // COPY: check, weather copy was correct // // //
        private Component copiedItem;
        private string oldFolderNodePath;
        private void copyClick()
        {
            if (selectedItem == null || selectedItem.Item1 == null)
            {
                MessageBox.Show("Select something");
                return;
            }
            
            copiedItem = selectedItem.Item1;
            oldFolderNodePath = newFolderNodePath;

        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copyClick();
        }
        // // // CUT: // // //
        private bool isCutted = false;
        private Tuple<List<Component>, string> removedItem;
        private void cutClick()
        {
            isCutted = true;
            copyClick();
            removedItem = Tuple.Create( new List<Component>() { selectedItem.Item1 }, selectedItem.Item2);
        }
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cutClick();
        }

        // // // PASTE:  // // //
        private List<Tuple<string, string>> FindAllFilesReferences(Folder copiedFolder, string folderName)
        {
            List<Tuple<string, string>> filePathList = new List<Tuple<string, string>>();// <[source of the coppied file],[destination of the coppied file]>
            foreach (Component _comp in copiedFolder.Get())
            {
                if (_comp is Folder)
                    filePathList.AddRange(FindAllFilesReferences((Folder)_comp, folderName + _comp.Name + "_"));
                else
                    filePathList.Add(Tuple.Create("Files\\" + HelperClass.NewFileName(oldFolderNodePath) + "_" + folderName + _comp.Name, "Files\\" + HelperClass.NewFileName(newFolderNodePath) + "_" + copiedItem.Name + "_" + folderName + _comp.Name));
            }
            return filePathList;
        }
        private List<Component> FindAllFiles(Folder folder)
        {
            List<Component> files = new List<Component>();
            foreach (Component _comp in folder.Get())
            {
                if (_comp is Folder)
                    files.AddRange(FindAllFiles((Folder)_comp));
                else
                    files.Add((File)_comp);
            }
            return files;
        }
        private void pasteClick()
        {
            if (selectedItem.Item1 is File)
            {
                MessageBox.Show("Click on the folder where you want to transfer the file");
                return;
            }

            System.Windows.Forms.TreeView treeView = selectedItem.Item2 == "LEFT" ? treeViewLeft : treeViewRight;
            var discFilePath = selectedItem.Item2 == "LEFT" ? discCfilePath : discDfilePath;
            var listView = selectedItem.Item2 == "LEFT" ? listViewLeft : listViewRight;
            string oldName = copiedItem.Name;


            if (treeView.SelectedNode == null)
            {
                MessageBox.Show("Please, select folder with the desired file again");
                return;
            }
            copiedItem.Name = HelperClass.TheSameNameCheck((Folder)treeView.SelectedNode.Tag, copiedItem.Name, copiedItem);
            string newName = copiedItem.Name;
            // updating xml
            string xpath = HelperClass.xPathFinding(treeView.SelectedNode, "");
            if (xpath == null)
            {
                MessageBox.Show("ERROR7:updateDoc-function");
                return;
            }
            XmlHelper.updateDoc(xpath, discFilePath,copiedItem);
            //
            TreeViewInitialization(discFilePath, treeView);
            if (copiedItem is File)
            {
                listView.Items.Add(copiedItem.Name);
                System.IO.File.Copy("Files\\" + HelperClass.NewFileName(oldFolderNodePath) + "_" + oldName, "Files\\" + HelperClass.NewFileName(newFolderNodePath) + "_" + newName);
                if (isCutted)
                {
                    isCutted = false;
                    var oldDiscFilePath = removedItem.Item2 == "LEFT" ? discCfilePath : discDfilePath;
                    var oldTreeView = removedItem.Item2 == "LEFT" ? treeViewLeft : treeViewRight;
                    var oldListView = removedItem.Item2 == "LEFT" ? listViewLeft : listViewRight;
                    RemoveItem(removedItem.Item1[0], oldTreeView, oldListView, oldDiscFilePath);
                }
            }
            else if (copiedItem is Folder)
            {
                List<Tuple<string, string>> filePathList;

                filePathList = FindAllFilesReferences((Folder)copiedItem, string.Empty);
                foreach (var _item in filePathList)
                {
                    System.IO.File.Copy(_item.Item1, _item.Item2);
                }

                if (isCutted)
                {
                    isCutted = false;
                    var oldDiscFilePath = removedItem.Item2 == "LEFT" ? discCfilePath : discDfilePath;
                    var oldTreeView = removedItem.Item2 == "LEFT" ? treeViewLeft : treeViewRight;
                    var oldListView = removedItem.Item2 == "LEFT" ? listViewLeft : listViewRight;
                    int i = 0;
                    //foreach (var _item in filePathList)
                    {
                        RemoveItem(removedItem.Item1[i++], oldTreeView, oldListView, oldDiscFilePath);
                    }
                }
            }
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pasteClick();    
        }
        // // // REMOVE: // // //
        private void RemoveItem(Component removedItem, System.Windows.Forms.TreeView treeView, System.Windows.Forms.ListView listView, string filePath)
        {
            if (removedItem is Folder)
            {
                HelperClass.RemoveFolderTxtFiles((Folder)removedItem, treeView.SelectedNode.FullPath); 
                var xPath = HelperClass.xPathFinding(treeView.SelectedNode, "");
                XmlHelper.RemoveFromXML(xPath, filePath);
                TreeViewInitialization(filePath, treeView);
                listView.Items.Clear();
            }
            else if (removedItem is File)
            {
                HelperClass.RemoveTxtFile(treeView.SelectedNode.FullPath, listView.SelectedItems[0].Text);
                var xPath = HelperClass.xPathFinding(treeView.SelectedNode, "/document[@DOCUMENT = '" + listView.SelectedItems[0].Text + "']");
                XmlHelper.RemoveFromXML(xPath, filePath);
                listView.SelectedItems[0].Remove();
            }
        }
        private void removeClick()
        {
            Component removedItem;
            if (selectedItem == null || selectedItem.Item1 == null)
            {
                MessageBox.Show("Select something");
                return;
            }
            removedItem = selectedItem.Item1;
            if (selectedItem.Item2 == "LEFT")
            {
                RemoveItem(removedItem, treeViewLeft, listViewLeft, discCfilePath);
            }
            else if (selectedItem.Item2 == "RIGHT")
            {
                RemoveItem(removedItem, treeViewRight, listViewRight, discDfilePath);
            }
        }
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removeClick();
        }
        // // // TextEditor-Part // // //
        private void listViewDoubleClick(System.Windows.Forms.ListView listView, System.Windows.Forms.TreeView treeView)
        {
            if (treeView.SelectedNode == null)
            {
                MessageBox.Show("Please, select folder with the desired file again");
                return;
            }
            HelperClass.OpenFileEditor(treeView.SelectedNode.FullPath, listView.SelectedItems[0].Text);
        }
        private void listViewLeft_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            listViewDoubleClick(listViewLeft, treeViewLeft);
        }
        private void listViewRight_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listViewDoubleClick(listViewRight, treeViewRight);
        }
        // // // Initializing my disks // // //
        private void InitializeAllFiles()
        {
            foreach (var file in System.IO.Directory.GetFiles("Files"))
            {
                System.IO.File.Delete(file);
            }
            System.IO.Directory.Delete("Files");
            System.IO.Directory.CreateDirectory("Files");
            HelperClass.FindAllTreeNodesAndCreateCorrespondingFiles(treeViewLeft.Nodes);
            HelperClass.FindAllTreeNodesAndCreateCorrespondingFiles(treeViewRight.Nodes);
        }
        private void initializeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitializeAllFiles();
        }
    }
}