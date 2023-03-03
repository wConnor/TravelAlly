using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelAlly.Data;
using TravelAlly.Models;
using TravelAlly.Services;

namespace TravelAlly.Controllers
{
    public class CitiesController : Controller
    {
        private readonly CityService _service;

        public CitiesController(CityService service)
        {
            _service = service;
        }

        // GET: Cities
        public async Task<IActionResult> Index()
        {
            return View(_service.ListCities());
        }

        // GET: Cities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var City = _service.GetCity(id);

            if (City == null)
            {
                return NotFound();
            }

            return View(City);
        }

        // GET: Cities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Lat,Lon,Country,Continent")] City city)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction(nameof(Index));
            }

            if (_service.CreateCity(city))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(city);
            }
        }

        // GET: Cities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var City = _service.GetCity(id);

            if (City == null)
            {
                return NotFound();
            }
            return View(City);
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Lat,Lon,Country,Continent")] City city)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction(nameof(Index));
            }

            if (id != city.Id)
            {
                return NotFound();
            }

            if (_service.UpdateCity(id, city))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(city);
            }
        }

        // GET: Cities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var City = _service.GetCity(id);

            if (City == null)
            {
                return NotFound();
            }

            return View(City);
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction(nameof(Index));
            }

            _service.DeleteCity(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
