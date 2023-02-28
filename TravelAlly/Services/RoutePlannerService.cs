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

        // Will be changed to IEnumerable<Transport> once transfers are added.
        public Transport CalculateRoutes(string OriginCity, string DestinationCity, DateTime DepartureDateTime)
        {
            List<Station> OriginStations = _stationRepository.ListStationsByCity(OriginCity).ToList();
            List<Station> DestinationStations = _stationRepository.ListStationsByCity(DestinationCity).ToList();

			// Consider problems with conflicting city names, i.e. Moscow in United States and Russia
			City OriginCityObject = _cityRepository.GetCityByName(OriginCity);
			City DestinationCityObject = _cityRepository.GetCityByName(DestinationCity);

			Transport CalculatedRoute = null;

			// Domestic route
			if (OriginCityObject.Country ==	DestinationCityObject.Country)
            {
                List<Transport> CountryRoutes = _transportRepository.ListTransportsByCountry(OriginCityObject.Country).ToList();

                bool RouteFound = false;

                foreach (var r in CountryRoutes)
                {
                    bool OriginFound = false, DestinationFound = false;
                    foreach (var sp in r.StationPassings)
                    {
                        if (sp.Station.City == OriginCityObject)
                        {
                            OriginFound = true;
                        }

                        if (sp.Station.City == DestinationCityObject && OriginFound)
                        {
                            DestinationFound = true;
                        }

                        if (OriginFound && DestinationFound)
                        {
                            RouteFound = true;
                            CalculatedRoute = r;
                            break;
                        }
                    }
                    if (RouteFound)
                    {
                        break;
                    }
                }
            }

            return CalculatedRoute;
        }
    }
}
