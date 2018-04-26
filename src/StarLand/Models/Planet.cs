using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarLand.Models
{
    public class Planet
    {
        public int PlanetId { get; set; }
        public string Name { get; set; }
        public double Size { get; set; }
        public double Distance { get; set; }
        public double Price { get; set; }
        public string Picture { get; set; }
        public int IsSold { get; set; }
    }
}
