using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ANRTournament.Models;
using Microsoft.Data.Entity;
using ANRTournament.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ANRTournament.Controllers
{
    public class HomeController : Controller
    {

        private ANRTournamentContext _context;
        private ICardsService _cardService;
        public HomeController(ANRTournamentContext context, ICardsService cardsService )
        {
            _context = context;
            _cardService = cardsService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var players = _context.Players
                .OrderBy(p => p.LastName)
                .ToArray();

            return View(players);
        }

        public async Task<IActionResult> Cards()
        {
            var cards = await _cardService.GetCardsAsync(true);
            return View(cards.Cards.ToArray<Card>());
        }
    }
}
