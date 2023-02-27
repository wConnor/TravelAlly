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
					//TimeZone = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time"),
					Country = "United Kingdom",
					Continent = Continent.EUROPE
				},
				new City
				{
					Id = 2,
					Name = "Paris",
					Lat = 48.864716,
					Lon = 2.349014,
					//TimeZone = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"),
					Country = "France",
					Continent = Continent.EUROPE
				},
				new City
				{
					Id = 3,
					Name = "Woking",
					Lat = 51.316366,
					Lon = -0.557833,
					//TimeZone = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time"),
					Country = "United Kingdom",
					Continent = Continent.EUROPE
				},
				new City
				{
					Id = 4,
					Name = "Basingstoke",
					Lat = 51.263320,
					Lon = -1.090735,
					//TimeZone = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time"),
					Country = "United Kingdom",
					Continent = Continent.EUROPE
				},
				new City
				{
					Id = 5,
					Name = "Exeter",
					Lat = 50.725556,
					Lon = -3.526944,
					//TimeZone = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time"),
					Country = "United Kingdom",
					Continent = Continent.EUROPE
				},
				new City
				{
					Id = 6,
					Name = "Pinhoe",
					Lat = 50.74069,
					Lon = -3.46717,
					Country = "United Kingdom",
					Continent = Continent.EUROPE
				},
				new City
				{
					Id = 7,
					Name = "Cranbrook (Devon)",
					Lat = 50.747,
					Lon = -3.413,
					Country = "United Kingdom",
					Continent = Continent.EUROPE
				},
				new City
				{
					Id = 8,
					Name = "Honiton",
					Lat = 50.7981,
					Lon = -3.1925,
					Country = "United Kingdom",
					Continent = Continent.EUROPE
				},
				new City
				{
					Id = 9,
					Name = "Axminster",
					Lat = 50.7821,
					Lon = -2.9981,
					Country = "United Kingdom",
					Continent = Continent.EUROPE
				},
				new City
				{
					Id = 10,
					Name = "Crewkerne",
					Lat = 50.8842,
					Lon = -2.7953,
					Country = "United Kingdom",
					Continent = Continent.EUROPE
				},
				new City
				{
					Id = 11,
					Name = "Yeovil",
					Lat = 50.9247,
					Lon = -2.6132,
					Country = "United Kingdom",
					Continent = Continent.EUROPE
				},
				new City
				{
					Id = 12,
					Name = "Sherborne",
					Lat = 50.9489,
					Lon = -2.5198,
					Country = "United Kingdom",
					Continent = Continent.EUROPE
				},
				new City
				{
					Id = 13,
					Name = "Templecombe",
					Lat = 51.0015,
					Lon = -2.4154,
					Country = "United Kingdom",
					Continent = Continent.EUROPE
				},
				new City
				{
					Id = 14,
					Name = "Gillingham (Dorset)",
					Lat = 51.0385,
					Lon = -2.2769,
					Country = "United Kingdom",
					Continent = Continent.EUROPE
				},
				new City
				{
					Id = 15,
					Name = "Tisbury",
					Lat = 51.0639,
					Lon = -2.0816,
					Country = "United Kingdom",
					Continent = Continent.EUROPE
				},
				new City
				{
					Id = 16,
					Name = "Salisbury",
					Lat = 51.069,
					Lon = -1.7952,
					Country = "United Kingdom",
					Continent = Continent.EUROPE
				},
				new City
				{
					Id = 17,
					Name = "Andover",
					Lat = 51.2079,
					Lon = -1.4795,
					Country = "United Kingdom",
					Continent = Continent.EUROPE
				}
			);

			modelBuilder.Entity<Station>().HasData(
				new Station
				{
					Id = 1,
					Name = "St. Pancras International",
					Code = "SPX",
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
					Code = "BSK",
					AcceptsTypes = TransportType.RAILWAY,
					Lat = 51.26842,
					Lon = -1.08857,
					CityId = 4
				},
				new Station
				{
					Id = 4,
					Name = "Woking Railway Station",
					Code = "WOK",
					AcceptsTypes = TransportType.RAILWAY,
					Lat = 51.31903,
					Lon = -0.55598,
					CityId = 3
				},
				new Station
				{
					Id = 3,
					Name = "London Waterloo",
					Code = "WAT",
					AcceptsTypes = TransportType.RAILWAY,
					Lat = 51.5031,
					Lon = -0.1132,
					CityId = 1
				},
				new Station
				{
					Id = 6,
					Name = "Exeter St. Davids",
					Code = "EXD",
					AcceptsTypes = TransportType.RAILWAY,
					Lat = 50.7292155,
					Lon = -3.5435703,
					CityId = 5
				},
				new Station
				{
					Id = 20,
					Name = "Exeter Central",
					Code = "EXC",
					AcceptsTypes = TransportType.RAILWAY,
					Lat = 50.7270161,
					Lon = -3.5321297,
					CityId = 5
				},
				new Station
				{
					Id = 7,
					Name = "Pinhoe Railway Station",
					Code = "PIN",
                    AcceptsTypes = TransportType.RAILWAY,
					Lat = 50.73779,
					Lon = -3.47008,
					CityId = 6
				},
				new Station
				{
					Id = 8,
					Name = "Cranbrook Station",
                    Code = "CBK",
                    AcceptsTypes = TransportType.RAILWAY,
					Lat = 50.75001,
					Lon = -3.42097,
					CityId = 7
				},
				new Station
				{
					Id = 9,
					Name = "Honiton Railway Station",
					Code = "HON",
                    AcceptsTypes = TransportType.RAILWAY,
					Lat = 50.79672,
					Lon = -3.1869,
					CityId = 8
				},
				new Station
				{
					Id = 10,
					Name = "Axminster Railway Station",
                    Code = "AXM",
					AcceptsTypes = TransportType.RAILWAY,
					Lat = 50.77901,
					Lon = -3.00495,
					CityId = 9
				},
				new Station
				{
					Id = 11,
					Name = "Crewkerne Railway Station",
                    Code = "CKN",
                    AcceptsTypes = TransportType.RAILWAY,
					Lat = 50.87357,
					Lon = -2.77844,
					CityId = 10
				},
				new Station
				{
					Id = 12,
					Name = "Yeovil Junction",
                    Code = "YVJ",
					AcceptsTypes = TransportType.RAILWAY,
					Lat = 50.92479,
					Lon = -2.61226,
					CityId = 11
				},
				new Station
				{
					Id = 13,
					Name = "Sherborne Railway Station",
                    Code = "SHE",
					AcceptsTypes = TransportType.RAILWAY,
					Lat = 50.9439790,
					Lon = -2.5129696,
					CityId = 12
				},
				new Station
				{
					Id = 14,
					Name = "Templecombe Railway Station",
                    Code = "TMC",
					AcceptsTypes = TransportType.RAILWAY,
					Lat = 51.00159,
					Lon = -2.41728,
					CityId = 13
				},
				new Station
				{
					Id = 15,
					Name = "Gillingham Railway Station",
                    Code = "GIL",
					AcceptsTypes = TransportType.RAILWAY,
					Lat = 51.03409,
					Lon = -2.27208,
					CityId = 14
				},
				new Station
				{
					Id = 16,
					Name = "Tisbury Railway Station",
                    Code = "TIS",
					AcceptsTypes = TransportType.RAILWAY,
					Lat = 51.061,
					Lon = -2.07879,
					CityId = 15
				},
				new Station
				{
					Id = 17,
					Name = "Salisbury Railway Station",
                    Code = "SAL",
					AcceptsTypes = TransportType.RAILWAY,
					Lat = 51.07055,
					Lon = -1.80645,
					CityId = 16
				},
				new Station
				{
					Id = 18,
					Name = "Andover Railway Station",
                    Code = "ADV",
					AcceptsTypes = TransportType.RAILWAY,
					Lat = 51.21155,
					Lon = -1.49277,
					CityId = 17,
				},
				new Station
				{
					Id = 19,
					Name = "Clapham Junction",
                    Code = "CLJ",
					AcceptsTypes = TransportType.RAILWAY,
					Lat = 51.4644589,
					Lon = -0.1705184,
					CityId = 1
				}
			);

			// BSK -> WAT
			{
				modelBuilder.Entity<StationPassing>().HasData(
					new StationPassing
					{
						Id = 1,
						StationId = 5,
						ArrivalTime = null,
						DepartureTime = DateTime.Parse("08:45"),
						TransportId = 1
					},
					new StationPassing
					{
						Id = 2,
						StationId = 4,
						ArrivalTime = DateTime.Parse("09:08"),
						DepartureTime = DateTime.Parse("09:09"),
						TransportId = 1
					},
					new StationPassing
					{
						Id = 3,
						StationId = 3,
						ArrivalTime = DateTime.Parse("09:41"),
						DepartureTime = null,
						TransportId = 1
					}
					);
			}

			// St. Pancras -> Gare du Nord
			{
				modelBuilder.Entity<StationPassing>().HasData(
					new StationPassing
					{
						Id = 4,
						StationId = 1,
						ArrivalTime = null,
						DepartureTime = DateTime.Parse("10:34"),
						TransportId = 2
					},
					new StationPassing
					{
						Id = 5,
						StationId = 2,
						ArrivalTime = DateTime.Parse("15:08"),
						DepartureTime = null,
						TransportId = 2
					});
			}

			// Exeter St. Davids -> London Waterloo
			{
				modelBuilder.Entity<StationPassing>().HasData(
				new StationPassing
				{
					Id = 6,
					StationId = 6,
					ArrivalTime = null,
					DepartureTime = DateTime.Parse("07:25"),
					TransportId = 3
				},
				new StationPassing
				{
					Id = 7,
					StationId = 20,
					ArrivalTime = DateTime.Parse("07:28"),
					DepartureTime = DateTime.Parse("07:29"),
					TransportId = 3
				},
				new StationPassing
				{
					Id = 8,
					StationId = 7,
					ArrivalTime = DateTime.Parse("07:33"),
					DepartureTime = DateTime.Parse("07:34"),
					TransportId = 3
				},
				new StationPassing
				{
					Id = 9,
					StationId = 8,
					ArrivalTime = DateTime.Parse("07:38"),
					DepartureTime = DateTime.Parse("07:39"),
					TransportId = 3
				},
				new StationPassing
				{
					Id = 10,
					StationId = 9,
					ArrivalTime = DateTime.Parse("07:51"),
					DepartureTime = DateTime.Parse("07:52"),
					TransportId = 3
				},
				new StationPassing
				{
					Id = 11,
					StationId = 10,
					ArrivalTime = DateTime.Parse("08:03"),
					DepartureTime = DateTime.Parse("08:04"),
					TransportId = 3
				},
				new StationPassing
				{
					Id = 12,
					StationId = 11,
					ArrivalTime = DateTime.Parse("08:16"),
					DepartureTime = DateTime.Parse("08:17"),
					TransportId = 3
				},
				new StationPassing
				{
					Id = 13,
					StationId = 12,
					ArrivalTime = DateTime.Parse("08:25"),
					DepartureTime = DateTime.Parse("08:26"),
					TransportId = 3
				},
				new StationPassing
				{
					Id = 14,
					StationId = 13,
					ArrivalTime = DateTime.Parse("08:35"),
					DepartureTime = DateTime.Parse("08:35"),
					TransportId = 3
				},
				new StationPassing
				{
					Id = 15,
					StationId = 14,
					ArrivalTime = DateTime.Parse("08:43"),
					DepartureTime = DateTime.Parse("08:43"),
					TransportId = 3
				},
				new StationPassing
				{
					Id = 16,
					StationId = 15,
					ArrivalTime = DateTime.Parse("08:50"),
					DepartureTime = DateTime.Parse("08:51"),
					TransportId = 3
				},
				new StationPassing
				{
					Id = 17,
					StationId = 16,
					ArrivalTime = DateTime.Parse("09:01"),
					DepartureTime = DateTime.Parse("09:01"),
					TransportId = 3
				},
				new StationPassing
				{
					Id = 18,
					StationId = 17,
					ArrivalTime = DateTime.Parse("09:17"),
					DepartureTime = DateTime.Parse("09:21"),
					TransportId = 3
				},
				new StationPassing
				{
					Id = 19,
					StationId = 18,
					ArrivalTime = DateTime.Parse("09:37"),
					DepartureTime = DateTime.Parse("09:38"),
					TransportId = 3
				},
				new StationPassing
				{
					Id = 20,
					StationId = 5,
					ArrivalTime = DateTime.Parse("09:56"),
					DepartureTime = DateTime.Parse("09:57"),
					TransportId = 3
				},
				new StationPassing
				{
					Id = 21,
					StationId = 4,
					ArrivalTime = DateTime.Parse("10:15"),
					DepartureTime = DateTime.Parse("10:17"),
					TransportId = 3
				},
				new StationPassing
				{
					Id = 22,
					StationId = 19,
					ArrivalTime = DateTime.Parse("10:36"),
					DepartureTime = DateTime.Parse("10:37"),
					TransportId = 3
				},
				new StationPassing
				{
					Id = 23,
					StationId = 3,
					ArrivalTime = DateTime.Parse("10:49"),
					DepartureTime = null,
					TransportId = 3
				}
				);
			}

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
					RouteCode = "",
					RouteType = RouteType.INTERNATIONAL,
					Carrier = "Eurostar",
					OperatesOnDays = WeekDay.MONDAY | WeekDay.TUESDAY | WeekDay.WEDNESDAY | WeekDay.THURSDAY | WeekDay.FRIDAY | WeekDay.SATURDAY | WeekDay.SUNDAY
				},
				new Transport
				{
					Id = 3,
					Type = TransportType.RAILWAY,
					RouteCode = "",
					RouteType = RouteType.DOMESTIC,
					Carrier = "South Western Railway",
					OperatesOnDays = WeekDay.MONDAY | WeekDay.TUESDAY | WeekDay.WEDNESDAY | WeekDay.THURSDAY | WeekDay.FRIDAY | WeekDay.SATURDAY | WeekDay.SUNDAY
				}
				);
		}

		public DbSet<TravelAlly.Models.City> City { get; set; } = default!;

		public DbSet<TravelAlly.Models.Station> Station { get; set; }

		public DbSet<TravelAlly.Models.Transport> Transport { get; set; }
	}
}
