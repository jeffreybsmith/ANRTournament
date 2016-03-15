using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace ANRTournament.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int MatchPoints { get; set; }
        public Identity Corp { get; set; }
        public Identity Runner { get; set; }
    }
}
