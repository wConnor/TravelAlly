using TravelAlly.Models;
using TravelAlly.Repositories;

namespace TravelAlly.Services
{
	public class SectionEntryService
	{
		private readonly SectionEntryRepository _repository;

		public SectionEntryService(SectionEntryRepository repository)
		{
			_repository = repository;
		}

		public bool CreateSectionEntry(SectionEntry SE)
		{
			return _repository.CreateSectionEntry(SE);
		}

		public SectionEntry GetSectionEntryByPageSection(string Page, string Section)
		{
			return _repository.GetSectionEntryByPageSection(Page, Section);
		}

		public IEnumerable<SectionEntry> ListSectionEntries()
		{
			return _repository.ListSectionEntries();
		}

		public IEnumerable<SectionEntry> ListSectionEntriesByPageSection(string Page, string Section)
		{
			return _repository.ListSectionEntriesByPageSection(Page, Section);
		}
	}
}
