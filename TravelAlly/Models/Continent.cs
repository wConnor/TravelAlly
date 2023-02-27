using System.ComponentModel.DataAnnotations;

namespace TravelAlly.Models
{
    public enum Continent
    {
		[Display(Name = "None")]
		NONE,
		[Display(Name = "Asia")]
		ASIA,
		[Display(Name = "Africa")]
		AFRICA,
		[Display(Name = "North America")]
		NORTH_AMERICA,
		[Display(Name = "South America")]
		SOUTH_AMERICA,
		[Display(Name = "Europe")]
		EUROPE,
		[Display(Name = "Antarctica")]
		ANTARCTICA,
		[Display(Name = "Oceania")]
        OCEANIA
    }
}
