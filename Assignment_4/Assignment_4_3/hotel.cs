
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Assignment_4_3
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

        [Serializable]

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

        BinaryFormatter binaryFormatter = new BinaryFormatter();
  

        public void WriteToFile()
        {
            string filePath = @"U:\Temp\hotels_ser.dat";
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
            string filePath = @"U:\Temp\hotels_ser.dat";
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
