using Microsoft.AspNetCore.Mvc;
using CarRental.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarRental.Controllers
{
    public class CarsController : Controller
    {
        private static readonly List<Car> availableCars = new List<Car>
        {
            new Car { Id = 1, Name = "Alto", PricePerDay = 3000m },
            new Car { Id = 2, Name = "Corolla", PricePerDay = 6000m },
            new Car { Id = 3, Name = "Civic", PricePerDay = 8000m }
        };

        private static readonly List<Car> bookedCars = new List<Car>();

        [HttpGet]
        public IActionResult Index()
        {
            return View(availableCars);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Book(int id)
        {
            var car = availableCars.FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                // Car not available, return to Index
                return RedirectToAction(nameof(Index));
            }

            availableCars.Remove(car);
            bookedCars.Add(car);

            return RedirectToAction(nameof(Booked));
        }

        [HttpGet]
        public IActionResult Booked()
        {
            return View(bookedCars);
        }
    }
}
