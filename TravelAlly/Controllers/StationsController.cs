using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelAlly.Data;
using TravelAlly.Models;
using TravelAlly.ViewModels;

namespace TravelAlly.Controllers
{
	public class StationsController : Controller
	{
		private readonly TravelAllyContext _context;

		public StationsController(TravelAllyContext context)
		{
			_context = context;
		}

		// GET: Stations
		public async Task<IActionResult> Index()
		{
			var travelAllyContext = _context.Station.Include(s => s.City);
			return View(await travelAllyContext.ToListAsync());
		}

		// GET: Stations/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.Station == null)
			{
				return NotFound();
			}

			var station = await _context.Station
				.Include(s => s.City)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (station == null)
			{
				return NotFound();
			}

			return View(station);
		}

		// GET: Stations/Create
		public IActionResult Create()
		{
			CreateStationViewModel csvm = new CreateStationViewModel();
			csvm.CityNamesList = new SelectList(_context.City.Select(c => c.Name).ToList());

			return View(csvm);
		}

		// POST: Stations/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Name,AcceptsTypes,Lat,Lon,CityName")] CreateStationViewModel csvm)
		{
			Station	Station	= new Station();
			Station.Name = csvm.Name;
			Station.AcceptsTypes = csvm.AcceptsTypes;
			Station.Lat = csvm.Lat;
			Station.Lon = csvm.Lon;
			Station.City = await _context.City.FirstOrDefaultAsync(c => c.Name == csvm.CityName);

			if (ModelState.IsValid)
			{
				_context.Add(Station);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}

			return View(Station);
		}

		// GET: Stations/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.Station == null)
			{
				return NotFound();
			}


			var Station = await _context.Station.FindAsync(id);
			if (Station == null)
			{
				return NotFound();
			}

			CreateStationViewModel csvm = new CreateStationViewModel();

			csvm.StationId = Station.Id;
			csvm.Name = Station.Name;
			csvm.Lat = Station.Lat;
			csvm.Lon = Station.Lon;
			csvm.AcceptsTypes = Station.AcceptsTypes;
			// TODO: fix CityName field to have the default value of Station.Name.
			csvm.CityNamesList = new SelectList(_context.City.Select(c => c.Name).ToList(), Station.Name);

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
			if (id != csvm.StationId)
			{
				return NotFound();
			}

			var Station = await _context.Station.FindAsync(csvm.StationId);
			var City = await _context.City.FirstOrDefaultAsync(c => c.Name == csvm.CityName);

			Station.Name = csvm.Name;
			Station.Lat = csvm.Lat;
			Station.Lon = csvm.Lon;
			Station.AcceptsTypes = csvm.AcceptsTypes;
			Station.City = City;

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(Station);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!StationExists(csvm.StationId))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}

			return View(Station);
		}

		// GET: Stations/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.Station == null)
			{
				return NotFound();
			}

			var station = await _context.Station
				.Include(s => s.City)
				.FirstOrDefaultAsync(m => m.Id == id);
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
			if (_context.Station == null)
			{
				return Problem("Entity set 'TravelAllyContext.Station' is null.");
			}
			var station = await _context.Station.FindAsync(id);
			if (station != null)
			{
				_context.Station.Remove(station);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool StationExists(int id)
		{
			return _context.Station.Any(e => e.Id == id);
		}
	}
}
