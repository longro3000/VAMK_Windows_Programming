using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3_1
{
    public delegate void ProcessFlightDelegate(Flight flight);

    class Program
    {
        static void DisplayFlight(Flight flight)
        {
            Console.WriteLine(" Flight's ID: {0}, Flight's Origin: {1}, Flight's Destination: {2}, Flight's Date: {3}, Flight's Price: {4}", flight.id, flight.origin, flight.destination, flight.date, flight.price);
        }
        static void Main(string[] args)
        {
            AirlineCompany airlineCompany = new AirlineCompany();

            airlineCompany[3] = new Flight(4, "Helsinki", "Tokyo", "11.11.2019", 900);

            for (int i = 0; i<4; i++)
            {
                Console.WriteLine(airlineCompany[i].toString());
            }

            Console.WriteLine("Enter a flight's ID: ");
            int id = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Flight found: ");

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(airlineCompany[i].FindFlight(id));
            }

            Console.WriteLine("Enter a price: ");
            int price = Convert.ToInt16(Console.ReadLine());

            ProcessFlightDelegate pfd = new ProcessFlightDelegate(DisplayFlight);

            airlineCompany.ProcessCheapPrice(pfd, price);

            Console.ReadLine();
        }
    }
}
