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

        public List<Transport> CalculateRoutes(string OriginCity, string DestinationCity, DateTime DepartureDateTime)
        {
            List<Station> OriginStations = _stationRepository.ListStationsByCity(OriginCity).ToList();
            List<Station> DestinationStations = _stationRepository.ListStationsByCity(DestinationCity).ToList();

			// Consider problems with conflicting city names, i.e. Moscow in United States and Russia
			City OriginCityObject = _cityRepository.GetCityByName(OriginCity);
			City DestinationCityObject = _cityRepository.GetCityByName(DestinationCity);

			List<Transport> EligibleRoutes = new List<Transport>();

			// Domestic route
			if (OriginCityObject.Country ==	DestinationCityObject.Country)
            {
                List<Transport> CountryRoutes = _transportRepository.ListTransportsByCountry(OriginCityObject.Country).ToList();

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
                            EligibleRoutes.Add(r);
                            break;
                        }
                    }
                }

                // No direct route found - attempt with transfers.
                if (EligibleRoutes.Count == 0)
                {

                }
            }
            // International Route
            else
            {
                // Attempt to find a direct route between the two countries.
                List<Transport> InternationalRotues = _transportRepository.ListTransportsByCountry(OriginCityObject.Country).ToList();

                foreach (var r in InternationalRotues)
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
							EligibleRoutes.Add(r);
							break;
						}
                    }
                }

                // No direct route found - attempt with transfers possibly crossing country borders.
                if (EligibleRoutes.Count == 0)
                {

                }
            }

            return EligibleRoutes;
        }
    }
}
