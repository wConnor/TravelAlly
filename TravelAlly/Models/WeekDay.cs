﻿namespace TravelAlly.Models
{
	[Flags]
	public enum WeekDay
	{
		NONE = 0,
		MONDAY = 1,
		TUESDAY = 2,
		WEDNESDAY = 4,
		THURSDAY = 8,
		FRIDAY = 16,
		SATURDAY = 32,
		SUNDAY = 64
	}
}
