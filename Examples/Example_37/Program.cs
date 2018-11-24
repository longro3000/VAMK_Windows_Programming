using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
namespace Example_37
{
    //Here we declare that the Employee class gives us something to serialize
    [Serializable]
    class Employee
    {
        //Some attributes
        private int employeeNumber;
        private string employeeName;
        private decimal salary;
        public Employee()
        {
            employeeNumber = 0;
            employeeName = "not_knowmn";
            salary = 0.0m;
        }

        //Here we define the constructor
        public Employee(int employeeNumber, string employeeName, decimal salary)
        {
            this.employeeNumber = employeeNumber;
            this.employeeName = employeeName;
            this.salary = salary;
        }
        public int EmployeeNumber
        {
            get
            {
                return employeeNumber;
            }
        }
        public string FindEmployee(int employeeNumber)
        {
            if (this.employeeNumber == employeeNumber)
                return this.ToString();
            return "";
        }
        //Here we define the ToString method for the class
        public override string ToString()
        {
            return employeeNumber + " " + employeeName + " " + salary;
        }
    }
    class MainClass
    {
        static void Main(string[] args)
        {
            string filePath = @"U:\2017-2018\dotNet\employee.dat";
            //  string filePath = @"U:\2017-2018\dotNet\employee.xml";
            Employee[] employees = new Employee[3];
            employees[0] = new Employee(100, "Natalie", 2600.20m);
            employees[1] = new Employee(200, "Nima", 3800.20m);
            employees[2] = new Employee(300, "Shiva", 1800.20m);


            //Here we create a FileStream to hold the serialized employee so
            //that we append data to the end of the file.
            FileStream fileStream = new FileStream(filePath, FileMode.Append);

            //Here we use the CLR's binary formatting support
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            //SoapFormatter soapFormatter = new SoapFormatter();
            //Here we serialize the objects
            for (int i = 0; i < employees.Length; i++)
            {
                binaryFormatter.Serialize(fileStream, employees[i]);
                //soapFormatter.Serialize(fileStream, employees[i]);
                fileStream.Flush();
            }
            fileStream.Close();
            //Here we open a read stream to retrieve the serialized objects
            fileStream = new FileStream(filePath, FileMode.Open);
            object obj = null;
            int employeeNumber = 100;
            string result;
            for (;;)
            {
                try
                {
                    obj = binaryFormatter.Deserialize(fileStream);
                    //obj = soapFormatter.Deserialize(fileStream);
                    //Here we check whether obj is of type Employee 
                    //or not and if it is, we type cast it to Employee
                    //and call the GetEmployee() method.
                    if (obj is Employee)
                    {
                        result = ((Employee)obj).FindEmployee(employeeNumber);
                        if (!string.IsNullOrEmpty(result))
                            Console.WriteLine("Information of employee with employee number: " + employeeNumber + ":" + Environment.NewLine + result);
                    }


                }
                catch (EndOfStreamException e)
                {
                    Console.WriteLine("No object left!" + e.Message);
                }
                catch (SerializationException)
                {
                    // Console.WriteLine(e.Message);
                    break;
                }
                catch (System.Xml.XmlException)
                {
                    //Console.WriteLine(e.Message);
                    break;
                }

            }
            //Here we close the file read stream.
            fileStream.Close();

        }
    }
}
