using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;
using TravelAlly.Data;
using TravelAlly.Models;

namespace TravelAlly.Repositories
{
	public class StationRepository
	{
		private TravelAllyContext _context;

        public StationRepository(TravelAllyContext context)
		{
			_context = context;
		}
		
		public bool CreateStation(Station S)
		{
			try
			{
				_context.Add(S);
				_context.SaveChangesAsync();
				return true;
			} 
			catch
			{
				return false;
			}
		}

		public Station GetStation(int id)
		{
			return _context.Station.FirstOrDefault(m => m.Id == id);
		}

		public bool UpdateStation(Station S)
		{
			try
			{
				_context.Update(S);
				_context.SaveChanges();
			}
			catch (DbUpdateConcurrencyException)
			{
				return false;				
			}

			return true;			
		}

		public void DeleteStation(int id)
		{
			var	S =	_context.Station.Find(id);
			_context.Station.Remove(S);
			_context.SaveChanges();
		}

		public IEnumerable<Station> ListStations()
		{
			return _context.Station.Include(s => s.City);
		}

		public bool StationExists(int id)
		{
			return _context.Station.Any(e => e.Id == id);
		}
	}
}
