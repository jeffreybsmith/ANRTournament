using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ANRTournament.Models
{
    public class NetrunnerDBDataSet
    {
        public Uri imageUrlTemplate { get; set; }

        public List<Card> data { get; set; }

        public int total { get; set; }

        public bool success { get; set; }

        public string version_number { get; set; }

        public DateTime last_updated { get; set; }
    }
}
