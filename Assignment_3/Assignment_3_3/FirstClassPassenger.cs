using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3_3
{
    class FirstClassPassenger : EconomyPassenger
    {
        String mealMenu;
        private double bonus = 0.0;
        public double Bonus
        {
            get
            {
                return bonus;
            }
        }

        public FirstClassPassenger(int id, string firstName, string lastName, string phoneNumber, int luggageWeight, String mealMenu) : base(id, firstName, lastName, phoneNumber, luggageWeight)
        {
            this.mealMenu = mealMenu;
        }

        public override void addTicket(Ticket ticket)
        {
            base.addTicket(ticket);
            bonus += ticket.getPrice(ticket.ticketID) * 0.02;
        }

        public override string getInfo(int id)
        {
            return base.getInfo(id) + "\nMeal Menu: " + mealMenu + "Bonus: " + this.Bonus;
        }
    }
}
