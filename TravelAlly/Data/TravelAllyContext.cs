using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
                }
            );
        }

        public DbSet<TravelAlly.Models.City> City { get; set; } = default!;

        public DbSet<TravelAlly.Models.Station> Station { get; set; }

        public DbSet<TravelAlly.Models.Transport> Transport { get; set; }
    }
}
