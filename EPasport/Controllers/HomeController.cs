using EPasport.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EPasport.Controllers
{
    public class HomeController : Controller
    {
        EPasportContext db;
        public HomeController(EPasportContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(db.TechObjects.ToList());
        }

        [HttpPost]
        public IActionResult Index(TechObject _object)
        {
            db.TechObjects.Add(_object);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult RemoveTechObject(TechObject? _object)
        {
            if(_object != null)
            {
                db.TechObjects.Remove(_object);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult RemoveMaintenanceWorks(MaintenanceWorks? _object)
        {
            if (_object != null)
            {
                db.MaintenanceWorks.Remove(_object);
                db.SaveChanges();
            }
            return RedirectToAction("MaintenanceWorks", new {Id= _object.TechObjectId});
        }

       
        [HttpGet]
        public IActionResult AllMaintenanceWorks()
        {
            return View(db.MaintenanceWorks.ToList());
        }

        [HttpGet]
        public IActionResult MaintenanceWorks(int? Id)
        {
            if (Id == null) return RedirectToAction("Index");
            ViewBag.TechObjectId = Id;
            return View(from item in db.MaintenanceWorks
                        where item.TechObjectId == Id
                        select item);
        }

        [HttpPost]
        public IActionResult MaintenanceWorks(MaintenanceWorks _object)
        {
            db.MaintenanceWorks.Add(_object);
            db.SaveChanges();
            return RedirectToAction("MaintenanceWorks");
        }
    }
}
