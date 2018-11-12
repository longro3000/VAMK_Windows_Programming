using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4_2
{
    public interface Icustomer
    {
        String Search(int id, string value);
        int roomNumber
        {
            get;
            set;
        }
        int stayLength
        {
            get;
            set;
        }
        String Name
        {
            get;
            set;
        }
        String Address
        {
            get;
            set;
        }
        String ArrivalDate
        {
            get;
            set;
        }
    }
    class customer
    {
        private string name, address, arrivalDate;
        private int roomNumber, stayLength;

        public customer(string name, string address, string date, int number, int length)
        {
            this.name = name;
            this.address = address;
            this.arrivalDate = date;
            this.roomNumber = number;
            this.stayLength = length;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value.Length != 0)
                    name = value;
                name = "unknown";
            }
        }
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                if (value.Length != 0)
                    address = value;
                address = "unknown";
            }
        }
        public string ArrivalDate
        {
            get
            {
                return arrivalDate;
            }
            set
            {
                if (value.Length != 0)
                    arrivalDate = value;
                arrivalDate = "unknown";
            }
        }
        public int RoomNumber
        {
            get
            {
                return roomNumber;
            }
            set
            {
                if (value != 0)
                    roomNumber = value;
                roomNumber = 0;
            }
        }
        public int StayLength
        {
            get
            {
                return stayLength;
            }
            set
            {
                if (value != 0)
                    stayLength = value;
                stayLength = 0;
            }
        }
    }
}
