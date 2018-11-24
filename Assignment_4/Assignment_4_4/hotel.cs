
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Xml;

namespace Assignment_4_4
    {
        
        public interface Ihotel
        {
            string Search(string type, string payload);
            String Name
            {
                get;
                set;
            }
            String ConstructionDate
            {
                get;
                set;
            }
            String Address
            {
                get;
                set;
            }
            int Stars
            {
                get;
                set;
            }
        }


        class Hotel : Ihotel
        {
            private String name, constructionDate, address;
            private int stars;
            ArrayList roomList = new ArrayList();
            ArrayList customerList = new ArrayList();

            public Hotel(String name, String date, String address, int stars)
            {
                this.name = name;
                this.constructionDate = date;
                this.address = address;
                this.stars = stars;
            }
            public void addRoom(Room r)
            {
                roomList.Add(r);
            }
            public void addCustomer(Customer c)
            {
                customerList.Add(c);
            }
        public string RoomListToString()
            {
                string list = "";
                foreach ( Room r in roomList)
                {
                    list += r.ToString() + "/";
                }
                return list;
            }
            public string CustomerListToString()
            {
                string list = "";
                foreach (Room r in roomList)
                {
                    list += r.ToString() + "/";
                }
                return list;
             }
            public string ToString()
            {
                return this.name + ";" + this.constructionDate + ";" + this.address + ";" + this.stars + ";" + this.RoomListToString() + ";" + this.CustomerListToString();
            }

        public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    if (value.Length != 0)
                        name = value;
                    name = "unknown";
                }
            }

            public string ConstructionDate
            {
                get
                {
                    return constructionDate;
                }
                set
                {
                    if (value.Length != 0)
                        constructionDate = value;
                    constructionDate = "unknown";
                }
            }

            public string Address
            {
                get
                {
                    return address;
                }
                set
                {
                    if (value.Length != 0)
                        address = value;
                    address = "unknown";
                }
            }

            public int Stars
            {
                get
                {
                    return stars;
                }
                set
                {
                    if (value != 0)
                        stars = value;
                    stars = 0;
                }
            }

        //---------------------------------------------------------------------IO-----------------------------------------------------------------------------------------------

        string filePathName = @"U:\Temp\hotels.xml";
        public void WriteXML()
        {
            //Here we use the XmlTextWriter to open a new XML file
            XmlTextWriter xmlTextWriter = new XmlTextWriter(filePathName, System.Text.Encoding.UTF8);


            xmlTextWriter.Formatting = Formatting.Indented;
            //Here we write XML declaration
            xmlTextWriter.WriteStartDocument();
            //Here we write the root elemnt
            xmlTextWriter.WriteStartElement("Hotels");
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
            XmlNode hotelNode = xmlDocument.CreateNode(XmlNodeType.Element, "Hotel", null);
            //Here we define an attribute and add it to the employee node
            //Here we create name node without any namespace
            XmlNode nameNode = xmlDocument.CreateNode(XmlNodeType.Element, "Name", null);
            nameNode.InnerText = this.name;
            hotelNode.AppendChild(nameNode);

            XmlNode dateNode = xmlDocument.CreateNode(XmlNodeType.Element, "ConstructionDate", null);
            dateNode.InnerText = this.constructionDate;
            hotelNode.AppendChild(dateNode);

            //Here we create job node without any namespace
            XmlNode addressNode = xmlDocument.CreateNode(XmlNodeType.Element, "Address", null);
            addressNode.InnerText = this.address;
            hotelNode.AppendChild(addressNode);

            XmlNode starNode = xmlDocument.CreateNode(XmlNodeType.Element, "Stars", null);
            starNode.InnerText = this.stars.ToString();
            hotelNode.AppendChild(starNode);

            //Here we select the first element with the name specified by variable parent and
            //append the newly created child to the end of it.
            xmlDocument.SelectSingleNode("//" + "Hotels").AppendChild(hotelNode);

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
        }
        //----------------------------------------------------SEARCH METHOD-----------------------------------------------------------------

        public string Search(string type, string payload)
        {
            bool check = false;
            
            switch (type)
            {
                case "name":
                    if (this.name == payload) {
                        check = true;
                    }
                    break;
                case "constructionDate":
                    if (this.constructionDate == payload)
                    {
                        check = true;
                    }
                    break;
                case "address":
                    if (this.address == payload)
                    {
                        check = true;
                    }
                    break;
                case "stars":
                    if (this.stars == int.Parse(payload))
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
