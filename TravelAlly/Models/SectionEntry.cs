﻿namespace TravelAlly.Models
{
    public class SectionEntry
    {
        public int Id { get; set; }
        public string? Contents { get; set; }
        public string Section { get; set; }
        public string Page { get; set; }
        public DateTime Edited { get; set; }
        public int EditedByUserId { get; set; }
    }
}
