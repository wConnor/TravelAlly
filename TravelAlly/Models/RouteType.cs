using System.ComponentModel.DataAnnotations;

namespace TravelAlly.Models
{
	public enum RouteType
	{
		[Display(Name = "Domestic")]
		DOMESTIC,
		[Display(Name = "International")]
		INTERNATIONAL
	}
}
