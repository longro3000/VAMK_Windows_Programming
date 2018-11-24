using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Assignment_4_4
{
    class Program
    {
        static void Main(string[] args)
        {
            //CUSTOMER INIT
            Customer customer1 = new Customer("ABC", "DEF", "29.3.2018", 1, 5);
            Customer customer2 = new Customer("DEF", "DEF", "29.3.2018", 2, 6);
            Customer customer3 = new Customer("GHI", "DEF", "29.3.2018", 1, 9);

            ArrayList customers = new ArrayList();
            customers.Add(customer1);
            customers.Add(customer2);
            customers.Add(customer3);
            //WRITE CUSTOMER TO FILE

            customer1.WriteXML();
            customer1.WriteToFile();
            customer2.WriteToFile();
            customer3.WriteToFile();
            //READ CUSTOMER FROM FILE
            customer1.ReadFromFile();
            //ROOM INIT
            Room room1 = new Room(1, "A", "SINGLE", "S", 6.58);
            Room room2 = new Room(1, "B", "DOUBLE", "T", 10.58);

            ArrayList rooms = new ArrayList();
            rooms.Add(room1);
            rooms.Add(room2);
            //WRITE ROOM TO FILE
            room1.WriteXML();
            room1.WriteToFile();
            room2.WriteToFile();
            //READ ROOM FROM FILE
            room1.ReadFromFile();

            //HOTEL INIT
            ArrayList hotels = new ArrayList();
            Hotel hotel1 = new Hotel("contiential", "25.6.1965", "ABC", 8);
            hotel1.addRoom(room1);
            hotel1.addRoom(room2);
            hotel1.addCustomer(customer1);
            hotel1.addCustomer(customer2);

            Hotel hotel2 = new Hotel("new world", "25.7.2005", "DEF", 9);
            hotel2.addRoom(room1);
            hotel2.addCustomer(customer3);
            hotels.Add(hotel1);
            hotels.Add(hotel2);
            //WRITE HOTEL TO FILE
            hotel1.WriteXML();
            hotel1.WriteToFile();
            hotel2.WriteToFile();
            //READ HOTEL FROM FILE
            hotel1.ReadFromFile();

            Console.WriteLine("enter whether you wanna search:\n 1. Customer\n 2. Room\n 3. Hotel\n");
            int i = int.Parse(Console.ReadLine());
            Console.Write("Enter criteria you wanna search: ");
            string type = Console.ReadLine();
            Console.Write("Enter data you wanna search: ");
            string payload = Console.ReadLine();

            switch (i)
            {
                case 1:
                    {
                        String value ="";
                        foreach (Customer c in customers)
                        {
                            value += c.Search(type, payload);
                        }
                        Console.WriteLine(value);
                        break;
                    }
                case 2:
                    {
                        String value = "";
                        foreach (Room r in rooms)
                        {
                            value += r.Search(type, payload);
                        }
                        Console.WriteLine(value);
                        break;
                    }
                case 3:
                    {
                        String value = "";
                        foreach (Hotel h in hotels)
                        {
                            value += h.Search(type, payload);
                        }
                        Console.WriteLine(value);
                        break;
                    }
        
            }
            Console.ReadLine();
        }
    }
}
