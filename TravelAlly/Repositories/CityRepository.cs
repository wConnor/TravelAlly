using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;
using TravelAlly.Data;
using TravelAlly.Models;

namespace TravelAlly.Repositories
{
	public class CityRepository
	{
		private TravelAllyContext _context;

        public CityRepository(TravelAllyContext context)
		{
			_context = context;
		}
		
		public bool CreateCity(City S)
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

		public City GetCity(int id)
		{
			return _context.City.FirstOrDefault(m => m.Id == id);
		}
		public City GetCityByName(string name)
		{
			return _context.City.FirstOrDefault(m => m.Name == name);
		}
		public IEnumerable<string> ListCityNames()
		{
			return _context.City.Select(c => c.Name);
		}

		public bool UpdateCity(City S)
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

		public void DeleteCity(int id)
		{
			var	S =	_context.City.Find(id);
			_context.City.Remove(S);
			_context.SaveChanges();
		}

		public IEnumerable<City> ListCities()
		{
			return _context.City;
		}

		public bool CityExists(int id)
		{
			return _context.City.Any(e => e.Id == id);
		}
	}
}
