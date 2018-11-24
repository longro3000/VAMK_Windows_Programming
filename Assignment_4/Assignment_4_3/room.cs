using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Assignment_4_3
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

    [Serializable]
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

        BinaryFormatter binaryFormatter = new BinaryFormatter();


        public void WriteToFile()
        {
            string filePath = @"U:\Temp\rooms_ser.dat";
            FileStream fileStream = new FileStream(filePath, FileMode.Append);
            // Here we write some data into the file. Note, that the decimal
            //separator is set to , because of finnish location.
            try
            {

                binaryFormatter.Serialize(fileStream, this.ToString());
                fileStream.Flush();

            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\nWrite error.");
            }

            fileStream.Close();
        }

        public void ReadFromFile()
        {
            string filePath = @"U:\Temp\rooms_ser.dat";
            FileStream fileStream = new FileStream(filePath, FileMode.Open);
            string item = "";
            object obj = null;
            for (;;)
            {
                try
                {
                    obj = binaryFormatter.Deserialize(fileStream);
                    //obj = soapFormatter.Deserialize(fileStream);
                    //Here we check whether obj is of type Employee 
                    //or not and if it is, we type cast it to Employee
                    //and call the GetEmployee() method.
                    if (obj is string)
                    {
                        item += obj;
                    }

                }
                catch (EndOfStreamException e)
                {
                    Console.WriteLine("No object left!" + e.Message);
                }
                catch (SerializationException)
                {
                    // Console.WriteLine(e.Message);
                    break;
                }
                catch (System.Xml.XmlException)
                {
                    //Console.WriteLine(e.Message);
                    break;
                }

            }
            Console.WriteLine(item);
            fileStream.Close();
        }
        //----------------------------------------------------SEARCH METHOD-----------------------------------------------------------------

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
