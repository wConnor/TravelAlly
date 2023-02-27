using System.ComponentModel.DataAnnotations;

namespace TravelAlly.Models
{
	public class City
	{
		public City() {	}
		public City(int id, string? name, double lat, double lon, /*TimeZoneInfo timeZone*/ string? country, string? continent)
		{
			Id = id;
			Name = name;
			Lat = lat;
			Lon = lon;
			//TimeZone = timeZone;
			Country = country;
			Continent = continent;
		}

		[Key]
		public int Id { get; set; }
		public string? Name { get; set; }
		public double Lat { get; set; }
		public double Lon { get; set; }
		//public TimeZoneInfo TimeZone { get; set; }
		public string? Country { get; set; }
		public string? Continent { get; set; }
	}
}
