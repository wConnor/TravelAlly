using Microsoft.EntityFrameworkCore;
using System.Collections;
using TravelAlly.Models;

namespace TravelAlly.Data
{
	public class TravelAllyContext : DbContext
	{
		public TravelAllyContext(DbContextOptions<TravelAllyContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<City>().HasData(
				new City
				{
					Id = 1,
					Name = "London",
					Lat = 51.507222,
					Lon = -0.1275,
					Country = "United Kingdom",
					Continent = "Europe"
				},
				new City
				{
					Id = 2,
					Name = "Paris",
					Lat = 48.864716,
					Lon = 2.349014,
					Country = "France",
					Continent = "Europe"
				},
				new City
				{
					Id = 3,
					Name = "Woking",
					Lat = 51.316366,
					Lon = -0.557833,
					Country = "United Kingdom",
					Continent = "Europe"
				},
				new City
				{
					Id = 4,
					Name = "Basingstoke",
					Lat = 51.263320,
					Lon = -1.090735,
					Country = "United Kingdom",
					Continent = "Europe"
				}
			);

			modelBuilder.Entity<Station>().HasData(
				new Station
				{
					Id = 1,
					Name = "St. Pancras International",
					AcceptsTypes = TransportType.RAILWAY,
					Lat = 51.53,
					Lon = -0.125278,
					CityId = 1
				},
				new Station
				{
					Id = 2,
					Name = "Gare du Nord",
					AcceptsTypes = TransportType.RAILWAY,
					Lat = 48.881111,
					Lon = 2.355278,
					CityId = 2
				},
				new Station
				{
					Id = 5,
					Name = "Basingstoke Railway Station",
					AcceptsTypes = TransportType.RAILWAY,
					Lat = 51.26842,
					Lon = -1.08857,
					CityId = 4
				},
				new Station
				{
					Id = 4,
					Name = "Woking Railway Station",
					AcceptsTypes = TransportType.RAILWAY,
					Lat = 51.31903,
					Lon = -0.55598,
					CityId = 3
				},
				new Station
				{
					Id = 3,
					Name = "London Waterloo",
					AcceptsTypes = TransportType.RAILWAY,
					Lat = 51.5031,
					Lon = -0.1132,
					CityId = 1
				}
			);

			StationPassing BSK = new StationPassing
			{
				Id = 1,
				StationId = 5,
				ArrivalTime = null,
				DepartureTime = DateTime.Parse("08:45"),
				TransportId = 1
			};
			StationPassing WOK = new StationPassing
			{
				Id = 2,
				StationId = 4,
				ArrivalTime = DateTime.Parse("09:08"),
				DepartureTime = DateTime.Parse("09:09"),
				TransportId = 1
			};
			StationPassing WAT = new StationPassing
			{
				Id = 3,
				StationId = 3,
				ArrivalTime = DateTime.Parse("09:41"),
				DepartureTime = null,
				TransportId = 1
			};

			modelBuilder.Entity<StationPassing>().HasData(
				BSK,
				WOK,
				WAT
				);

			StationPassing STP = new StationPassing
			{
				Id = 4,
				StationId = 1,
				ArrivalTime = null,
				DepartureTime = DateTime.Parse("10:34"),
				TransportId = 2
			};

			StationPassing GDN = new StationPassing
			{
				Id = 5,
				StationId = 2,
				ArrivalTime = DateTime.Parse("15:08"),
				DepartureTime = null,
				TransportId = 2
			};

			modelBuilder.Entity<StationPassing>().HasData(
				STP,
				GDN
			);

			modelBuilder.Entity<Transport>().HasData(
				new Transport
				{
					Id = 1,
					Type = TransportType.RAILWAY,
					RouteType = RouteType.DOMESTIC,
					Carrier = "South Western Railway",
					OperatesOnDays = WeekDay.MONDAY | WeekDay.WEDNESDAY | WeekDay.FRIDAY,
				},
				new Transport
				{
					Id = 2,
					Type = TransportType.RAILWAY,
					RouteType = RouteType.INTERNATIONAL,
					Carrier = "Eurostar",
					OperatesOnDays = WeekDay.MONDAY | WeekDay.TUESDAY | WeekDay.WEDNESDAY | WeekDay.THURSDAY | WeekDay.FRIDAY | WeekDay.SATURDAY | WeekDay.SUNDAY
				}
				);
		}

		public DbSet<TravelAlly.Models.City> City { get; set; } = default!;

		public DbSet<TravelAlly.Models.Station> Station { get; set; }

		public DbSet<TravelAlly.Models.Transport> Transport { get; set; }
	}
}
