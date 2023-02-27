using System.ComponentModel.DataAnnotations;

namespace TravelAlly.Models
{
	[Flags]
	public enum WeekDay
	{
		[Display(Name = "None")]
		NONE = 0,
		[Display(Name = "Monday")]
		MONDAY = 1,
		[Display(Name = "Tuesday")]
		TUESDAY = 2,
		[Display(Name = "Wednesday")]
		WEDNESDAY = 4,
		[Display(Name = "Thursday")]
		THURSDAY = 8,
		[Display(Name = "Friday")]
		FRIDAY = 16,
		[Display(Name = "Saturday")]
		SATURDAY = 32,
		[Display(Name = "Sunday")]
		SUNDAY = 64
	}
}
