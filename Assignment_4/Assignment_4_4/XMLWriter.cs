using System.IO;
using System.Xml;

namespace Assignment_4_4
{
    class XMLWriter
    {
        string filePathName = @"U:\Temp\customers.xml";
        public void WriteXML(string filePathName, string parent)
        {
            //Here we use the XmlTextWriter to open a new XML file
            XmlTextWriter xmlTextWriter = new XmlTextWriter(filePathName, System.Text.Encoding.UTF8);


            xmlTextWriter.Formatting = Formatting.Indented;
            //Here we write XML declaration
            xmlTextWriter.WriteStartDocument();
            //Here we write the root elemnt
            xmlTextWriter.WriteStartElement(parent);
            xmlTextWriter.WriteEndElement();
            xmlTextWriter.WriteEndDocument();
            //Here we flush and close the stream

            //xmlTextWriter.Flush();
            xmlTextWriter.Close();
        }

        public void AddNewElement(string filePathName, string parent)
        {
            //Here we load the XML file into the memory
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePathName);
            //Here we create employee node without any namespace
            XmlNode employeeNode = xmlDocument.CreateNode(XmlNodeType.Element, "hotel", null);
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
        }
        //This method returns file information
    }
}