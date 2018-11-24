using System;
using System.IO;


namespace Example34
{
    public class Program
    {
        public static void Main()
        {

            TextWriter textWriter;
            TextReader textReader;


            String filePath = @"U:\Temp\products.txt";

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

            Console.WriteLine();

            // Here we open the file for reading.
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


            //Here we serach items entered by user.
            Console.Write("Please type product name: ");
            string product = Console.ReadLine();
            Console.WriteLine();

            string item;
            bool itemFound = false;
            try
            {
                // Read an inventory entry.
                while ((item = textReader.ReadLine()) != null)
                {
                    char[] delimiterChars = { ' ', ';' };
                    string[] info = item.Split(delimiterChars);

                    foreach (string i in info)
                        Console.Write(i + " ");

                    Console.WriteLine(Environment.NewLine + "---------" + Environment.NewLine);

                    //foreach(string str in info)
                    //    Console.Write(str + " ");

                    //Console.WriteLine();


                    /* See if the item matches the one requested.
                    If so, display information */
                    if (info[0].Equals(product))
                    {
                        Console.WriteLine(info[0] + " " + info[1] + " items. " +
                        "Price: {0:C} each", double.Parse(info[2]));
                        Console.WriteLine("Total value of {0}: {1:C}.",
                        info[0], Int16.Parse(info[1]) * double.Parse((info[2])));

                        itemFound = true;

                        break;
                    }
                }

                textReader.Close();

                if (itemFound == false)
                    Console.WriteLine(product + " was not found.");
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "Read error.");
            }

            Console.ReadLine();
        }
    }
}