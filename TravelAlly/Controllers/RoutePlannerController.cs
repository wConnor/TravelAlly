using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using TravelAlly.Models;
using TravelAlly.Services;
using TravelAlly.ViewModels;

namespace TravelAlly.Controllers
{
	public class RoutePlannerController : Controller
	{
		private readonly RoutePlannerService _service;

        public RoutePlannerController(RoutePlannerService service)
        {
			_service = service;			
        }

        public IActionResult Index()
		{
			RoutePlannerRequestViewModel ViewModel = new RoutePlannerRequestViewModel();
			ViewModel.CityNames = new SelectList(_service.ListCities());

			return View(ViewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> FindRoute([Bind("Origin,Destination,DepartureTime")] RoutePlannerRequestViewModel ViewModel)
		{
			if (ViewModel.Origin == ViewModel.Destination)
			{
				return NotFound();				
			}

			RoutePlannerResultViewModel	ResultViewModel	= new RoutePlannerResultViewModel();
			ResultViewModel.Transport = _service.CalculateRoutes(ViewModel.Origin, ViewModel.Destination, ViewModel.DepartureTime);
			ResultViewModel.OriginCityName = ViewModel.Origin;
			ResultViewModel.DestinationCityName = ViewModel.Destination;
			ResultViewModel.DepartureTime = ViewModel.DepartureTime;

			return View(ResultViewModel);
		}
	}
}
