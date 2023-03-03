using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelAlly.Data;
using TravelAlly.Models;
using TravelAlly.Services;
using TravelAlly.ViewModels;

namespace TravelAlly.Controllers
{
	public class StationsController : Controller
	{
		private readonly StationService _service;
		private readonly CityService _cityService;

		public StationsController(StationService service, CityService cityService)
		{
			_service = service;
			_cityService = cityService;
		}

		// GET: Stations
		public async Task<IActionResult> Index()
		{
			return View(_service.ListStations());
		}

		// GET: Stations/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var Station = _service.GetStation(id);

			if (Station == null)
			{
				return NotFound();
			}

			return View(Station);
		}

		// GET: Stations/Create
		public IActionResult Create()
		{
			CreateStationViewModel csvm = new CreateStationViewModel();
			csvm.CityNamesList = new SelectList(_cityService.ListCityNames());

			return View(csvm);
		}

		// POST: Stations/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Name,AcceptsTypes,Lat,Lon,CityName")] CreateStationViewModel csvm)
		{
			if (!User.Identity.IsAuthenticated)
			{
				return RedirectToAction(nameof(Index));				
			}

			Station Station = new Station();
			Station.Name = csvm.Name;
			Station.AcceptsTypes = csvm.AcceptsTypes;
			Station.Lat = csvm.Lat;
			Station.Lon = csvm.Lon;
			Station.City = _cityService.GetCityByName(csvm.CityName);

			if (_service.CreateStation(Station))
			{
				return RedirectToAction(nameof(Index));
			}
			else
			{
				return View(Station);
			}
		}

		// GET: Stations/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			var Station = _service.GetStation(id.Value);
			if (Station == null)
			{
				return NotFound();
			}

			CreateStationViewModel csvm = new CreateStationViewModel(Station.Id, Station.Name, Station.AcceptsTypes, Station.Lat, Station.Lon, null, new SelectList(_cityService.ListCityNames(), Station.Name));

			//csvm.StationId = Station.Id;
			//csvm.Name = Station.Name;
			//csvm.Lat = Station.Lat;
			//csvm.Lon = Station.Lon;
			//csvm.AcceptsTypes = Station.AcceptsTypes;
			//// TODO: fix CityName field to have the default value of Station.Name.
			//csvm.CityNamesList = new SelectList(_context.City.Select(c => c.Name).ToList(), Station.Name);

			return View(csvm);
		}

		// POST: Stations/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		//
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("StationId,Name,AcceptsTypes,Lat,Lon,CityName")] CreateStationViewModel csvm)
		{
			if (!User.Identity.IsAuthenticated)
			{
				return RedirectToAction(nameof(Index));
			}

			if (id != csvm.StationId)
			{
				return NotFound();
			}

			var Station = _service.GetStation(csvm.StationId);
			var City = _cityService.GetCityByName(csvm.CityName);

			Station.Name = csvm.Name;
			Station.Lat = csvm.Lat;
			Station.Lon = csvm.Lon;
			Station.AcceptsTypes = csvm.AcceptsTypes;
            Station.City = City;

            if (_service.UpdateStation(id, Station))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(Station);
            }
		}

		// GET: Stations/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			var station = _service.GetStation(id);

			if (station == null)
			{
				return NotFound();
			}

			return View(station);
		}

		// POST: Stations/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (!User.Identity.IsAuthenticated)
			{
				return RedirectToAction(nameof(Index));
			}

			_service.DeleteStation(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
