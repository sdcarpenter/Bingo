using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bingo.Models;
using Microsoft.EntityFrameworkCore;

namespace Bingo.Controllers
{
    public class CardsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BingoContext _context;

        public CardsController(ILogger<HomeController> logger, BingoContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Show(int id)
        {
            var card = _context.Cards
                .Include(c => c.Numbers)
                .Single(c => c.CardNumber == id);
            return View(card);
        }
    }
}