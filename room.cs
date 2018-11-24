using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment_4_1
{
    public interface Iroom
    {
        String Search(int id, string value);
        int Number
        {
            get;
            set;
        }
        String Area
        {
            get;
            set;
        }
        String Type
        {
            get;
            set;
        }
        String Description
        {
            get;
            set;
        }
        double Price
        {
            get;
            set;
        }
    }
    class room : Iroom
    {
        private int number;
        private String area, type, description;
        private double price;

        public room(int number, string area, string type, string description, double price)
        {
            this.number = number;
            this.area = area;
            this.type = type;
            this.description = description;
            this.price = price;
        }

        public string Area
        {
            get
            {
                return area;
            }
            set
            {
                if (value.Length != 0)
                    area = value;
                area = "unknown";
            }
        }
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                if (value.Length != 0)
                    type = value;
                type = "unknown";
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                if (value.Length != 0)
                    description = value;
                description = "unknown";
            }
        }

        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                if (value != 0)
                    number = value;
                number = 0;
            }
        }

        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value != 0)
                    price = value;
                price = 0;
            }
        }


    }
}
