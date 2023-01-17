using Microsoft.AspNetCore.Mvc.Rendering;
using TravelAlly.Models;

namespace TravelAlly.ViewModels
{
    public class CreateStationViewModel
    {
        public int StationId { get; set; }
        public String Name { get; set; }
        public TransportType AcceptsTypes { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }

        public String CityName { get; set; }
        public SelectList CityNamesList;
    }
}
