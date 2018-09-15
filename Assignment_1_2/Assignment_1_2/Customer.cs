using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1_2
{
    class Customer
    {
        int id;
        string name;
        int flightid;

        public Customer(int id, string name, int flightid)
        {
            this.id = id;
            this.name = name;
            this.flightid = flightid;
        }
        public int getFlightID()
        {
            return flightid;
        }

        public bool CustomerCheck(int id)
        {
            return (id == this.id);
        }

        public bool FlightCheck(int id)
        {
            return (id == this.flightid);
        }

        public string CustomerDetail()
        {
            return "Name: " + name + ", id = " + id + ", flightid = " + flightid;
        }
    }
}
