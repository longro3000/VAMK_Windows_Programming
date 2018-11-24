using System;
using System.Xml;
using System.IO;
namespace Example_311
{
    class XMLReader
    {
        private static void AddChildren(XmlNode xmlNode, int level)
        {
            XmlNode childXmlNode;
            //Here we speciy padding; th enumber of spaces based on the level in the XML tree
            string pad = new string(' ', level * 2);

            Console.WriteLine(pad + xmlNode.Name + "(" + xmlNode.NodeType.ToString() + ": " + xmlNode.Value + "");
            //Here we extract possible attributes
            if (xmlNode.NodeType == XmlNodeType.Element)
            {

                XmlNamedNodeMap mapAttributes = xmlNode.Attributes;
                for (int i = 0; i < mapAttributes.Count; i++)
                {
                    Console.WriteLine(pad + " " + mapAttributes.Item(i).Name + "=" + mapAttributes.Item(i).Value);
                }

            }
            //Here we call recursively o all children of the current node
            if (xmlNode.HasChildNodes)
            {
                childXmlNode = xmlNode.FirstChild;
                while (childXmlNode != null)
                {
                    AddChildren(childXmlNode, level + 1);
                    childXmlNode = childXmlNode.NextSibling;
                }
            }
        }
            try
                //Here we open the XML file
                XmlTextReader xmlTextReader = new XmlTextReader(filePath);
                //Does not return any whitespace node
                xmlTextReader.WhitespaceHandling = WhitespaceHandling.None;
                //Here we load the file into memory
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(xmlTextReader);
                //Here we get the document root nodeXmlNode xmlNode=
                XmlNode xmlNode = xmlDocument.DocumentElement;
                //Here we recursively walk through the node tree
                AddChildren(xmlNode, 0);
                //Heer we close the reader
                xmlTextReader.Close();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(filePath + " was not found!");
            }
            Console.ReadLine();
        }
    }
}