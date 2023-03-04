using TravelAlly.Models;

namespace TravelAlly.ViewModels
{
	public class CountryPageViewModel
	{
		public Dictionary<string, string> SectionContentsDict { get; set; }
		public List<Station> Stations { get; set; }
		public List<Transport> TransportRoutes { get; set; }
	}
}
