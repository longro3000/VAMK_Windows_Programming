using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3_1
{
    class AirlineCompany
    {
        private readonly string name;
        private Flight[] flights = new Flight[4];

        public AirlineCompany()
        {
            String[] companies = new String[] { "Finair", "VietNam airline", "Qatar Airways" };
            Random r = new Random();
            int num = r.Next(0, 2);
            name = companies[num];
            this.flights[0] = new Flight(1, "Saigon", "Hanoi", "29.10.2018", 200);
            this.flights[1] = new Flight(2, "Saigon", "Seoul", "30.10.2018", 500);
            this.flights[2] = new Flight(3, "Saigon", "Helsinki", "31.10.2018", 700);
        }

        public Flight this[int index]
        {
            set
            {
                flights[index] = value;
            }
            get
            {
                return flights[index];
            }
        }
        
        public void ProcessCheapPrice(ProcessFlightDelegate processFlightDelegate, int price)
        {
            foreach (Flight flight in flights)
            {
                if (flight.CheckPrice(price))
                {
                    processFlightDelegate(flight);
                }
            }
        }

    }
}
