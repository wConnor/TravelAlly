using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAlly.Models
{
	public class Transport
	{
		public Transport() { }

		[Key]
		public int Id { get; set; }
		public String? RouteCode { get; set; }
		public TransportType Type { get; set; }
		public RouteType RouteType { get; set; }
		public String? Carrier { get; set; }
		[DisplayName("Operates On Days")]
		public WeekDay? OperatesOnDays { get; set; }
		[DisplayName("Stations Served (Station, Arrival : Departure)")]		
		public virtual List<StationPassing>? StationPassings { get; set; }
	}
}
