using Microsoft.AspNetCore.Mvc.Rendering;

namespace TravelAlly.ViewModels
{
	public class RoutePlannerRequestViewModel
	{
		public SelectList CityNames { get; set; }
		public string Origin { get; set; }
		public string Destination { get; set; }
		public DateTime DepartureTime { get; set; }
	}
}
