using System.ComponentModel.DataAnnotations;

namespace TravelAlly.Models
{
	public class Transport
	{
		[Key]
		public int Id { get; set; }
		public TransportType Type { get; set; }
		public String? Carrier { get; set; }
		[DataType(DataType.Time)]
		public DateTime DepartureTime { get; set; }
		[DataType(DataType.Time)]
		public DateTime ArrivalTime { get; set; }
		public ICollection<Station>? StationsServed { get; set; }

	}
}
