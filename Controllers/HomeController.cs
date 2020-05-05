using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bingo.Models;

namespace Bingo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BingoContext _context;

        public HomeController(ILogger<HomeController> logger, BingoContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var card = new BingoCard {
                DateCreated = DateTime.Now,
                Numbers = Enumerable.Range(1, 99)
                    .Shuffle()
                    .Select((c, i) => new BingoNumber {
                        Number = c,
                        Order = i
                    })
                    .Take(24)
                    .ToArray()
            };

            _context.Cards.Add(card);
            _context.SaveChanges();

            return RedirectToAction("Show", "Cards", new { id = card.CardNumber});
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
