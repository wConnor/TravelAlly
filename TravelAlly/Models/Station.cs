using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TravelAlly.Models
{
	public class Station
	{
		public Station() { }
		public Station(int id, string? name, TransportType acceptsTypes, double lat, double lon, int cityId, City? city)
		{
			Id = id;
			Name = name;
			AcceptsTypes = acceptsTypes;
			Lat = lat;
			Lon = lon;
			CityId = cityId;
			City = city;
		}

		[Key]
		public int Id { get; set; }
		public String? Name { get; set; }
		[DisplayName("Accepts Transport Types")]
		public TransportType AcceptsTypes { get; set; }
		[DisplayName("Latitude")]
		public double Lat { get; set; }
		[DisplayName("Longitude")]
		public double Lon { get; set; }
		public int CityId { get; set; }
		public City? City { get; set; }
	}
}
