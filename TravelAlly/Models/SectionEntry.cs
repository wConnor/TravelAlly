using System.ComponentModel.DataAnnotations;

namespace TravelAlly.Models
{
    public class SectionEntry
    {
        [Key]
        public int Id { get; set; }
        public string? Contents { get; set; }
        public string? Section { get; set; }
        public string? Page { get; set; }
        public DateTime Edited { get; set; }
        public string? EditedByUser { get; set; }
    }
}
