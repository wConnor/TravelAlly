using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TravelAlly.Data;
using TravelAlly.Models;
using TravelAlly.Services;
using TravelAlly.ViewModels;

namespace TravelAlly.Controllers
{
	public class HomeController : Controller
	{
//		private readonly ILogger<HomeController> _logger;
		private readonly TransportService _transportService;
		private readonly StationService _stationService;

		public HomeController(TransportService transportService, StationService stationService)
		{
			_transportService = transportService;
			_stationService = stationService;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Map()
		{
			MapOutputViewModel ViewModel = new MapOutputViewModel();
			ViewModel.Stations = _stationService.ListStations().ToList();
			ViewModel.TransportRoutes = _transportService.ListTransports().ToList();

			return View(ViewModel);
		}

		public IActionResult EditSection()
		{
			return View();
		}

		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSection(int id)
        {
			// implement.
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
			var ViewModel = new MapOutputViewModel();
			ViewModel.Stations = _stationService.ListStationsByCountry("United Kingdom").ToList();
			ViewModel.TransportRoutes = _transportService.ListTransportsByCountry("United Kingdom").ToList();

			return View("~/Views/Home/Europe/UnitedKingdom.cshtml", ViewModel);
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