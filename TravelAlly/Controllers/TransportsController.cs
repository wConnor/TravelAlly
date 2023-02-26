using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelAlly.Data;
using TravelAlly.Models;
using TravelAlly.Repositories;
using TravelAlly.Services;

namespace TravelAlly.Controllers
{
	public class TransportsController : Controller
	{
		private TransportService _service;		

		public TransportsController(TransportService service)
		{
			_service = new TransportService(this.ModelState);
		}

		// GET: Transports
		public async Task<IActionResult> Index()
		{
			return View(_service.ListTransports());
		}

		// GET: Transports/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			var transport = _service.GetTransport(id);

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
			if (_service.CreateTransport(transport))
			{
				return RedirectToAction(nameof(Index));
			}
			else
			{
				return View(transport);
			}
		}

		// GET: Transports/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			var transport = _service.GetTransport(id);

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

			if (_service.UpdateTransport(id, transport))
			{
				return RedirectToAction(nameof(Index));
			}
			else if (!_service.TransportExists(transport.Id))
			{
				return NotFound();
			} 
			else
			{
				return View(transport);
			}
		}

		// GET: Transports/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			var transport = _service.GetTransport(id);
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
			_service.DeleteTransport(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
