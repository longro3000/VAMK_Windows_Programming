using System;

using System.Collections.Generic;

using System.Text;

namespace InterfaceDemo

{

    //Here we define interface IPerson

    public interface IPerson

    {

        //These are method prototypes

        string GetName(int id);

        bool Search(string name);

        //This is the property

        string Name

        {

            get;

            set;

        }

        //This is another property

        int ID

        {

            get;

            set;

        }

    }

    //This is interface ICustomer, which inherits IPerson

    public interface ICustomer : IPerson

    {

        //This is the method prototype

        void AddDebit(float debit);

        //This is the property

        float Debit

        {

            set;

        }

    }

    //This is class OrdinaryCustomer, which inherits interface ICustomer

    class OrdinaryCustomer : ICustomer

    {

        private string name;

        private int id;

        private float debit;


        public OrdinaryCustomer()
        {
            this.name = "Name not known";
            this.id = 0;
            this.debit = 0.0f;
        }

        public OrdinaryCustomer(string name, int id, float debit)
        {
            this.name = name;
            this.id = id;
            this.debit = debit;
        }
        //These are the implementation of methods

        public string GetName(int id)

        {

            return name;

        }

        public bool Search(string name)

        {

            if (this.name.Equals(name))

                return true;

            else

                return false;

        }

        public void AddDebit(float debit)

        {

            this.debit += debit;

        }

        public string Name

        {

            get

            {

                return name;

            }

            set

            {

                if (value.Length >= 5 && value.Length <= 10)
                    name = value;
                else
                    name = "Name not defined";

            }

        }

        public int ID

        {

            get

            {

                return id;

            }

            set

            {
                if (value > 0)
                    id = value;
                else
                    id = 0;

            }

        }

        public float Debit

        {

            set

            {

                debit = value;

            }

        }

        public override string ToString()

        {

            return "Customer's info: " + name + " " + id + " " + debit;

        }

    }

    class Program

    {

        static void Main(string[] args)

        {

            OrdinaryCustomer oc = new OrdinaryCustomer();

            oc.ID = 100;

            oc.Name = "Charlie";

            oc.AddDebit(1234.5f);

            Console.WriteLine(oc);

            Console.WriteLine("Customer Charlie foud? " + oc.Search("Charlie"));

            Console.ReadLine();

        }

    }

}
