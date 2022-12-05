using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_1._0
{
    internal static class HelperClass
    {
        public static string TheSameNameCheck(Folder myNewHome, string copiedItemName, Component copiedItemType)
        {
            // Вирішую проблему повторюванних імен
            if (copiedItemType is Folder)
            {
                foreach (Component _node in myNewHome.Get())
                {
                    if (_node.Name == copiedItemName)
                    {
                        copiedItemName += "-copied";
                        copiedItemName = TheSameNameCheck(myNewHome, copiedItemName, copiedItemType);
                    }
                }
            }
            else if (copiedItemType is File)
            {
                foreach (Component _item in myNewHome.Get())
                {
                    if (_item.Name == copiedItemName)
                    {
                        var splitedName = copiedItemName.Split('.');
                        splitedName[0] = splitedName[0] + "-copied";
                        copiedItemName = splitedName[0] + "." + splitedName[1];
                        copiedItemName = TheSameNameCheck(myNewHome, copiedItemName, copiedItemType);
                    }
                }
            }
            return copiedItemName;
        }
        public static string xPathFinding(TreeNode myNode, string concreteItem)
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
        public static string NewFileName(string _filePath)
        {
            // Формую ім'я до файлів, які зберігаю у провідничок
            string[] _splitedFilePath = _filePath.Split('\\');
            string newName = string.Empty;
            foreach (string item in _splitedFilePath)
            {
                newName += "_" + item.TrimEnd(':');
            }
            return newName.TrimStart('_');
        }
        public static List<Tuple<bool, string>> OpenFolderCheck(TreeNodeCollection Nodes)
        {
            //Перевіряю, які ноди з Nodes відкриті, і формую відповідний список <відкритий? true:false, ім'я нода>
            List<Tuple<bool, string>> openFolder = new List<Tuple<bool, string>>();

            foreach (TreeNode _node in Nodes)
            {
                if (_node.IsExpanded)
                {
                    openFolder.Add(Tuple.Create(true, _node.Text));
                }
                else
                {
                    openFolder.Add(Tuple.Create(false, _node.Text));
                }
                openFolder.AddRange(OpenFolderCheck(_node.Nodes));
            }
            return openFolder;
        }
        public static int OpenOrCloseFolder(List<Tuple<bool, string>> openFolder, int folderIndex, TreeNodeCollection Nodes)
        {
            //Отримую інформацію з попередньої функції, та відкриваю/закриваю відповідні TreeViewNode-и
            foreach (TreeNode _node in Nodes)
            {
                if (openFolder.Count - 1 < folderIndex)
                    return 0;
                if (openFolder[folderIndex].Item2 == _node.Text)
                {
                    if (openFolder[folderIndex].Item1)
                        _node.Expand();
                    else
                        _node.Collapse();
                    folderIndex = OpenOrCloseFolder(openFolder, ++folderIndex, _node.Nodes);
                }
            }
            return folderIndex;
        }
        public static void FindAndOpenTreeViewNode(TreeNodeCollection Nodes, string[] folderSequence, int currentFolderIndex, System.Windows.Forms.TreeView treeView)
        {
            // Відкриваю та тицяю у папку за даною послідовністю її батьків folderSequence
            foreach (TreeNode _node in Nodes)
            {
                if (currentFolderIndex > folderSequence.Length - 1)
                    return;
                if (_node.Text == folderSequence[currentFolderIndex])
                {
                    _node.Expand();
                    treeView.SelectedNode = _node;
                    FindAndOpenTreeViewNode(_node.Nodes, folderSequence, ++currentFolderIndex, treeView);
                }
            }
        }
        public static void SelectListViewItem(string myNodeName, System.Windows.Forms.ListView listView)
        {
            // Вибираю елемент з іменем myNodeName у listView (якщо такий є)
            int p = -1;
            foreach (ListViewItem _item in listView.Items)
            {
                if (_item.Text == myNodeName)
                    p = _item.Index;
            }
            if (p > -1)
            {
                listView.Items[p].Focused = true;
                listView.Items[p].Selected = true;
                listView.Items[p].EnsureVisible();
                listView.Select();
            }

        }
        public static void RemoveFolderTxtFiles(Component removedItem, string treeViewNodeFilePath)
        {
            // видаляє .тхт файли, які є у папці, що ми видалили у програмі
            foreach (var item in ((Folder)removedItem).Get())
            {
                if (item is File)
                {
                    HelperClass.RemoveTxtFile(treeViewNodeFilePath, item.Name);
                }
                else if (item is Folder)
                {
                    RemoveFolderTxtFiles(item, treeViewNodeFilePath + "\\" + item.Name);
                }
            }
        }
        private static string TxtFileReference(string treeViewNodeFilePath, string listViewFileName)
        {
            return "Files\\" + HelperClass.NewFileName(treeViewNodeFilePath) + "_" + listViewFileName;
        }
        public static void RemoveTxtFile(string treeViewNodeFilePath, string listViewFileName)
        {
            // видаляє .тхт файл з listViewFileName ім'ям у самому менеджері,
            // та з treeViewNodeFilePath посиланням на папку, в якій він знаходиться у менеджері
            var a = TxtFileReference(treeViewNodeFilePath, listViewFileName);
            System.IO.File.Delete(a);
        }
        public static void OpenFileEditor(string treeViewNodeFilePath, string listViewFileName)
        {
            // Програмно запускає мій едітор (ехе-шник якого знаходиться за textEditorExePath),
            // та закидує туди шлях до файла, який йому потрібно відкрити

            string textFilePath = TxtFileReference(treeViewNodeFilePath, listViewFileName);//"Files\\" + HelperClass.NewFileName(treeViewNodeFilePath) + "_" + listViewFileName;
            const string textEditorExePath = "TextEditor_1.0\\TextEditor_1.0\\bin\\Debug\\net6.0-windows\\TextEditor_1.0.exe";

            if (System.IO.File.Exists(textFilePath))
                System.Diagnostics.Process.Start(textEditorExePath, textFilePath);
            else
            {
                System.IO.File.Create(textFilePath).Close();
                System.Diagnostics.Process.Start(textEditorExePath, textFilePath);
            }


        }
        public static void FindAllTreeNodesAndCreateCorrespondingFiles(TreeNodeCollection Nodes)
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
                        System.IO.File.Create(TxtFileReference(_node.FullPath, _file.Name)).Close();// "Files\\" + HelperClass.NewFileName(_node.FullPath) + "_" + _file.Name).Close();
                    }
                }
                FindAllTreeNodesAndCreateCorrespondingFiles(_node.Nodes);
            }
        }
    }
}
