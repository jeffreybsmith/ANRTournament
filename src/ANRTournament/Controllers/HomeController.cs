using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ANRTournament.Models;
using Microsoft.Data.Entity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ANRTournament.Controllers
{
    public class HomeController : Controller
    {

        private ANRTournamentContext _context;
        public HomeController(ANRTournamentContext context)
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
    }
}
