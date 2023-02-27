using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
		public async Task<IActionResult> FindRoute([Bind("Origin,Destination")] RoutePlannerRequestViewModel ViewModel)
		{
			_service.CalculateRoutes(ViewModel.Origin, ViewModel.Destination);
			return NotFound();
		}
	}
}
