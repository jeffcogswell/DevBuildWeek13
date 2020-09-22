using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ApiCallDemo1.Models;
using System.Net.Http;

namespace ApiCallDemo1.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Test()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://catfact.ninja");
            var response = await client.GetAsync("/fact");
            Cat info = await response.Content.ReadAsAsync<Cat>();
            return Content(info.fact);
        }

        public IActionResult Test1()
        {
            Response.Headers["x-grandcircus-test"] = "test header";
            Response.ContentType = "text/html";
            return Content("<b>Hello</b>");
        }

        public IActionResult Test2()
        {
            return RedirectToAction("Test3");
        }

        public IActionResult Test3()
        {
            return Content("Hello");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
