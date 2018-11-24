namespace Example_310
{
    using System;
    using System.IO;
    using System.Xml;


    class XMLWriter
    {
        //This method generates and writes the whole XML tree to the specified file.
        public string WriteXML(string filePathName)
        {
            //Here we use the XmlTextWriter to open a new XML file
            XmlTextWriter xmlTextWriter = new XmlTextWriter(filePathName, System.Text.Encoding.UTF8);


            xmlTextWriter.Formatting = Formatting.Indented;
            //Here we write XML declaration
            xmlTextWriter.WriteStartDocument();
            //Here we write the root elemnt
            xmlTextWriter.WriteStartElement("employees");
            //Here we write the first employee
            xmlTextWriter.WriteStartElement("employee");
            //Here we define an attribute with namespace so that the local name
            //of the namespace will be emp and the URI=http://www.emps.com
            xmlTextWriter.WriteAttributeString("emp", "id", "http://www.emps.com", "e1000");
            //Here we write an attribute without namespace definition.
            //xmlTextWriter.WriteAttributeString("id", "e1000");
            xmlTextWriter.WriteElementString("name", "Shirin");
            xmlTextWriter.WriteElementString("job", "Security Expert");
            //This is the end of employee element.
            xmlTextWriter.WriteEndElement();
            //Here we start adding a new employee complex element.
            xmlTextWriter.WriteStartElement("employee");
            //Here we define an attribute with namespace for the element.
            xmlTextWriter.WriteAttributeString("emp", "id", "http://www.emps.com", "e2000");

            //Here we write an attribute without namespace definition.
            //xmlTextWriter.WriteAttributeString("id", "e2000");
            xmlTextWriter.WriteElementString("name", "Farhad");
            xmlTextWriter.WriteElementString("job", "Software Designer");
            //Here we write the ending tag for element employee
            xmlTextWriter.WriteEndElement();
            //Here we end the root element
            xmlTextWriter.WriteEndElement();
            //Here we end the document element
            xmlTextWriter.WriteEndDocument();
            //Here we flush and close the stream

            //xmlTextWriter.Flush();
            xmlTextWriter.Close();
            return GetFileInfo(filePathName);
        }
        //This method returns file information
        public string GetFileInfo(string filePathName)
        {
            //Here we create a FileInfo object
            FileInfo fileInfo = new FileInfo(filePathName);


            //Here we return the file path and its length.
            return Path.GetFullPath(filePathName) + " was written succefully. File size: " + fileInfo.Length + ".";
        }
        //This method appends new elements to the XML tree.
        public string AppendElement(string filePathName)
        {
            //Reading and adding new data
            XmlTextReader xmlTextReader = new XmlTextReader(filePathName);
            //Does not return any whitespace node
            xmlTextReader.WhitespaceHandling = WhitespaceHandling.None;
            //Here we load the file into memory
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlTextReader);
            xmlTextReader.Close();
            XmlElement newEmpElement = xmlDocument.CreateElement("employee");
            newEmpElement.SetAttribute("id", "e5000");
            XmlElement newNameElement = xmlDocument.CreateElement("name");
            newNameElement.InnerText = "Barbara";
            newEmpElement.AppendChild(newNameElement);
            XmlElement newJobElement = xmlDocument.CreateElement("job");
            newJobElement.InnerText = "Software Designer";
            newEmpElement.AppendChild(newJobElement);

            XmlNode rootNode = xmlDocument.DocumentElement;
            // xmlDocument.GetElementById("employees").AppendChild(newEmpElement);

            //Here we would add the new child to the end of the root node
            rootNode.AppendChild(newEmpElement);
            xmlDocument.Save(filePathName);
            return GetFileInfo(filePathName);
        }
        public string AddNewElement(string filePathName, string parent)
        {
            //Here we load the XML file into the memory
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePathName);
            //Here we create employee node without any namespace
            XmlNode employeeNode = xmlDocument.CreateNode(XmlNodeType.Element, "employee", null);
            //Here we define an attribute and add it to the employee node
            XmlAttribute attribute = xmlDocument.CreateAttribute("id");
            attribute.Value = "e8000";
            employeeNode.Attributes.Append(attribute);
            //Here we create name node without any namespace
            XmlNode nameNode = xmlDocument.CreateNode(XmlNodeType.Element, "name", null);
            nameNode.InnerText = "Arash";
            employeeNode.AppendChild(nameNode);
            //Here we create job node without any namespace
            XmlNode jobNode = xmlDocument.CreateNode(XmlNodeType.Element, "job", null);
            jobNode.InnerText = "Software developer";
            employeeNode.AppendChild(jobNode);

            //Here we select the first element with the name specified by variable parent and
            //append the newly created child to the end of it.
            xmlDocument.SelectSingleNode("//" + parent).AppendChild(employeeNode);

            //Here we would add the new child to the beginning of the node
            //xmlDocument.SelectSingleNode("//" + parent).PrependChild(employeeNode);
            //Here we save changes to the XML tree permanently.
            xmlDocument.Save(filePathName);
            //Here we retun some information about the file.
            return GetFileInfo(filePathName);
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            string filePathName = @"U:\Temp\employees.xml";
            FileInfo fileInfo = new FileInfo(filePathName);
            if (!fileInfo.Exists)
            {

                try
                {
                    Console.WriteLine("Creating " + filePathName + "...");

                    //Here we create the file and close it.
                    File.CreateText(filePathName).Close();
                    //Here we check the information of the file
                    Console.WriteLine(fileInfo.Exists + " " + fileInfo.Length);

                }
                catch (FileNotFoundException)
                {
                    //The CLR throws fake exception.
                    //Console.WriteLine("Couldn't create " + filePathName);
                }
            }
            XMLWriter xmlWriter = new XMLWriter();
            //Here we write the XML tree to the file only if the file is empty
            //  if (fileInfo.Length == 0)
            Console.WriteLine(xmlWriter.WriteXML(filePathName));
            //Here we add a new element to the existing XML tree. 
            Console.WriteLine(xmlWriter.AddNewElement(filePathName, "employees"));
            Console.WriteLine(xmlWriter.AppendElement(filePathName));
            Console.ReadLine();
        }
    }
}