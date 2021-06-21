using System;
using System.Collections.Generic;
using System.Text;
using DPS926_A2.Model.Players;

namespace DPS926_A2.Model.Teams
{
    public class Team
    {
        public int id { get; set; }
        public string name { get; set; }
        public string full_name { get; set; }
        public string city { get; set; }
        public string division { get; set; }
        public string conference { get; set; }
        public string abbreviation { get; set; }
    }
}
