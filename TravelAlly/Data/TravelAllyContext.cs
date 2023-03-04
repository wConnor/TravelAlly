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

			modelBuilder.Entity<SectionEntry>().HasData(
				new SectionEntry
				{
					Id = 1,
					Contents = "<p>With the United Kingdom being a fairly small country, you will find yourself able to mostly rely on travelling by train. Smaller towns and villages may not have a railway station, but you will be able to take a train to a larger town in the area and then use local bus services to reach your destination. Strike action is fairly frequent, so be sure to check <a href=\"https://www.nationalrail.co.uk\">NationalRail</a> for the latest updates.</p>\r\n        <p>It is also possible to travel to France, Belgium, and the Netherlands from London by train using the Eurostar.</p>\r\n        <h4>Purchasing Tickets</h4>\r\n        <h5>Online</h5>\r\n        <p>Tickets can be purchased online via a variety of services, but the most popular would be <a href=\"https://www.nationalrail.co.uk\">NationalRail</a> and <a href=\"https://www.thetrainline.com\">Trainline</a> (+£1.00 booking fee). Purchasing from these websites should provide you with your ticket in either a PDF format or some other means to show via. an app or Google / Apple wallet. When asked by a ticket inspector on-board, simply show them the QR code which they will then scan with the device that they carry.</p>\r\n        <h5>In-Person</h5>\r\n        <p>One can also purchase tickets in-person from both ticket booths and ticket machines if they so desire.</p>\r\n        <h5>Ticket Types</h5>\r\n        <p>There are a variety of different types of tickets that affect the trains that you can board and the price that you pay. They are as follows:</p>\r\n        <ul>\r\n            <li><b>Advance</b>: A ticket that has been purchased in-advance for a specific journey. This ticket can only be purchased online. The carrier is only able to board the specific train stated on the ticket; not the one before nor after. These are the best-value tickets that can get, though they are <b>not</b> refundable, and missing the specified train will require the purchase of another, likely expensive ticket. In the event of the train being cancelled, the ticket will be valid for the next one. If a delay were to cause the carrier to miss their connecting train, then the ticket inspectors are fairly understanding and will allow them to board.</li>\r\n            <li>\r\n                <b>Off-Peak</b>: A ticket that allows the carrier to travel on any train on a certain route during off-peak hours. Unlike an advance ticket, the carrier can simply board any train that their ticket is valid on; not just a single one. There are two main categories of off-peak train times, and these are as follows:\r\n                <ul>\r\n                    <li><b>Intercity</b>: Monday to Friday, 09:30 to 16:00, and then after 19:00.</li>\r\n                    <li><b>Transport for London (TFL)</b>: Monday to Friday from the first service 06:30, from 09:30 to 16:00, and then after 19:00.</li>\r\n                </ul>\r\n            <li><b>Anytime</b>: A ticket that allows the carrier to travel at anytime, regardless of whether or not it is currently peak or off-peak hours. These tickets are typically the most expensive, and their high prices can typically be avoided by purchasing in-advance.</li>\r\n            <li><b>Season</b>: A specialised ticket that allows the carrier unlimited travel between two stations for a specific period of time. Typically not used by travellers due to its high price and makes more sense for commuters.\r\n        </ul>\r\n        <p><b>Off-Peak</b> and <b>Anytime</b> tickets offer a 'Return' ticket type, which allows the traveller to go from one station to another and back. These tickets typically offer better value than having two single tickets. Advance tickets do <b>not</b> have a return option and must be purchased as two singles.</p>\r\n        <h5>Railcard</h5>\r\n        <p>The railcard allows its carrier to save 33% off of their train journeys and costs £30 per year, or £70 for three years. Not everyone is eligible for a railcard - one is required to be a UK citizen and fall under a certain group, such as being between the ages of 16 and 25, and being a senior. You can find out more at <a href=\"https://www.railcard.co.uk/about-railcards/\">https://www.railcard.co.uk/about-railcards/</a>. If you are eligible, it is absolutely recommended that you take advantage of it as it pays itself off very quickly, sometimes in a single journey. The railcard is not valid for Eurostar journeys. There are ways to get a free railcard, such as opening a student current account with Santander.</p>\r\n        <h5>Most Economical Method</h5>\r\n        <p>Train travel can be fairly expensive in the United Kingdom. The absolute best way to get the most out of your money is to purchase tickets online and well in-advance - a week minimum, but no longer than a month.</p>",
					Section = "Train",
					Page = "UnitedKingdom",
					Edited = DateTime.Now,
					EditedByUser = "admin@example.com"
				},
				new SectionEntry
				{
					Id = 2,
					Contents = "<p>Test</p>",
					Section = "Coach",
					Page = "UnitedKingdom",
					Edited = DateTime.Now,
					EditedByUser = "admin@example.com"
				},
				new SectionEntry
				{
					Id = 3,
					Contents = "<p>Looking for London-specific travel advice? Visit the <a asp-controller=\"Home\" asp-action=\"London\">London</a> page.</p>",
					Section = "Country",
					Page = "UnitedKingdom",
					Edited = DateTime.Now,
					EditedByUser = "admin@admin.com"
                }
				);
		}

		public DbSet<TravelAlly.Models.SectionEntry> SectionEntry { get; set; }

		public DbSet<TravelAlly.Models.City> City { get; set; } = default!;

		public DbSet<TravelAlly.Models.Station> Station { get; set; }

		public DbSet<TravelAlly.Models.Transport> Transport { get; set; }
	}
}
