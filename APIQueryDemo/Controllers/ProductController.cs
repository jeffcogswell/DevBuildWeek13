using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIQueryDemo.Controllers
{
    [Route("Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public List<string> Get(string word)
        {
            List<string> result = new List<string>();
            result.Add("Root");
            result.Add("Path");
            if (word != null)
            {
                result.Add(word);
            }
            return result;
        }

        [HttpGet("Demo")]
        public List<string> Demo(string word)
        {
            List<string> result = new List<string>();
            result.Add("Hello");
            result.Add("World");
            result.Add(word);
            return result;
        }


        // Two ways into this function
        // https://localhost:44320/Product/Demo/test
        // https://localhost:44320/Product/Demo/test?word=abc

        [HttpGet("Demo/{userid}")]
        public List<string> Demo2(string userid, string word)
        {
            List<string> result = new List<string>();
            result.Add("Another");
            result.Add("Test");
            result.Add(userid);
            if (word != null)
            {
                result.Add(word);
            }
            return result;
        }

        [HttpGet("Emptylist")]
        public List<string> EmptyList()
        {
            List<string> result = new List<string>();
            return result;
        }

        [HttpGet("Emptyobject")]
        public Object EmptyObject()
        {
            return new { };
            // Or you can return anything you want like this:
            //return new { somemember = 3, another = "hello" };

            // Or you can return a specific type of object
            //WeatherForecast weath = new WeatherForecast() { Summary = "test" };
            //return weath;
        }
    }
}
