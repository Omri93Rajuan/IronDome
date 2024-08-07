using IrooDome.DAL;
using IrooDome.Models;
using IrooDome.Utils;
using IrooDome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IrooDome.Controllers
{
    public class ThreatController : Controller
    {
        public IActionResult Index()
        {
            List<Threat> threats = Data.Get.Threats
                .Include(t => t.org)
                .Include(t => t.type)
                .ToList();
            return View(threats);
        }

        public IActionResult Create()
        {

            List<ThreatAmmunition>? ta = Data.Get.ThreatAmmunitions.ToList();
            List<TerrorOrg>? orgList = Data.Get.TerrorOrgs.ToList();

            CreateThreatViewModel model = new CreateThreatViewModel
            {
                Types = ta.Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.Name }).ToList(),
                TerrorOrgs = orgList.Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.Name }).ToList()
            };

            return View(model);
        }
     

        [HttpPost]
        public IActionResult Create(CreateThreatViewModel model)
        {
            TerrorOrg? org = Data.Get.TerrorOrgs.Find(model.OrgId);
            ThreatAmmunition? threatType = Data.Get.ThreatAmmunitions.Find(model.ThreatTypeId);

            if (org != null && threatType != null)
            {
                Threat newThreat = new Threat
                {
                    org = org,
                    type = threatType,
                };

                Data.Get.Threats.Add(newThreat);
                Data.Get.SaveChanges();

                Task.Run(() => StartAttack(newThreat));
            }

            return RedirectToAction(nameof(Index));
        }
        private void StartAttack(Threat threat)
        {
            Console.WriteLine($"Threat {threat.Id} from {threat.org.Name} with {threat.org.Name} started.");
            threat.status = ThreatStatus.Active;
            Task.Delay(threat.responseTime * 1000).Wait();
            Console.WriteLine($"Threat {threat.Id} attack finished.");

            threat.status = ThreatStatus.Inactive;
            Data.Get.SaveChanges();
        }
    }
}
