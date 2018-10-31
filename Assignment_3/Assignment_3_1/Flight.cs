using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3_1
{
    class Flight
    {
        public int id;
        public String origin, destination, date;
        public int price;

        public Flight(int id, String origin, String destination, String date, int price)
        {
            this.id = id;
            this.origin = origin;
            this.destination = destination;
            this.date = date;
            this.price = price;
        }

        public String FindFlight(int id)
        {
            if (this.id == id)
                return this.toString();
            else return null;
        }

        public String toString()
        {
            return "Flight ID: " + id + ", Origin: " + origin + ", Destination: " + destination + ", Date: " + date + ", Price: " + price + "\n";
        }

    }
}
