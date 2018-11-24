using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace Assignment_4_4
{
    public interface Iroom
    {
        String Search(string type, string payload);
        int Number
        {
            get;
            set;
        }
        String Area
        {
            get;
            set;
        }
        String Type
        {
            get;
            set;
        }
        String Description
        {
            get;
            set;
        }
        double Price
        {
            get;
            set;
        }
    }

    class Room : Iroom
    {
        private int number;
        private String area, type, description;
        private double price;

        public Room(int number, string area, string type, string description, double price)
        {
            this.number = number;
            this.area = area;
            this.type = type;
            this.description = description;
            this.price = price;
        }
        public string ToString()
        {
            return this.number + ',' + this.area + ',' + this.type + ',' + this.description + ',' + this.price;
        }
        public string Area
        {
            get
            {
                return area;
            }
            set
            {
                if (value.Length != 0)
                    area = value;
                area = "unknown";
            }
        }
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                if (value.Length != 0)
                    type = value;
                type = "unknown";
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                if (value.Length != 0)
                    description = value;
                description = "unknown";
            }
        }

        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                if (value != 0)
                    number = value;
                number = 0;
            }
        }

        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value != 0)
                    price = value;
                price = 0;
            }
        }
        //---------------------------------------------------------------------IO-----------------------------------------------------------------------------------------------

        string filePathName = @"U:\Temp\rooms.xml";
        public void WriteXML()
        {
            //Here we use the XmlTextWriter to open a new XML file
            XmlTextWriter xmlTextWriter = new XmlTextWriter(filePathName, System.Text.Encoding.UTF8);


            xmlTextWriter.Formatting = Formatting.Indented;
            //Here we write XML declaration
            xmlTextWriter.WriteStartDocument();
            //Here we write the root elemnt
            xmlTextWriter.WriteStartElement("Rooms");
            xmlTextWriter.WriteEndElement();
            xmlTextWriter.WriteEndDocument();
            //Here we flush and close the stream

            //xmlTextWriter.Flush();
            xmlTextWriter.Close();
        }
        public void AddNewElement()
        {
            //Here we load the XML file into the memory
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePathName);
            //Here we create employee node without any namespace
            XmlNode roomNode = xmlDocument.CreateNode(XmlNodeType.Element, "Room", null);
            //Here we define an attribute and add it to the employee node
            //Here we create name node without any namespace
            XmlNode numberNode = xmlDocument.CreateNode(XmlNodeType.Element, "Number", null);
            numberNode.InnerText = this.number.ToString();
            roomNode.AppendChild(numberNode);

            XmlNode areaNode = xmlDocument.CreateNode(XmlNodeType.Element, "Area", null);
            areaNode.InnerText = this.area;
            roomNode.AppendChild(areaNode);

            XmlNode typeNode = xmlDocument.CreateNode(XmlNodeType.Element, "Type", null);
            typeNode.InnerText = this.type;
            roomNode.AppendChild(typeNode);

            //Here we create job node without any namespace
            XmlNode descriptionNode = xmlDocument.CreateNode(XmlNodeType.Element, "Description", null);
            descriptionNode.InnerText = this.description;
            roomNode.AppendChild(descriptionNode);

            XmlNode priceNode = xmlDocument.CreateNode(XmlNodeType.Element, "Price", null);
            priceNode.InnerText = this.price.ToString();
            roomNode.AppendChild(priceNode);

            //Here we select the first element with the name specified by variable parent and
            //append the newly created child to the end of it.
            xmlDocument.SelectSingleNode("//" + "Rooms").AppendChild(roomNode);

            //Here we would add the new child to the beginning of the node
            //xmlDocument.SelectSingleNode("//" + parent).PrependChild(employeeNode);
            //Here we save changes to the XML tree permanently.
            xmlDocument.Save(filePathName);
            //Here we retun some information about the file.
        }
        private static void AddChildren(XmlNode xmlNode, int level)
        {
            XmlNode childXmlNode;
            //Here we speciy padding; th enumber of spaces based on the level in the XML tree
            string pad = new string(' ', level * 2);

            Console.WriteLine(pad + xmlNode.Name + ": " + xmlNode.Value + "");
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

        public void WriteToFile()
        {
            this.AddNewElement();
        }

        public void ReadFromFile()
        {
            try
            {
                //Here we open the XML file
                XmlTextReader xmlTextReader = new XmlTextReader(filePathName);
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
                Console.WriteLine(filePathName + " was not found!");
            }
        }        //----------------------------------------------------SEARCH METHOD-----------------------------------------------------------------

        public string Search(string type, string payload)
        {
            bool check = false;

            switch (type)
            {
                case "number":
                    if (this.number == int.Parse(payload))
                    {
                        check = true;
                    }
                    break;
                case "constructionDate":
                    if (this.area == payload)
                    {
                        check = true;
                    }
                    break;
                case "type":
                    if (this.type == payload)
                    {
                        check = true;
                    }
                    break;
                case "description":
                    if (this.description == payload)
                    {
                        check = true;
                    }
                    break;
                case "price":
                    if (this.number == double.Parse(payload))
                    {
                        check = true;
                    }
                    break;
                default:
                    return "please type a criteria !";
                    break;
            }

            if (check)
            {
                return this.ToString();
            }
            else
            {
                return "";
            }
        }

    }
}
