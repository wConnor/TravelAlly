using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;
using TravelAlly.Data;
using TravelAlly.Models;

namespace TravelAlly.Repositories
{
	public class SectionEntryRepository
	{
		private TravelAllyContext _context;

        public SectionEntryRepository(TravelAllyContext context)
		{
			_context = context;
		}
		
		public bool CreateSectionEntry(SectionEntry SE)
		{
			try
			{
				_context.Add(SE);
				_context.SaveChanges();
				return true;
			} 
			catch
			{
				return false;
			}
		}

		public SectionEntry GetSectionEntry(int id)
		{
			return _context.SectionEntry.FirstOrDefault(m => m.Id == id);
		}
		
		public SectionEntry GetSectionEntryByPageSection(string Page, string Section)
		{
			return _context.SectionEntry.OrderByDescending(se => se.Edited)
				.First(se => (se.Page == Page && se.Section == Section));
		}

		public bool UpdateSectionEntry(SectionEntry S)
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

		public void DeleteSectionEntry(int id)
		{
			var	S =	_context.SectionEntry.Find(id);
			_context.SectionEntry.Remove(S);
			_context.SaveChanges();
		}

		public IEnumerable<SectionEntry> ListSectionEntries()
		{
			return _context.SectionEntry;
		}

		public IEnumerable<SectionEntry> ListSectionEntriesByPageSection(string Page, string Section)
		{
			return _context.SectionEntry.OrderByDescending(se => se.Edited)
				.Where(se => (se.Page == Page && se.Section == Section));
		}

		public bool SectionEntryExists(int id)
		{
			return _context.SectionEntry.Any(e => e.Id == id);
		}
	}
}
