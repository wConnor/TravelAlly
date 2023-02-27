using Microsoft.AspNetCore.Mvc.ModelBinding;
using TravelAlly.Data;
using TravelAlly.Models;
using TravelAlly.Repositories;

namespace TravelAlly.Services
{
	public class CityService
	{
		private CityRepository _repository;
		private ModelStateDictionary _modelState;

		public CityService(CityRepository repository)
		{
			_repository = repository;
		}

		public void SetModelState(ModelStateDictionary modelState)
		{
			_modelState = modelState;
		}

		protected bool ValidateCity(City S)
		{
			return _modelState.IsValid;			
		}

		public bool CreateCity(City S)
		{
			if (!ValidateCity(S))
			{
				return false;
			}

			try
			{
				_repository.CreateCity(S);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public City GetCity(int? id)
		{
			if (id == null)
			{
				return null;
			}

			return _repository.GetCity(id.Value);
		}

		public City GetCityByName(string? name)
		{
			if (name ==	null)
			{
				return null;
			}

			return _repository.GetCityByName(name);
		}

		public bool	UpdateCity(int id, City S)
		{
			if (id != S.Id)
			{
				return false;
			}

			if (!ValidateCity(S))
			{
				return false;
			}

			return _repository.UpdateCity(S);
		}
		
		public bool DeleteCity(int? id)
		{
			if (!_repository.CityExists(id.Value))
			{
				return false;
			}

			_repository.DeleteCity(id.Value);
			return true;
		}

		public IEnumerable<City> ListCities()
		{
			return _repository.ListCities();
		}

		public IEnumerable<string> ListCityNames()
		{
			return _repository.ListCityNames();
		}

		public bool CityExists(int id)
		{
			return _repository.CityExists(id);
		}
			
	}
}
