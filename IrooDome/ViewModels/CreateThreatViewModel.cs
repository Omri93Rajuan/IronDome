using IrooDome.DAL;
using IrooDome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IrooDome.ViewModels
{
    public class CreateThreatViewModel
    {
        public List<SelectListItem> TerrorOrgs { get; set; }

        public int OrgId { get; set; }

        public List<SelectListItem> Types { get; set; }

        public int ThreatTypeId { get; set; }

        public List<SelectListItem> Threats { get; set; }

        public int ThreatId { get; set; }
    }
}
