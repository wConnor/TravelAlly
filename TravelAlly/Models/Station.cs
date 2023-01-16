using System.ComponentModel.DataAnnotations;

namespace TravelAlly.Models
{
	public class Station
	{
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
