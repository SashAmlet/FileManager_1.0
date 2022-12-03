using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.LinkLabel;

namespace FileManager_1._0
{
    public partial class FileManagerForm : Form
    {
        // // // Initialization part // // //
        private const string discCfilePath = "discCdataBase.xml";
        private const string discDfilePath = "discDdataBase.xml";
        private Folder myFolder; 
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
        private int openOrcloseFolder(List<Tuple<bool, string>> openFolder, int i, TreeNodeCollection Nodes)
        {
            foreach (TreeNode _node in Nodes)
            {
                if (openFolder.Count - 1 < i)
                    return 0;
                if (openFolder[i].Item2 == _node.Text)
                {
                    if (openFolder[i].Item1)
                        _node.Expand();
                    else
                        _node.Collapse();
                    i = openOrcloseFolder(openFolder, ++i, _node.Nodes);
                }
            }
            return i;
        }
        void TreeViewInitialization(string filePath, TreeView treeView)
        {
            //Для перевірки на відкритість\закритість папок
            List<Tuple<bool, string>> openFolder;
            if (treeView.Nodes.Count != 0)
                openFolder = openFolderCheck(treeView.Nodes);
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

                myFolder = tupleForTree.Item2;

                xmlReader.Close();
            }

            //Для перевірки на відкритість\закритість папок
            if (openFolder.Count != 0)
                openOrcloseFolder(openFolder, 0, treeView.Nodes);
        }
        // // // 
        public FileManagerForm()
        {
            InitializeComponent();
            TreeViewInitialization(discCfilePath, treeViewLeft);
            TreeViewInitialization(discDfilePath, treeViewRight);

        }
        // // // ListView Filling (after selecting some TreeView item) // // //
        private string xPathFinding(TreeNode myNode, string concreteItem)
        {
            // Динамічно формую xPath, через проблему повторюванних імен
            if (myNode == null)
            {
                MessageBox.Show("ERROR_1:xPathFindingFunction");
                return null;
            }
            string xPath = "/folder[@FOLDER = '" + myNode.Text + "']" + concreteItem;
            while (myNode.Parent != null)
            {
                xPath = xPath.Insert(0, "/folder[@FOLDER = '" + myNode.Parent.Text + "']");
                myNode = myNode.Parent;
            }
            xPath = xPath.Insert(0, "/dataBase");
            return xPath;
        }
        private void listViewFilling(ListView listView, TreeView treeView, string filePath)
        {
            // За допомогою DOM та xPath відбираю усі ноди (тобо текстові файли),
            // що лежать у тій самій папці, на яку тикнули (текстові файли дочірніх
            // до нашого класів не виводяться, щоб це змінити, треба поставити у
            // xpath перед document ще один слешик)

            listView.Items.Clear();
            XmlDocument xml = new XmlDocument();
            xml.Load(filePath);
            var myNode = treeView.SelectedNode;
            string xpath = xPathFinding(myNode, "/document");
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
        
        // // // Some HELPER functions // // //
        private XmlElement CreateXmlElement(XmlDocument xml, string itemType, string itemAttrType, string itemAttrText)
        {
            XmlElement newItem = xml.CreateElement(itemType);
            try
            {
                XmlAttribute itemAttr = xml.CreateAttribute(itemAttrType);
                XmlText nameText = xml.CreateTextNode(itemAttrText);
                itemAttr.AppendChild(nameText);
                newItem.Attributes.Append(itemAttr);
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR6:CreateXmlElement-function");
            }
            return newItem;
        }
        private Tuple<XmlDocument, XmlElement> updateDocRecFunc(XmlDocument xDoc, XmlElement myElem, Folder copiedItem)
        {
            foreach (Component comp in copiedItem.Get())
            {
                if (comp is Folder)
                {
                    var newFolder = CreateXmlElement(xDoc, "folder", "FOLDER", comp.Name);
                    newFolder.InnerText = "";
                    myElem.AppendChild(updateDocRecFunc(xDoc, newFolder, (Folder)comp).Item2);
                }
                else if(comp is File)
                {
                    var newFile = CreateXmlElement(xDoc, "document", "DOCUMENT", comp.Name);
                    newFile.InnerText = "";
                    myElem.AppendChild(newFile);
                }
            }

            return Tuple.Create(xDoc, myElem);
        }
        private void updateDoc(TreeNode newHomeTreeNode, string filePath)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(filePath);

            string xpath = xPathFinding(newHomeTreeNode, "");
            if (xpath == null)
            {
                MessageBox.Show("ERROR7:updateDoc-function");
                return;
            }
            var newHomeNode = xDoc.SelectSingleNode(xpath);
            if (copiedItem is Folder)
            {
                var newFolder = CreateXmlElement(xDoc, "folder", "FOLDER", copiedItem.Name);
                var res = updateDocRecFunc(xDoc, newFolder, (Folder)copiedItem);
                newHomeNode.AppendChild(res.Item2);
            }
            else if (copiedItem is File)
            {
                var newFile = CreateXmlElement(xDoc, "document", "DOCUMENT", copiedItem.Name);
                newHomeNode.AppendChild(newFile);

            }
            xDoc.Save(filePath);
        }
        private List<Tuple<bool, string>> openFolderCheck(TreeNodeCollection Nodes)
        {
            List<Tuple<bool, string>> openFolder = new List<Tuple<bool, string>>();
            
            foreach (TreeNode _node in Nodes)
            {
                if (_node.IsExpanded)
                {
                    openFolder.Add(Tuple.Create(true,_node.Text));
                }
                else
                {
                    openFolder.Add(Tuple.Create(false, _node.Text));
                }
                openFolder.AddRange(openFolderCheck(_node.Nodes));
            }
            return openFolder;
        }
        private void theSameNameCheck(TreeNode myNewHome, ListView listView)
        {
            if (copiedItem is Folder)
            {
                foreach (TreeNode _node in myNewHome.Nodes)
                {
                    if (_node.Text == copiedItem.Name)
                    {
                        copiedItem.Name += "-copied";
                        theSameNameCheck(myNewHome, listView);
                        break;
                    }
                }
            }
            else if (copiedItem is File)
            {
                foreach(ListViewItem _item in listView.Items)
                {
                    if (_item.Text== copiedItem.Name)
                    {
                        var splitedName = copiedItem.Name.Split('.');
                        splitedName[0] = splitedName[0] + "-copied";
                        copiedItem.Name = splitedName[0] + "." + splitedName[1];
                        theSameNameCheck(myNewHome, listView);
                        break;
                    }
                }
            }
        }

        // // // ComboBox functions // // //
        TreeView comboTreeView;
        ListView comboListView;
        private void findTreeViewNode(TreeNodeCollection Nodes, string[] myNodes, int i)
        {
            foreach (TreeNode _node in Nodes)
            {
                if (i > myNodes.Length-1)
                    return;
                if (_node.Text == myNodes[i])
                {
                    _node.Expand();
                    comboTreeView.SelectedNode = _node;
                    findTreeViewNode(_node.Nodes, myNodes, ++i);
                }
            }
        }
        private void selectListViewItem(string myNodeName)
        {
            int p = -1;
            foreach (ListViewItem _item in comboListView.Items)
            {
                if (_item.Text == myNodeName)
                    p = _item.Index;
            }
            if (p > -1)
            {
                comboListView.Items[p].Focused = true;
                comboListView.Items[p].Selected = true;
                comboListView.Items[p].EnsureVisible();
                comboListView.Select();
            }

        }
        private void findNode(string link)
        {
            var myNodes = link.Split('\\');
            findTreeViewNode(comboTreeView.Nodes, myNodes, 0);
            selectListViewItem(myNodes[myNodes.Length - 1]);
        }
        private void comboBoxClick(KeyPressEventArgs e, string comboBoxText, string _comboBox)
        {
            if (e.KeyChar == ((char)Keys.Enter))
            {
                if (_comboBox == "LEFT")
                {
                    comboTreeView = treeViewLeft;
                    comboListView = listViewLeft;
                    findNode(comboBoxText);
                    comboBoxLeftLink.Items.Add(comboBoxText);

                }
                else if (_comboBox == "RIGHT")
                {
                    comboTreeView = treeViewRight;
                    comboListView = listViewRight;
                    findNode(comboBoxText);
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
            //else
                //MessageBox.Show("ERROR7: selectedItemSelect-function");
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
        Component copiedItem;
        string oldFolderNodePath;
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
        private void cutClick()
        {
            copyClick();
            removeClick();
        }
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cutClick();
        }

        // // // PASTE:  // // //
        private void pasteClick()
        {
            if (selectedItem.Item1 is File)
            {
                MessageBox.Show("Click on the folder where you want to transfer the file");
                return;
            }

            TreeView treeView = selectedItem.Item2 == "LEFT" ? treeViewLeft : treeViewRight;
            var discFilePath = selectedItem.Item2 == "LEFT" ? discCfilePath : discDfilePath;
            var listView = selectedItem.Item2 == "LEFT" ? listViewLeft : listViewRight;
            Folder newHome = (Folder)selectedItem.Item1;
            string oldName = copiedItem.Name;
            theSameNameCheck(treeView.SelectedNode, listView);
            string newName = copiedItem.Name;
            newHome.Add(copiedItem);
            updateDoc(treeView.SelectedNode, discFilePath);
            TreeViewInitialization(discFilePath, treeView);
            if (copiedItem is File)
            {
                listView.Items.Add(copiedItem.Name);
                //System.IO.File.Create("Files\\" + nameFormFunc(newFolderNodePath) + "_" + newName).Close();
                System.IO.File.Copy("Files\\" + nameFormFunc(oldFolderNodePath) + "_" + oldName, "Files\\" + nameFormFunc(newFolderNodePath) + "_" + newName);
            }
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pasteClick();    
        }
        // // // REMOVE: // // //
        private void removeSomeItem(string itemType, TreeView treeView, string filePath)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(filePath);
            var xPath = xPathFinding(treeView.SelectedNode, itemType);
            var myNode = xml.SelectSingleNode(xPath);
            myNode.ParentNode.RemoveChild(myNode);
            xml.Save(filePath);
        }
        private void fileOrFolderRemove(Component removedItem, TreeView treeView, ListView listView, string filePath)
        {
            if (removedItem is Folder)
            {
                removeSomeItem("", treeView, filePath);
                TreeViewInitialization(filePath, treeView);
                listView.Items.Clear();
            }
            else if (removedItem is File)
            {
                var a = "Files\\" + nameFormFunc(treeView.SelectedNode.FullPath) + "_" + listView.SelectedItems[0].Text;
                System.IO.File.Delete(a);
                removeSomeItem("/document[@DOCUMENT = '" + listView.SelectedItems[0].Text + "']", treeView, filePath);
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
                fileOrFolderRemove(removedItem, treeViewLeft, listViewLeft, discCfilePath);
            }
            else if (selectedItem.Item2 == "RIGHT")
            {
                fileOrFolderRemove(removedItem, treeViewRight, listViewRight, discDfilePath);
            }
        }
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removeClick();
        }
        // // // TextEditor-Part // // //
        private string nameFormFunc(string _filePath)
        {
            string[] _splitedFilePath = _filePath.Split('\\');
            string newName = string.Empty;
            foreach(string item in _splitedFilePath)
            {
                newName += "_" + item.TrimEnd(':');
            }
            return newName.TrimStart('_');
        }
        private void listViewDoubleClick(ListView listView, TreeView treeView)
        {
            if (treeView.SelectedNode == null)
            {
                MessageBox.Show("Please, select folder with the desired file again");
                return;
            }
            string textFilePath = "Files\\" + nameFormFunc(treeView.SelectedNode.FullPath) + "_" + listView.SelectedItems[0].Text;
            if (System.IO.File.Exists(textFilePath))
                System.Diagnostics.Process.Start("TextEditor_1.0\\TextEditor_1.0\\bin\\Debug\\net6.0-windows\\TextEditor_1.0.exe", textFilePath);
            else
            {
                System.IO.File.Create(textFilePath).Close();
                System.Diagnostics.Process.Start("TextEditor_1.0\\TextEditor_1.0\\bin\\Debug\\net6.0-windows\\TextEditor_1.0.exe", textFilePath);
            }
            

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

        private void findAllTreeNodes(TreeNodeCollection Nodes)
        {
            foreach (TreeNode _node in Nodes)
            {
                Folder nodeTag = (Folder)_node.Tag;
                var tagList = nodeTag.Get();
                List<File> fileList = new List<File>();
                foreach (var _tag in tagList)
                {
                    if (_tag is File)
                    {
                        fileList.Add((File)_tag);
                    }
                }
                if (fileList.Count > 0)
                {
                    foreach (File _file in fileList)
                    {
                        System.IO.File.Create("Files\\" + nameFormFunc(_node.FullPath) +"_" +_file.Name).Close();
                    }
                }
                findAllTreeNodes(_node.Nodes);
            }
        }
        private void initializeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(var file in System.IO.Directory.GetFiles("Files"))
            {
                System.IO.File.Delete(file);
            }
            System.IO.Directory.Delete("Files");
            System.IO.Directory.CreateDirectory("Files");
            findAllTreeNodes(treeViewLeft.Nodes);
            findAllTreeNodes(treeViewRight.Nodes);
        }
    }
}