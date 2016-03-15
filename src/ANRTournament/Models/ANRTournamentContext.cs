using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ANRTournament.Models
{
    public class ANRTournamentContext : DbContext
    {
        public DbSet<Player> Players { get; set; }

        public DbSet<Identity> Identities { get; set; }

    }

}
