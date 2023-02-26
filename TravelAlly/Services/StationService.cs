using Microsoft.AspNetCore.Mvc.ModelBinding;
using TravelAlly.Data;
using TravelAlly.Models;
using TravelAlly.Repositories;

namespace TravelAlly.Services
{
	public class StationService
	{
		private StationRepository _repository;
		private ModelStateDictionary _modelState;

		public StationService(StationRepository repository)
		{
			_repository = repository;
		}

		public void SetModelState(ModelStateDictionary modelState)
		{
			_modelState = modelState;
		}

		protected bool ValidateStation(Station S)
		{
			return _modelState.IsValid;			
		}

		public bool CreateStation(Station S)
		{
			if (!ValidateStation(S))
			{
				return false;
			}

			try
			{
				_repository.CreateStation(S);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public Station GetStation(int? id)
		{
			if (id == null)
			{
				return null;
			}

			return _repository.GetStation(id.Value);
		}

		public bool	UpdateStation(int id, Station S)
		{
			if (id != S.Id)
			{
				return false;
			}

			if (!ValidateStation(S))
			{
				return false;
			}

			return _repository.UpdateStation(S);
		}
		
		public bool DeleteStation(int? id)
		{
			if (!_repository.StationExists(id.Value))
			{
				return false;
			}

			_repository.DeleteStation(id.Value);
			return true;
		}

		public IEnumerable<Station> ListStations()
		{
			return _repository.ListStations();
		}

		public bool StationExists(int id)
		{
			return _repository.StationExists(id);
		}
			
	}
}
