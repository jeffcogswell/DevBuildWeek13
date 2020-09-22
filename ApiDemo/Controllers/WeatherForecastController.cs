using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiDemo.Controllers
{
    [ApiController]
    [Route("weather")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("Test")]
        public string Test()
        {
            return "Hello";
        }

        [HttpGet("Test/{id}")]
        public List<string> Test(string id)
        {
            List<string> res = new List<string>();
            res.Add("Hello");
            res.Add("There");
            res.Add("Everybody");
            res.Add(id);

            return res;
        }

        [HttpGet("Employee/{userid}")]
        public Employee Emp(string userid)
        {
            Employee emp1 = new Employee() { Userid = userid, Department = "IT", Name = "Fred Smith " };
            return emp1;
        }
    }
}
