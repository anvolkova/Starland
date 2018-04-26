using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarLand.Models;

namespace StarLand.ViewModels
{
    public class PlanetListViewModel
    {
        public IEnumerable<Planet> Planets { get; set; }
        public string MinPrice { get; set; }
        public string MaxPrice { get; set; }
    }
}
