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

        public String DisplayFlight(Flight flight)
        {
            return String.Format(" Flight's ID: {0}, Flight's Origin: {1}, Flight's Destination: {2}, Flight's Date: {3}, Flight's Price: {4}" , flight.id , flight.origin, flight.destination, flight.date, flight.price);
        }


        public String DisplayFlightshort(Flight flight)
        {
            return String.Format("Flight's Origin: {0}, Flight's Destination: {1}", flight.origin, flight.destination);
        }


        public String ProcessCheapPrice(ProcessFlightDelegate processFlightDelegate, int price)
        {

            String info = "";
            foreach (Flight flight in flights)
            {
                if (flight.CheckPrice(price))
                {
                  info +=  processFlightDelegate(flight) + "\n";
                }
            }
            return info;
        }

    }
}
