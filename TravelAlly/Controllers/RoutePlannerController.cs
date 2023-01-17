using Microsoft.AspNetCore.Mvc;

namespace TravelAlly.Controllers
{
	public class RoutePlannerController : Controller
	{
        private readonly ILogger<RoutePlannerController> _logger;

        public RoutePlannerController(ILogger<RoutePlannerController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
		{
			return View();
		}
	}
}
