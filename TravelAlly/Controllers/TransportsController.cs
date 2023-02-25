﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelAlly.Data;
using TravelAlly.Models;

namespace TravelAlly.Controllers
{
	public class TransportsController : Controller
	{
		private readonly TravelAllyContext _context;

		public TransportsController(TravelAllyContext context)
		{
			_context = context;
		}

		// GET: Transports
		public async Task<IActionResult> Index()
		{
			var travelAllyContext = _context.Transport
				.Include(t => t.StationPassings)
				.ThenInclude(sp => sp.Station);

			return View(await travelAllyContext.ToListAsync());
		}

		// GET: Transports/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.Transport == null)
			{
				return NotFound();
			}

			var transport = await _context.Transport
				.FirstOrDefaultAsync(m => m.Id == id);
			if (transport == null)
			{
				return NotFound();
			}

			return View(transport);
		}

		// GET: Transports/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Transports/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Type,Carrier,OperatesOnDays,RouteType")] Transport transport)
		{
			if (ModelState.IsValid)
			{
				_context.Add(transport);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(transport);
		}

		// GET: Transports/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.Transport == null)
			{
				return NotFound();
			}

			var transport = await _context.Transport.FindAsync(id);
			if (transport == null)
			{
				return NotFound();
			}

			return View(transport);
		}

		// POST: Transports/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Carrier,OperatesOnDays,RouteType")] Transport transport)
		{
			if (id != transport.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(transport);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!TransportExists(transport.Id))
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
			return View(transport);
		}

		// GET: Transports/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.Transport == null)
			{
				return NotFound();
			}

			var transport = await _context.Transport
				.FirstOrDefaultAsync(m => m.Id == id);
			if (transport == null)
			{
				return NotFound();
			}

			return View(transport);
		}

		// POST: Transports/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.Transport == null)
			{
				return Problem("Entity set 'TravelAllyContext.Transport' is null.");
			}
			var transport = await _context.Transport.FindAsync(id);
			if (transport != null)
			{
				_context.Transport.Remove(transport);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool TransportExists(int id)
		{
			return _context.Transport.Any(e => e.Id == id);
		}
	}
}
