
using System;
using System.Collections;
namespace Example_25
{

    //Here we declare a delegate type for processing a item:
    public delegate void ProcessItemDelegate(Item item);


    //Here we define the main class
    class Program
    {
        //Here we print the name of the item.
        static void DisplayName(Item item)
        {
            Console.WriteLine("   {0}", item.Name);
        }

        public static void Main()
        {
            ItemDB itemDB = new ItemDB();
            itemDB.AddItem("Chair", 45.67);
            itemDB.AddItem("Table", 165.80);
            itemDB.AddItem("Desk", 65.30);
            itemDB.AddItem(new Item("Laptop", 148.0));
            //Console.WriteLine("Items with prices lower than 100 euros:");
            //Here we call ProcessCheapItems() method and pass a delegate instance to it
            string input = "";
            double price = 0;
            bool cont = false;

            do
            {
                try
                {
                    Console.Write("Please enter a price: ");
                    input = Console.ReadLine();
                    price = Int16.Parse(input);
                    cont = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine(input + " is not convertible to a number!");
                    cont = true;
                }
            } while (cont);

            ProcessItemDelegate pid = new ProcessItemDelegate(DisplayName);
            itemDB.ProcessCheapItems(pid, price);
            //Here we call ProcessCheapItems() method and pass another delegate instance to it
            itemDB.ProcessCheapItems(new ProcessItemDelegate(itemDB.DisplayItemInfo), price);

            Console.WriteLine("Average Item Price: {0:#.##} euros", itemDB.AveragePrice());

            Console.ReadLine();
        }
    }
}
