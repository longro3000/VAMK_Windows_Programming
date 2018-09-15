using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1_2
{
    class Flight
    {
        int id;
        string origin;
        string destination;
        string date;

        public Flight(int id, string origin, string destination, string date)
        {
            this.id = id;
            this.origin = origin;
            this.destination = destination;
            this.date = date;
        }

        public string FlightCheck(int id)
        {
            if (this.id == id)
                return "flight's id: " + id + ", origin: " + origin + ", destination: " + destination + ", date: " + date;
            else return "";
        }

    }
}
