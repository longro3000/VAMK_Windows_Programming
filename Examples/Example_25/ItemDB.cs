using System;
using System.Collections;

namespace Example_25
{
    //Here we maintain a item database.
    public class ItemDB
    {
        double totalPrice;
        //Here we create itemList of all items in the database
        ArrayList itemList;
        public ItemDB()
        {
            itemList = new ArrayList();
            totalPrice = 0.0;
        }
        //Here we add an item to the database
        public void AddItem(string name, double price)
        {
            itemList.Add(new Item(name, price));
            totalPrice += price;
        }
        public void AddItem(Item item)
        {
            itemList.Add(item);
            totalPrice += item.Price;
        }

        public void DisplayItemInfo(Item item)
        {
            Console.WriteLine(item.Name + " " + item.Price);

        }
        public double AveragePrice()
        {
            if (this.itemList.Count == 0)
                return 0.0;
            return totalPrice / this.itemList.Count;
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
}