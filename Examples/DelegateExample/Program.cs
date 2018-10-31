using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateExample
{
    delegate void ProcessMessageDelegate(string s);
    class Messages
    {
        public static void SayHello(string msg)
        {
            Console.WriteLine("  Good morning, {0}!", msg);
        }
        public void SayGoodbye(string msg)
        {
            Console.WriteLine("  Goodbye, {0}!", msg);
        }
    }

    class Program
    {
        public static void Main()
        {
            ProcessMessageDelegate pmd1, pmd2, pmd3, pmd4;

            //Here we create the delegate object pmd1 that references
            // the method SayHello:
            pmd1 = new ProcessMessageDelegate(Messages.SayHello);

            //Here we create an instance of Messages.
            Messages msg = new Messages();

            //Here we create the delegate object pmd2 that references
            //the method SayGoodbye:
            pmd2 = new ProcessMessageDelegate(msg.SayGoodbye);
            //Here we compose delegates pmd1 and pmd2
            pmd3 = pmd1 + pmd2;

            //Here we remove pmd2 from the composed delegate, leaving pmd3,
            // which calls only the method SayGoodbye:
            pmd4 = pmd3 - pmd2;

            Console.WriteLine("Invoking delegate pmd1:");
            pmd1("pmd1");
            Console.WriteLine("Invoking delegate pmd2:");
            pmd2("pmd2");
            Console.WriteLine("Invoking delegate pmd3:");
            pmd3("pmd3");
            Console.WriteLine("Invoking delegate pmd4:");
            pmd4("pmd4");
            Console.ReadLine();
        }
    }
}
