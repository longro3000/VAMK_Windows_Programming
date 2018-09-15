using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer[] Customers = new Customer[6];
            Flight[] Flights = new Flight[4];
            int CustomerID = 0;

            Customers[0] = new Customer(11, "abc", 1);
            Customers[1] = new Customer(13, "def", 2);
            Customers[2] = new Customer(15, "ghi", 1);
            Customers[3] = new Customer(22, "jkl", 3);
            Customers[4] = new Customer(29, "mno", 2);

            Flights[0] = new Flight(4, "SaiGon", "HaNoi", "12.01.88");
            Flights[1] = new Flight(2, "SaiGon", "HaNoi", "12.01.88");
            Flights[2] = new Flight(3, "SaiGon", "HaNoi", "12.01.88");

            Console.Write("enter Customer id: ");
            int id = Int16.Parse(Console.ReadLine());
            Console.Write("enter Customer name: ");
            string name = Console.ReadLine();
            Console.Write("enter Customer's flight id: ");
            int flightid = Int16.Parse(Console.ReadLine());

            Customers[5] = new Customer(id, name, flightid);

            Console.Write("enter flight id: ");
            id = Int16.Parse(Console.ReadLine());
            Console.Write("enter flight origin: ");
            string origin = Console.ReadLine();
            Console.Write("enter flight destination: ");
            string destination = Console.ReadLine();
            Console.Write("enter flight date: ");
            string date = Console.ReadLine();

            Flights[3] = new Flight(id, origin, destination, date);

            Console.Write("search customer id: ");
            int idSearch  = Int16.Parse(Console.ReadLine());

            Console.WriteLine(" Customers length" + Customers.Length);
            Console.WriteLine(" Customer Found: ");
            for (int i = 0; i < Customers.Length; i++)
            {
                if (Customers[i].CustomerCheck(idSearch))
                {
                    Console.WriteLine(Customers[i].CustomerDetail());
                    CustomerID = Customers[i].getFlightID();
                }
            }
            Console.WriteLine();
            Console.WriteLine("Targeted Customer's Flight: ");
            for (int i = 0; i < Flights.Length; i++)
            {
                Console.WriteLine(Flights[i].FlightCheck(CustomerID));
            }

            Console.Write("search flight id: ");
            idSearch = Int16.Parse(Console.ReadLine());

            Console.WriteLine(" flight Found: ");
            for (int i = 0; i < Flights.Length; i++)
            {
                Console.WriteLine(Flights[i].FlightCheck(id));
            }

            Console.WriteLine(" Targeted flight's customers: ");
            for (int i = 0; i < Customers.Length; i++)
            {
                if (Customers[i].FlightCheck(idSearch))
                {
                    Console.WriteLine(Customers[i].CustomerDetail());
                }
            }

            Console.ReadLine();
        }
    }
}
