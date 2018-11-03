using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Assignment_3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Flight[] flightList = new Flight[2];
            Passenger[] passengerList = new Passenger[3];
            Ticket[] ticketList = new Ticket[2];

            flightList[0] = new Flight(1, "SG", "HEL", "11.11.2018");
            flightList[1] = new Flight(2, "HEL", "VAA", "11.12.2018");

            passengerList[0] = new Passenger(1, "ABC", "DEF", "0234896456");
            passengerList[1] = new EconomyPassenger(2, "DUNG", "HOANG", "045874212", 30);
            passengerList[2] = new FirstClassPassenger(3, "NGUYEN", "BUI", "0234685423", 30, "MEAT");

            ticketList[0] = new Ticket();
            ticketList[0].addTicket(flightList[0], 1, 2, 500);

            ticketList[1] = new Ticket();
            ticketList[1].addTicket(flightList[1], 2, 3, 700);

            passengerList[2].addTicket(ticketList[0]);
            passengerList[2].addTicket(ticketList[1]);

            passengerList[1].addTicket(ticketList[0]);
            passengerList[1].addTicket(ticketList[1]);

            int i;

            Console.Write("Enter Flight's ID: ");
            int id = Convert.ToInt16(Console.ReadLine());
            for (i=0; i < 2; i++)
            {
                Console.Write(flightList[i].findFlight(id)); 
            }

            for (i = 0; i < 2; i++)
            {
                Console.WriteLine("Ticket ID: {0} 's details:\n", ticketList[i].ticketID);
                Console.Write(ticketList[i].getInfo(passengerList));
            }

            Console.Write("Enter Passenger's ID: ");
            id = Convert.ToInt16(Console.ReadLine());
            for (i = 0; i < 3; i++)
            {
                Console.Write(passengerList[i].getInfo(id));
            }

            Console.ReadLine();
        }
    }
}
