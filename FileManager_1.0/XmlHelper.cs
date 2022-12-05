using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FileManager_1._0
{
    internal static class XmlHelper
    {
        public static XmlElement CreateXmlElement(XmlDocument xml, string itemType, string itemAttrType, string itemAttrText)
        {
            // Формую xml-node для xml-документа за відповідними параметрами
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
        private static Tuple<XmlDocument, XmlElement> updateDocRecFunc(XmlDocument xDoc, XmlElement myElem, Folder classItem)
        {
            foreach (Component comp in classItem.Get())
            {
                if (comp is Folder)
                {
                    var newFolder = XmlHelper.CreateXmlElement(xDoc, "folder", "FOLDER", comp.Name);
                    newFolder.InnerText = "";
                    myElem.AppendChild(updateDocRecFunc(xDoc, newFolder, (Folder)comp).Item2);
                }
                else if (comp is File)
                {
                    var newFile = XmlHelper.CreateXmlElement(xDoc, "document", "DOCUMENT", comp.Name);
                    newFile.InnerText = "";
                    myElem.AppendChild(newFile);
                }
            }

            return Tuple.Create(xDoc, myElem);
        }
        public static void updateDoc(string xpath, string filePath, Component classItem)
        {
            // Оновлюю xml-документ, вставляючи на місце xpath усю структуру classItem (якщо папка, то папку, та весь вміст)
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(filePath);

            var newHomeNode = xDoc.SelectSingleNode(xpath);
            if (classItem is Folder)
            {
                var newFolder = XmlHelper.CreateXmlElement(xDoc, "folder", "FOLDER", classItem.Name);
                var res = updateDocRecFunc(xDoc, newFolder, (Folder)classItem);
                newHomeNode.AppendChild(res.Item2);
            }
            else if (classItem is File)
            {
                var newFile = XmlHelper.CreateXmlElement(xDoc, "document", "DOCUMENT", classItem.Name);
                newHomeNode.AppendChild(newFile);

            }
            xDoc.Save(filePath);
        }
        public static void RemoveFromXML(string xPath, string filePath)
        {
            // Видаляю нод за таким шляхом xPath з xml-документа
            XmlDocument xml = new XmlDocument();
            xml.Load(filePath);
            var myNode = xml.SelectSingleNode(xPath);
            myNode.ParentNode.RemoveChild(myNode);
            xml.Save(filePath);
        }
    }
}
