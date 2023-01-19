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
		public TransportType AcceptsTypes { get; set; }
		public double Lat { get; set; }
		public double Lon { get; set; }
		public int CityId { get; set; }
		public City? City { get; set; }
	}
}
