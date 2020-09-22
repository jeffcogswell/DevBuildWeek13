using System;
using Newtonsoft.Json;

namespace JSONDemo1
{

    class Employee
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public Decimal Salary { get; set; }
    }

    class Program
    {

        static void ReadJSONString()
        {
            // Notice I'm using single quotes to make my life easier
            // Technically that's not correct :-)
            string json = "{ Name: 'Julie', Department: 'Development', Salary: 100000 }";
            Employee emp = JsonConvert.DeserializeObject<Employee>(json);
            Console.WriteLine(emp.Name);
            Console.WriteLine(emp.Department);
            Console.WriteLine(emp.Salary);
        }

        static void WriteJSONString()
        {
            Employee emp = new Employee() { Name = "Fred", Department = "Accounting", Salary = 80000 };
            string json = JsonConvert.SerializeObject(emp);
            Console.WriteLine(json);
        }

        static void Main(string[] args)
        {
            ReadJSONString();
            WriteJSONString();
        }
    }
}
