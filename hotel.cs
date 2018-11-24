using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace Assignment_4_1
{
    public interface Ihotel
    {
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

    class hotel : Ihotel
    {
        private String name, constructionDate, address;
        private int stars;
        ArrayList RoomList = new ArrayList();
        ArrayList CustomerList = new ArrayList();

        public hotel(String name, String date, String address, int stars)
        {
            this.name = name;
            this.constructionDate = date;
            this.address = address;
            this.stars = stars;
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
                if (value !=  0)
                    stars = value;
                stars = 0;
            }
        }

        TextWriter textWriter;
        TextReader textReader;


        String filePath = @"U:\Temp\hotels.txt";

            try
            {


                //Here we define a StreamWriter object for appending text.
                textWriter = new StreamWriter(filePath);
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
                textWriter.WriteLine("Toothbrush;10;1,90");
                textWriter.WriteLine("Toothpaste;5 3,90");
                textWriter.WriteLine("Soap;25 2,95");
                textWriter.WriteLine("Cream;30 4,60");

            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\nWrite error.");
            }

            textWriter.Close();

    }
}
