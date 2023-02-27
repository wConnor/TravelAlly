using Microsoft.AspNetCore.Mvc.ModelBinding;
using TravelAlly.Data;
using TravelAlly.Models;
using TravelAlly.Repositories;

namespace TravelAlly.Services
{
	public class TransportService
	{
		private TransportRepository _repository;
		private ModelStateDictionary _modelState;

		public TransportService(TransportRepository repository)
		{
			_repository = repository;
		}

		public void SetModelState(ModelStateDictionary modelState)
		{
			_modelState = modelState;
		}

		protected bool ValidateTransport(Transport T)
		{
			return _modelState.IsValid;			
		}

		public bool CreateTransport(Transport T)
		{
			if (!ValidateTransport(T))
			{
				return false;
			}

			try
			{
				_repository.CreateTransport(T);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public Transport GetTransport(int? id)
		{
			if (id == null)
			{
				return null;
			}

			return _repository.GetTransport(id.Value);
		}

		public bool UpdateTransport(int id, Transport T)
		{
			if (id != T.Id)
			{
				return false;
			}

			if (!ValidateTransport(T))
			{
				return false;
			}

			return _repository.UpdateTransport(T);
		}
		
		public bool DeleteTransport(int? id)
		{
			if (!_repository.TransportExists(id.Value))
			{
				return false;
			}

			_repository.DeleteTransport(id.Value);
			return true;
		}

		public IEnumerable<Transport> ListTransports()
		{
			return _repository.ListTransports();
		}
		public IEnumerable<Transport> ListTransportsByCountry(string Country)
		{
			return _repository.ListTransportsByCountry(Country);
		}

		public bool TransportExists(int id)
		{
			return _repository.TransportExists(id);
		}
			
	}
}
