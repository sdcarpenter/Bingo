using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bingo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Bingo.Controllers
{
    public class GamesController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BingoContext _context;

        public GamesController(ILogger<HomeController> logger, BingoContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Show(int id)
        {
            var game = _context.Games
                .Include(c => c.Numbers)
                .Single(c => c.GameNumber == id);

            return View(game);
        }

        [HttpPost]
        public IActionResult DrawNumber(int id)
        {
            var game = _context.Games
                .Include(c => c.Numbers)
                .Single(c => c.GameNumber == id);
            
            var pick = Enumerable.Range(1, 99)
                .GroupJoin(game.Numbers.Select(d => d.Number),
                    c => c,
                    c => c,
                    (availableNumber, pickedNumber) => new
                    {
                        AvailableNumber = availableNumber,
                        PickedNumber = !pickedNumber.Any() ? null : (int?) pickedNumber.FirstOrDefault()
                    })
                .Where(c => c.PickedNumber == null)
                .Shuffle()
                .First()
                .AvailableNumber;

            _context.GameNumbers.Add(new BingoGameNumber
            {
                Number = pick,
                GameNumber = game.GameNumber
            });

            _context.SaveChanges();


            return RedirectToAction("Show", new { id = game.GameNumber });
        }

        public IActionResult Index()
        {
            var game = new BingoGame
            {
                DateCreated = DateTime.Now
            };

            _context.Games.Add(game);
            _context.SaveChanges();

            return RedirectToAction("show", new {id = game.GameNumber });
        }
    }
}
