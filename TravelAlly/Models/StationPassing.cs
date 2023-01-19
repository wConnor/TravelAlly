using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAlly.Models
{
	public class StationPassing
	{
		[Key]
		public int Id { get; set; }
		public int StationId { get; set; }
		public Station? Station { get; set; }
		public int TransportId { get; set; }
		[ForeignKey("TransportId")]
		public Transport? Transport { get; set; }
		[DataType(DataType.Time)]
		public DateTime? ArrivalTime { get; set; }
		[DataType(DataType.Time)]
		public DateTime? DepartureTime { get; set; }
	}
}
