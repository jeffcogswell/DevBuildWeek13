﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CardAPIProject.Models;
using System.Net.Http;

namespace CardAPIProject.Controllers
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

        public async Task<IActionResult> Cards(string deck_id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://deckofcardsapi.com/");

            if (deck_id == null)
            {
                var response1 = await client.GetAsync("/api/deck/new/shuffle/?deck_count=1");
                Cards info = await response1.Content.ReadAsAsync<Cards>();
                deck_id = info.deck_id;
            }

            var response = await client.GetAsync($"/api/deck/{deck_id}/draw/?count=5");
            Cards cards = await response.Content.ReadAsAsync<Cards>();
            return View(cards);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
