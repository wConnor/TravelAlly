using System.ComponentModel.DataAnnotations;

namespace TravelAlly.Models
{
	public class City
	{
		[Key]
		public int Id { get; set; }
		public string? Name { get; set; }
		public double Lat { get; set; }
		public double Lon { get; set; }
		public string? Country { get; set; }
	}
}
