using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3_3
{
    class EconomyPassenger : Passenger
    {
            int luggageWeight;
            public EconomyPassenger(int id, String firstName, String lastName, String phoneNumber, int luggageWeight) : base(id, firstName, lastName, phoneNumber)
            {
                this.luggageWeight = luggageWeight;
            }

        public override string getInfo(int id)
        {
            return base.getInfo(id) + "\nLuggage weight: " + this.luggageWeight;
        }
    }
}
