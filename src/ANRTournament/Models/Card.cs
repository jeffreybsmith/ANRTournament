using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ANRTournament.Models
{
    public class Card
    {
        public string Code { get; set; }

        public int Deck_Limit { get; set; }

        public string Type_Code { get; set; }

        public string Title { get; set; }

        public string SubType { get; set; }

        public string Faction_Code { get; set; }

        public int Faction_Cost { get; set; }

        public bool Uniqueness { get; set; }

        public string Side_Code { get; set; }

        public string Imagesrc { get; set; }

    }
}
