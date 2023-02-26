using Microsoft.AspNetCore.Mvc.Rendering;
using TravelAlly.Models;

namespace TravelAlly.ViewModels
{
    public class CreateStationViewModel
    {
		public CreateStationViewModel() { }
		public CreateStationViewModel(int stationId, string name, TransportType acceptsTypes, double lat, double lon, string cityName, SelectList cityNamesList)
		{
			StationId = stationId;
			Name = name;
			AcceptsTypes = acceptsTypes;
			Lat = lat;
			Lon = lon;
			CityName = cityName;
			CityNamesList = cityNamesList;
		}

		public int StationId { get; set; }
        public String Name { get; set; }
        public TransportType AcceptsTypes { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public String CityName { get; set; }
        public SelectList CityNamesList { get; set; }
    }
}
