using System;

using System.Collections;

namespace Example_25
{

    //Here we define class Item

    public class Item
    {
        private string name;
        private double price;


        public Item(string name, double price)
        {

            this.name = name;

            this.price = price;

        }



        public string Name
        {
            get
            {
                return name;
            }

        }


        public double Price
        {
            get
            {
                return price;
            }

        }



        public bool CheckPrice(double price)
        {

            if (this.price < price)

                return true;

            return false;

        }

    }

    //Here we declare a delegate type for processing a item:

    public delegate void ProcessItemDelegate(Item item);

    //Here we maintain a item database.

    public class ItemDB
    {

        int itemCounter;

        double totalPrice;

        //Here we create itemList of all items in the database

        ArrayList itemList;

        public ItemDB()
        {

            itemList = new ArrayList();

            itemCounter = 0;

            totalPrice = 0.0;

        }

        //Here we add an item to the database

        public void AddItem(string name, double price)
        {

            itemList.Add(new Item(name, price));

            itemCounter++; ;

            totalPrice += price;

        }

        public void AddItem(Item item)
        {

            itemList.Add(item);
            itemCounter++;

            totalPrice += item.Price;


        }


        public void DisplayItemInfo(Item item)
        {

            Console.WriteLine(item.Name + " " + item.Price);


        }





        public double AveragePrice()
        {

            return totalPrice / itemCounter;

        }


        //Here we call a passed-in delegate on each item to process it

        public void ProcessCheapItems(ProcessItemDelegate processItemDelegate, double price)
        {

            foreach (Item item in itemList)
            {

                if (item.CheckPrice(price))

                    //Here we call the delegate
                    processItemDelegate(item);

            }



        }

    }


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

            Console.WriteLine("Items with prices lower than 100 euros:");

            //Here we call ProcessCheapItems() method and pass a delegate instance to it


            double price;
            Console.Write("Please enter a price: ");
            price = Int16.Parse(Console.ReadLine());

            ProcessItemDelegate pid = new ProcessItemDelegate(DisplayName);

            itemDB.ProcessCheapItems(pid, price);

            //Here we call ProcessCheapItems() method and pass another delegate instance to it

            itemDB.ProcessCheapItems(new ProcessItemDelegate(itemDB.DisplayItemInfo), price);


            Console.WriteLine("Average Item Price: {0:#.##} euros",

               itemDB.AveragePrice());

            Console.ReadLine();

        }

    }
}
