using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace Assignment_4_4
{
    public interface Icustomer
    {
        String Search(string type, string payload);
        int roomNumber
        {
            get;
            set;
        }
        int stayLength
        {
            get;
            set;
        }
        String Name
        {
            get;
            set;
        }
        String Address
        {
            get;
            set;
        }
        String ArrivalDate
        {
            get;
            set;
        }
    }

    class Customer
    {
        private string name, address, arrivalDate;
        private int roomNumber, stayLength;

        public Customer(string name, string address, string date, int number, int length)
        {
            this.name = name;
            this.address = address;
            this.arrivalDate = date;
            this.roomNumber = number;
            this.stayLength = length;
        }

        public string ToString()
        {
            return this.name + ',' + this.address + ',' + this.arrivalDate + ',' + this.roomNumber + ',' + this.stayLength;
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
        public string ArrivalDate
        {
            get
            {
                return arrivalDate;
            }
            set
            {
                if (value.Length != 0)
                    arrivalDate = value;
                arrivalDate = "unknown";
            }
        }
        public int RoomNumber
        {
            get
            {
                return roomNumber;
            }
            set
            {
                if (value != 0)
                    roomNumber = value;
                roomNumber = 0;
            }
        }
        public int StayLength
        {
            get
            {
                return stayLength;
            }
            set
            {
                if (value != 0)
                    stayLength = value;
                stayLength = 0;
            }
        }
        //---------------------------------------------------------------------IO-----------------------------------------------------------------------------------------------

        string filePathName = @"U:\Temp\customers.xml";
        public void WriteXML()
        {
            //Here we use the XmlTextWriter to open a new XML file
            XmlTextWriter xmlTextWriter = new XmlTextWriter(filePathName, System.Text.Encoding.UTF8);


            xmlTextWriter.Formatting = Formatting.Indented;
            //Here we write XML declaration
            xmlTextWriter.WriteStartDocument();
            //Here we write the root elemnt
            xmlTextWriter.WriteStartElement("Customers");
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
            XmlNode customerNode = xmlDocument.CreateNode(XmlNodeType.Element, "Customer", null);
            //Here we define an attribute and add it to the employee node
            //Here we create name node without any namespace
            XmlNode nameNode = xmlDocument.CreateNode(XmlNodeType.Element, "Name", null);
            nameNode.InnerText = this.name;
            customerNode.AppendChild(nameNode);
            //Here we create job node without any namespace
            XmlNode addressNode = xmlDocument.CreateNode(XmlNodeType.Element, "Address", null);
            addressNode.InnerText = this.address;
            customerNode.AppendChild(addressNode);

            XmlNode dateNode = xmlDocument.CreateNode(XmlNodeType.Element, "ArrivalDate", null);
            dateNode.InnerText = this.arrivalDate;
            customerNode.AppendChild(dateNode);

            XmlNode roomNode = xmlDocument.CreateNode(XmlNodeType.Element, "RoomNumber", null);
            roomNode.InnerText = this.roomNumber.ToString();
            customerNode.AppendChild(roomNode);

            XmlNode lengthNode = xmlDocument.CreateNode(XmlNodeType.Element, "StayLength", null);
            lengthNode.InnerText = this.stayLength.ToString();
            customerNode.AppendChild(lengthNode);

            //Here we select the first element with the name specified by variable parent and
            //append the newly created child to the end of it.
            xmlDocument.SelectSingleNode("//" + "Customers").AppendChild(customerNode);

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
                    if (this.name == payload)
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
                case "arrivalDate":
                    if (this.arrivalDate == payload)
                    {
                        check = true;
                    }
                    break;
                case "roomNumber":
                    if (this.roomNumber == int.Parse(payload))
                    {
                        check = true;
                    }
                    break;
                case "stayLength":
                    if (this.stayLength == int.Parse(payload))
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

