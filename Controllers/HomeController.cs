using System;
using System.Diagnostics;
using System.Linq;
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
            // Make the Bingo grid
            var grid = Enumerable.Range(0, 5)
                .Select((c, i) => Enumerable.Range(0, 19).Select(d => d + i * 20 + 1).Shuffle().ToArray().Take(5).ToArray())
                .ToArray();
            
            // Flatten the grid for storage in the DB
            var flattenedGrid = Enumerable.Range(0, 5).SelectMany(c => Enumerable.Range(0, 5).Select(d => grid[d][c]))
                .ToList();

            // Remove the free space
            flattenedGrid.RemoveAt(12);
            
            // Generate the card
            var card = new BingoCard {
                DateCreated = DateTime.Now,
                Numbers = flattenedGrid
                    .Select((c, i) => new BingoNumber {
                        Number = c,
                        Order = i
                    })
                    .ToArray()
            };

            _context.Cards.Add(card);
            _context.SaveChanges();

            return RedirectToAction("Show", "Cards", new { id = card.CardNumber});
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
