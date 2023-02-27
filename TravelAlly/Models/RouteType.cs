using System.ComponentModel.DataAnnotations;

namespace TravelAlly.Models
{
	[Flags]
	public enum RouteType
	{
		[Display(Name = "Domestic")]
		DOMESTIC = 0,
		[Display(Name = "International")]
		INTERNATIONAL = 1
	}
}
