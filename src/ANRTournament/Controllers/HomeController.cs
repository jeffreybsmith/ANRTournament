using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ANRTournament.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ANRTournament.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            Player newPlayer = new Player();
            newPlayer.FirstName = "Jeff";
            newPlayer.LastName = "Smith";
            newPlayer.MatchPoints = 0;
            newPlayer.Corp = new Identity("Blue Sun");
            newPlayer.Runner = new Identity("Reina Roja");

            return View(newPlayer);
        }
    }
}
