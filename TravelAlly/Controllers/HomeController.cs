using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;
using TravelAlly.Data;
using TravelAlly.Models;
using TravelAlly.Services;
using TravelAlly.ViewModels;

namespace TravelAlly.Controllers
{
	public class HomeController : Controller
	{
		//		private readonly ILogger<HomeController> _logger;
		private readonly SectionEntryService _sectionEntryService;
		private readonly TransportService _transportService;
		private readonly StationService _stationService;

		public HomeController(SectionEntryService sectionEntryService, TransportService transportService, StationService stationService)
		{
			_sectionEntryService = sectionEntryService;
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

		public IActionResult EditSection(string Page, string Section)
		{
			EditSectionViewModel ViewModel = new EditSectionViewModel();
			ViewModel.Page = Page;
			ViewModel.Section = Section;
			ViewModel.Contents = _sectionEntryService.GetSectionEntryByPageSection(ViewModel.Page, ViewModel.Section).Contents;

			return View(ViewModel);
		}

		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSection([Bind("Page,Section,Contents")] EditSectionViewModel ViewModel)
        {
			SectionEntry SE = new SectionEntry();
			SE.Section = ViewModel.Section;
			SE.Page = ViewModel.Page;
			SE.Edited = DateTime.Now;
			SE.Contents = ViewModel.Contents;
			SE.EditedByUser = User.FindFirst(ClaimTypes.NameIdentifier).Value;

			_sectionEntryService.CreateSectionEntry(SE);
            return RedirectToAction(SE.Page);
        }

		public IActionResult History(string Page, string Section)
		{
			IEnumerable<SectionEntry> SectionEntries = _sectionEntryService.ListSectionEntriesByPageSection(Page, Section);

			return View(SectionEntries);
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
			var ViewModel = new CountryPageViewModel();
			ViewModel.Stations = _stationService.ListStationsByCountry("United Kingdom").ToList();
			ViewModel.TransportRoutes = _transportService.ListTransportsByCountry("United Kingdom").ToList();
			ViewModel.SectionContentsDict = new Dictionary<string, string>();

            SectionEntry CountryEntry = _sectionEntryService.GetSectionEntryByPageSection("UnitedKingdom", "Country");
            SectionEntry TrainEntry = _sectionEntryService.GetSectionEntryByPageSection("UnitedKingdom", "Train");
			SectionEntry CoachEntry = _sectionEntryService.GetSectionEntryByPageSection("UnitedKingdom", "Coach");

			ViewModel.SectionContentsDict.Add("Country", CountryEntry.Contents);
            ViewModel.SectionContentsDict.Add("Train", TrainEntry.Contents);
			ViewModel.SectionContentsDict.Add("Coach", CoachEntry.Contents);

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