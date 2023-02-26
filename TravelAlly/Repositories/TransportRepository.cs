using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;
using TravelAlly.Data;
using TravelAlly.Models;

namespace TravelAlly.Repositories
{
	public class TransportRepository
	{
		private TravelAllyContext _context;

        public TransportRepository(TravelAllyContext context)
		{
			_context = context;
		}
		
		public bool CreateTransport(Transport T)
		{
			try
			{
				_context.Add(T);
				_context.SaveChanges();
				return true;
			} 
			catch
			{
				return false;
			}
		}

		public Transport GetTransport(int id)
		{
			return _context.Transport
                .Include(t => t.StationPassings)
                .ThenInclude(sp => sp.Station)
				.FirstOrDefault(m => m.Id == id);
		}

		public bool UpdateTransport(Transport T)
		{
			try
			{
				_context.Update(T);
				_context.SaveChanges();
			}
			catch (DbUpdateConcurrencyException)
			{
				return false;				
			}

			return true;			
		}

		public void DeleteTransport(int id)
		{
			var	T =	_context.Transport.Find(id);
			_context.Transport.Remove(T);
			_context.SaveChanges();
		}

		public IEnumerable<Transport> ListTransports()
		{
			return _context.Transport
				.Include(t => t.StationPassings)
				.ThenInclude(sp => sp.Station).ToList();
		}

		public bool TransportExists(int id)
		{
			return _context.Transport.Any(e => e.Id == id);
		}
	}
}
