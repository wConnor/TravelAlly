using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TravelAlly.Data;
using TravelAlly.Models;
using TravelAlly.ViewModels;

namespace TravelAlly.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly TravelAllyContext _context;

		//public HomeController(ILogger<HomeController> logger)
		//{
		//	_logger = logger;
		//}

		public HomeController(TravelAllyContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Map()
		{
			return View();
		}

		public IActionResult Europe()
		{
			return View("~/Views/Home/Europe/Index.cshtml");
		}

		public IActionResult Asia()
		{
			return View("~/Views/Home/Asia/Index.cshtml");
		}

		public IActionResult Japan()
		{
			return View("~/Views/Home/Asia/Japan.cshtml");
		}

		public IActionResult UnitedKingdom()
		{
			// to be changed to use CreateStationViewModel.
			var movm = new MapOutputViewModel();
			movm.Stations = _context.Station.Where(s => s.City.Country == "United Kingdom").ToList();
			movm.TransportRoutes = _context.Transport
				.Include(s => s.StationPassings)
				.ThenInclude(c => c.Station).ToList();
			return View("~/Views/Home/Europe/UnitedKingdom.cshtml", movm);
		}
		
		public IActionResult London()
		{
			return View("~/Views/Home/Europe/London.cshtml");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}