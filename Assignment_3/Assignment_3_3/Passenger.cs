using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Assignment_3_3
{
    class Passenger
    {
        public int id;
        String firstName, lastName, phoneNumber;
        ArrayList ticketList = new ArrayList();

        public Passenger(int id, String firstName, String lastName, String phoneNumber)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
        }

        public virtual void addTicket(Ticket ticket)
        {
            this.ticketList.Add(ticket);
        }

        public virtual String getInfo(int id)
        {
            if (id == this.id)
            {
                String tickets = "Tickets: \n";
                foreach (Ticket ticket in ticketList)
                {
                    tickets += ticket.toString();
                }
                return this.toString() + tickets;
            }
            else return null;
        }

        public String toString()
        {
            return "passenger's ID: " + id + ", First Name: " + firstName + ", Last Name: " + lastName + ", Phone Number: " + phoneNumber + "\n";
        }
    }
}
