using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarLand.Models;
using StarLand.Services;
using StarLand.ViewModels;
using Microsoft.AspNetCore.Authorization;


namespace StarLand.Controllers
{
    public class OrderController : Controller
    {
        private IDataService<Planet> _planetService;
        
        public OrderController(IDataService<Planet> planetService)
        {
            _planetService = planetService;
        }
             
        [HttpGet]
        [Authorize(Roles ="Customer")]
        public IActionResult Payment(int planetId)
        {
            Planet planet = _planetService.GetSingle(p => p.PlanetId == planetId);
            OrderPaymentViewModel vm = new OrderPaymentViewModel
            {
                Name = planet.Name,
                TotalPrice = planet.Price,
                PlanetId = planet.PlanetId
            };
            return View(vm);
        }
        [HttpPost]
        [Authorize(Roles ="Customer")]
        [ValidateAntiForgeryToken]
        public IActionResult Payment(OrderPaymentViewModel vm)
        {                    
            if (ModelState.IsValid)
            {                
                Planet planet = _planetService.GetSingle(p => p.PlanetId == vm.PlanetId);
                planet.IsSold = 1;
                _planetService.Update(planet);
                return RedirectToAction("Placed", "Order", new { planetId = planet.PlanetId });
            }
            return View(vm);
        }

        [Authorize(Roles ="Customer")]
        public IActionResult Placed(int planetId)
        {
            Planet planet = _planetService.GetSingle(p => p.PlanetId == planetId);
            OrderPlacedViewModel vm = new OrderPlacedViewModel
            {
                Name = planet.Name,
                Picture = planet.Picture                
            };
            return View(vm);
        }
    }
}
