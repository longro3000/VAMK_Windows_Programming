using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace Assignment_3_3
{
    class Ticket
    {
        Flight flight;
        public int ticketID, passengerID;
        double price;
        private static readonly double extraTax;
        static DateTime date;

        static Ticket()
        {

  
            if ((date.DayOfWeek == DayOfWeek.Saturday) || (date.DayOfWeek == DayOfWeek.Sunday))
            {

                extraTax = 0.07;
            }
            else
            {
                extraTax = 0.05;
            }
                
        }
        public void addTicket(Flight flight, int ticketID, int passengerID, double price)
        {
            this.flight = flight;
            this.ticketID = ticketID;
            this.passengerID = passengerID;
            this.price = price;
        }

        public double getPrice(int id)
        {
            if (id == ticketID)
                return price + (price * extraTax);
            else return 0.0;
        }

        public String getInfo(Passenger[] passengers)
        {
             String ticketsInfo= "Ticket Info:\n" + this.toString() + "passengers Info:\n";
             foreach (Passenger passenger in passengers )
             {
                if (passenger.id == this.passengerID)
                {
                    ticketsInfo += passenger.getInfo(passengerID);
                }
             }
            return ticketsInfo;
        }

        public String toString()
        {
            return "Flight: " + flight.toString() + "ticketID: " + ticketID + ", passengerID: " + passengerID + ", price: " + this.getPrice(this.ticketID) + "\n";
        }

    }
}
