using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3_3
{
    public class Flight
    {
        public int id;
        public String origin, destination, date;
        public int price;

        public Flight(int id, String origin, String destination, String date)
        {
            this.id = id;
            this.origin = origin;
            this.destination = destination;
            this.date = date;
        }

        public String findFlight(int id)
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
