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
    [Serializable]
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

        BinaryFormatter binaryFormatter = new BinaryFormatter();


        public void WriteToFile()
        {
            string filePath = @"U:\Temp\customers_ser.dat";
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
            string filePath = @"U:\Temp\customers_ser.dat";
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

