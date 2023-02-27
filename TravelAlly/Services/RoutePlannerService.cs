using TravelAlly.Models;
using TravelAlly.Repositories;

namespace TravelAlly.Services
{
    public class RoutePlannerService
    {
        private readonly CityRepository _cityRepository;
        private readonly StationRepository _stationRepository;
        private readonly TransportRepository _transportRepository;

        public RoutePlannerService(CityRepository cityRepository, StationRepository stationRepository, TransportRepository transportRepository)
        {
            _cityRepository = cityRepository;
            _stationRepository = stationRepository;
            _transportRepository = transportRepository;
        }

        public IEnumerable<string> ListCities()
        {
            return _cityRepository.ListCityNames();
        }

        public IEnumerable<Transport> CalculateRoutes(string OriginCity, string DestinationCity)
        {
            List<Station> OriginStations = _stationRepository.ListStationsByCity(OriginCity).ToList();
            List<Station> DestinationStations = _stationRepository.ListStationsByCity(DestinationCity).ToList();


            return null;
        }
    }
}
