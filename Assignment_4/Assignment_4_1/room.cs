using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment_4_1
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

        TextWriter textWriter;
        TextReader textReader;


        String filePath = @"U:\Temp\rooms.txt";
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
