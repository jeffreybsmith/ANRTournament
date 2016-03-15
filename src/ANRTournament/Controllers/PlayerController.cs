using ANRTournament.Models;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ANRTournament.Controllers
{
    public class PlayerController : Controller
    {

        private ANRTournamentContext _context;
        public PlayerController(ANRTournamentContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var players = _context.Players
                .OrderBy(p => p.LastName)
                .ToArray();


            return View(players);
        }
        [HttpGet]   
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Player player)
        {
            if (ModelState.IsValid) {
                _context.Players.Add(player);
                _context.SaveChanges();
            }

            return View();
        }
    }
}
