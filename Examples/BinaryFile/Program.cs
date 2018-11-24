using System;
using System.IO;


namespace BinaryFile
{
    public class Product
    {
        public static void Main()
        {

            //Here we declare the binary writer and reader objects
            BinaryWriter binaryWriter;
            BinaryReader binaryReader;

            string item;
            int amount;
            double price;

            string filePath = @"U:\Temp\products.dat";

            try
            {

                //Here we initialize binaryWriter object. We use @ before strings

                //to void having to escape special characters
                binaryWriter = new BinaryWriter(new FileStream(filePath, FileMode.OpenOrCreate));
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\nCannot open " + filePath);
                return;
            }


            //Here we define a group of products
            string[] productNames = new string[] { "Toothbrush", "Toothpaste", "Soap" };
            int[] productAmounts = new int[] { 10, 5, 20 };
            double[] productPrices = new double[] { 1.80, 2.67, 3.45 };


            // Here we write some data into the file. 
            try
            {

                for (int i = 0; i < productNames.Length; i++)
                {
                    binaryWriter.Write(productNames[i]);
                    binaryWriter.Write(productAmounts[i]);
                    binaryWriter.Write(productPrices[i]);
                }

            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\nWrite error.");
            }

            binaryWriter.Close();

            Console.WriteLine();

            // Here we open the file for reading. 
            try
            {
                binaryReader = new BinaryReader(new FileStream(filePath, FileMode.Open));
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

            try
            {

                for (;;)
                {

                    // Read an inventory entry. 
                    item = binaryReader.ReadString();
                    amount = binaryReader.ReadInt32();
                    price = binaryReader.ReadDouble();

                    /* See if the item matches the one requested. 
                    If so, display information */
                    if (item.Equals(product))
                    {
                        Console.WriteLine(amount + " " + item + " items. " + "Price: {0:} $  each", price);
                        Console.WriteLine("Total value of {0}: {1} $.", item, price * amount);


                        break;
                    }
                }
            }

            catch (EndOfStreamException)
            {
                Console.WriteLine(product + " was not found!");
            }
            catch (IOException e)
            {
                Console.WriteLine("Read error." + e.Message);
            }
            Console.ReadLine();

        }


    }
}