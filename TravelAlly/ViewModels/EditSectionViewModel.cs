using Microsoft.AspNetCore.Mvc.Rendering;
using TravelAlly.Models;

namespace TravelAlly.ViewModels
{
    public class EditSectionViewModel
    {
        public string Contents { get; set; }
        public string Section { get; set; }
        public string Page { get; set; }
    }
}
