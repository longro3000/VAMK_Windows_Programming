using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3_1
{
    public delegate String ProcessFlightDelegate(Flight flight);

    class Program
    {
        


        static void Main(string[] args)
        {
            AirlineCompany airlineCompany = new AirlineCompany();

            airlineCompany[3] = new Flight(4, "Helsinki", "Tokyo", "11.11.2019", 900);

            for (int i = 0; i<4; i++)
            {
                Console.WriteLine(airlineCompany[i].toString());
            }

            Console.Write("Enter a flight's ID: ");
            int id = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Flight found: ");

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(airlineCompany[i].FindFlight(id));
            }

            Console.Write("Enter a price: ");
            int price = Convert.ToInt16(Console.ReadLine());

            ProcessFlightDelegate pfd = new ProcessFlightDelegate(airlineCompany.DisplayFlight);
            ProcessFlightDelegate pfd2 = new ProcessFlightDelegate(airlineCompany.DisplayFlightshort);
            ProcessFlightDelegate pfd3 = pfd + pfd2;

            Console.WriteLine(airlineCompany.ProcessCheapPrice(pfd3, price));

            Console.ReadLine();
        }
    }
}
