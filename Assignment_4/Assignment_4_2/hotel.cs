﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace Assignment_4_2
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

        BinaryWriter binaryWriter;
        BinaryReader binaryReader;


        string filePath = @"U:\Temp\hotels.dat";
        public void WriteToFile()
        {
            try
            {

                //Here we initialize binaryWriter object. We use @ before strings

                //to void having to escape special characters
                binaryWriter = new BinaryWriter(new FileStream(filePath, FileMode.Append));
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

                binaryWriter.Write(this.ToString());

            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\nWrite error.");
            }

            binaryWriter.Close();
        }

        public void ReadFromFile()
        {
            try
            {
                binaryReader = new BinaryReader(new FileStream(filePath, FileMode.Open));
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
                while ((item = binaryReader.ReadString()) != null)
                {
                    char[] delimiterChars = { ';' };
                    string[] info = item.Split(delimiterChars);

                    foreach (string i in info)
                        Console.Write(i + " ");

                    Console.WriteLine(Environment.NewLine + "---------" + Environment.NewLine);
                }


                binaryReader.Close();
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
