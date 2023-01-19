using System.Net;
using TravelAlly.Models;
using TransportType = TravelAlly.Models.TransportType;

namespace TravelAlly.ViewModels
{
	public class TransportViewModel
	{
		public String Carrier { get; set; }
		public TransportType Type {	get; set; }
		public WeekDay OperatesOnDays { get; set; }
		public List<String> StationPassingNames { get; set; }
		public List<Tuple<DateTime,	DateTime>> StationPassingTimes { get; set; }
	}
}
