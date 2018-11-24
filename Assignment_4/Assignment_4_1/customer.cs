using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment_4_1
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

        TextWriter textWriter;
        TextReader textReader;


        String filePath = @"U:\Temp\customers.txt";
        public void WriteToFile()
        {
            try
            {
                //Here we define a StreamWriter object for appending text.
                textWriter = new StreamWriter(filePath, true);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\nCannot open " + filePath);
                return;
            }

            // Here we write some data into the file. Note, that the decimal
            //separator is set to , because of finnish location.
            try
            {

                textWriter.WriteLine(this.ToString());

            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\nWrite error.");
            }

            textWriter.Close();
        }

        public void ReadFromFile()
        {
            try
            {
                textReader = new StreamReader(filePath);
                // textReader = new StreamReader(@" d:\temp\products.txt");

            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message + "\nCannot open " + filePath);
                return;
            }
            string item;
            try
            {
                // Read an inventory entry. 
                while ((item = textReader.ReadLine()) != null)
                {
                    char[] delimiterChars = { ',' };
                    string[] info = item.Split(delimiterChars);

                    foreach (string i in info)
                        Console.Write(i + " ");

                    Console.WriteLine(Environment.NewLine + "---------" + Environment.NewLine);
                }


                textReader.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "Read error.");
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

