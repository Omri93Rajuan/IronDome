using IrooDome.DAL;
using IrooDome.Models;
using Microsoft.AspNetCore.Mvc;

namespace IrooDome.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            List <DefenceAmmuntion> Defences =  Data.Get.DefenceAmmuntions.ToList();
            return View(Defences);
        }
        public IActionResult UpdateDefenceAmmuntion (int dfid, int amount)
        {
            DefenceAmmuntion? da = Data.Get.DefenceAmmuntions.Find (dfid);
            da.Amount = amount;
            Data.Get.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
