using TravelAlly.Models;

namespace TravelAlly.ViewModels
{
	public class RoutePlannerResultViewModel
	{
		public List<Transport> Routes { get; set; }
		public string OriginCityName {	get; set; }
		public string DestinationCityName { get; set; }
		public DateTime DepartureTime { get; set; }
	}
}
