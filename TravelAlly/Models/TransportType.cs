using System.ComponentModel.DataAnnotations;

namespace TravelAlly.Models
{
	[Flags]
	public enum TransportType
	{
		NONE = 0,
		RAILWAY = 1,
		SEA = 2,
		AIR = 4,
		ROAD = 8
	}
}
