using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{
    [Route("Employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // My endpoints are:
        //        /Employee
        //        /Employee?department=IT
        //        /Employee/{userid}
        //
        // Examples:
        //        /Employee    will retrieve all employees
        //        /Employee?department=IT      will return a list of all employees in department IT
        //        /Employee/fred    will give detail on userid fred


        // This is the default route for /Employee
        [HttpGet]
        public List<Employee> Emp()
        {
            List<Employee> emps = new List<Employee>();
            Employee emp1 = new Employee() { Userid = "fred", Department = "IT", Name = "Fred Smith" };
            emps.Add(emp1);
            Employee emp2 = new Employee() { Userid = "julie", Department = "Acct", Name = "Julie Jones" };
            emps.Add(emp2);
            return emps;
        }

        // This is an example of a function that's not a route
        public int test()
        {
            return 1;
        }

        // Example query parameters
        // Example /api/test2?category=abc
        [HttpGet("/api/test2")]
        public string test2(string category)
        {
            return $"Testing category {category}";
        }


        [HttpGet("{userid}")]
        public Employee Emp(string userid)
        {
            Employee emp1 = new Employee() { Userid = userid, Department = "IT", Name = "Fred Smith" };
            return emp1;
        }

        [HttpGet("empty")]
        public Object empty()
        {
            Employee emp1 = new Employee() { Userid = "hello", Department = "IT", Name = "Fred Smith" };
            return emp1;
        }

        // The JSON for a list that has nothing in it is
        //    []
        // The JSON for an empty object is
        //    {}


    }
}
