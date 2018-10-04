using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_1
{
    class Concert
    {
        string title;
        string location;
        string date;
        string time;
        int price;

        public Concert(string title, string location, string date, string time, int price)
        {
            this.title = title;
            this.location = location;
            this.date = date;
            this.time = time;
            this.price = price;
        }

        public string getTitle()
        {
            return this.title;
        }
        public void replace(string title, string location, string date, string time, int price)
        {
            this.title = title;
            this.location = location;
            this.date = date;
            this.time = time;
            this.price = price;
        }

        public static bool operator <(Concert Obj1, Concert Obj2)
        {
            if (Obj1.price < Obj2.price)
                return true;
            return false;
        }
        public static bool operator >(Concert Obj1, Concert Obj2)
        {
            if (Obj1.price > Obj2.price)
                return true;
            return false;
        }


        public static Concert operator ++(Concert Obj)
        {
            return new Concert(Obj.title, Obj.location, Obj.date, Obj.time, (Obj.price + 5));
        }

        public static Concert operator --(Concert Obj)
        {
            return new Concert(Obj.title, Obj.location, Obj.date, Obj.time, (Obj.price - 5));
        }

        public string toString()
        {
            return "Title: " + this.title + "\n Location: " + this.location + "\n Date: " + this.date + "\n Time: " + this.time + "\n Price: " + this.price;
        }
    }
}

