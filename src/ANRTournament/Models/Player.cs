using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ANRTournament.Models
{
    public class Player
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int MatchPoints { get; set; }
        public Identity Corp { get; set; }
        public Identity Runner { get; set; }
    }
}
