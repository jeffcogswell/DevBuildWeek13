using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ApiCallDemo.Models;
using System.Net.Http;

namespace ApiCallDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Test()
        {
            /*
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://catfact.ninja");
            var response = await client.GetAsync("/fact");
            var catstring = await response.Content.ReadAsStringAsync();
            return Content(catstring);
            */

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://catfact.ninja");
            var response = await client.GetAsync("/fact");
            Cat info = await response.Content.ReadAsAsync<Cat>();
            return View(info);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
