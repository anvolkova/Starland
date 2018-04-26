using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarLand.Models;
using StarLand.Services;
using StarLand.ViewModels;

namespace StarLand.Controllers
{
    public class PlanetController : Controller
    {
        private IDataService<Planet> _planetService;
        public PlanetController(IDataService<Planet> planetService)
        {
            _planetService = planetService;
        }
        public IActionResult List()
        {
            double minPrice, maxPrice;
            bool hasMin = Double.TryParse(HttpContext.Request.Query["MinPrice"].ToString(), out minPrice);
            bool hasMax = Double.TryParse(HttpContext.Request.Query["MaxPrice"].ToString(), out maxPrice);

            IEnumerable<Planet> planetList = _planetService.Query(p =>                                      
                    (p.IsSold == 0) && (!hasMin || p.Price >= minPrice) && (!hasMax || p.Price <= maxPrice));
           
            PlanetListViewModel vm = new PlanetListViewModel
            {
                Planets = planetList,
                MinPrice = hasMin ? minPrice.ToString() : "",
                MaxPrice = hasMax ? maxPrice.ToString() : "",
            };
            return View(vm);
        }
    }
}
