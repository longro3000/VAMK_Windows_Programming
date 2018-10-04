using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable Concerts = new Hashtable();

            Concert Obj = new Concert("BTS", "Sai Gon", "11.11.2018", "7 PM", 100);
            Concerts.Add(Obj.getTitle(), Obj.toString());

            Obj.replace("EXID", "Sai Gon", "11.11.2017", "6 PM", 125);
            Concerts.Add(Obj.getTitle(), Obj.toString());

            Obj.replace("MTP", "Sai Gon", "11.11.2019", "7 PM", 120);
            Concerts.Add(Obj.getTitle(), Obj.toString());

            Obj.replace("BigBang", "Ha Noi", "11.11.2020", "6 PM", 150);
            Concerts.Add(Obj.getTitle(), Obj.toString());

            Obj.replace("BichPhuong", "Helsinki", "11.11.2017", "6 PM", 125);
            Concerts.Add(Obj.getTitle(), Obj.toString());


            Concert Temp = new Concert("BTS", "Sai Gon", "11.11.2018", "7 PM", 100);

            Console.WriteLine("Concert detail: " + Temp.toString());

            Temp++;

            Console.WriteLine("Concert price increase: " + Temp.toString());

            Temp--;

            Console.WriteLine("Concert price decrease: " + Temp.toString());

            Console.WriteLine("BTS concert price < BichPhuong concert price: " + (Temp < Obj));

            Console.WriteLine("BTS concert price > BichPhuong concert price: " + (Temp > Obj));

            Console.ReadLine();
        }
    }
}
