using EPasport.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EPasport.Controllers
{
    public class HomeController : Controller
    {
        //Передача контекста БД посредством Dependency Injection
        EPasportContext db;
        public HomeController(EPasportContext context)
        {
            db = context;
        }

        //Get запрос для представления страницы Index
        [HttpGet]
        public IActionResult Index()
        {
            //Передача в представление модели таблицы БД ввиде списка
            return View(db.TechObjects.ToList());
        }

        //Post запрос для отправки данных на сервер посредством form
        [HttpPost]
        public IActionResult Index(TechObject _object)
        {
            //Добавление объекта в БД и её сохранение
            db.TechObjects.Add(_object);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Get запрос для представления страницы AllMaintenanceWorks
        [HttpGet]
        public IActionResult AllMaintenanceWorks()
        {
            return View(db.MaintenanceWorks.ToList());
        }

        //Get запрос для представления страницы MaintenanceWorks
        [HttpGet]
        public IActionResult MaintenanceWorks(int? Id)
        {
            if (Id == null) return RedirectToAction("Index");
            ViewBag.TechObjectId = Id;
            //Передача в представление модели списка intem по условию
            return View(from item in db.MaintenanceWorks
                        where item.TechObjectId == Id
                        select item);
        }

        //Post запрос для отправки данных на сервер посредством form
        [HttpPost]
        public IActionResult MaintenanceWorks(MaintenanceWorks _object)
        {
            //Добавление объекта в БД и её сохранение
            db.MaintenanceWorks.Add(_object);
            db.SaveChanges();
            //Переадресация на метод MaintenanceWorks с отправкой параметра TechObjectId
            return RedirectToAction("MaintenanceWorks", new { Id = _object.TechObjectId });
        }

        //Get запрос для удаления оъекта TechObject из БД
        [HttpGet]
        public IActionResult RemoveTechObject(TechObject? _object)
        {
            if(_object != null)
            {
                //Удаление и сохрание данных в таблице БД
                db.TechObjects.Remove(_object);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        //Get запрос для удаления оъекта MaintenanceWorks из БД
        [HttpGet]
        public IActionResult RemoveMaintenanceWorks(MaintenanceWorks? _object)
        {
            if (_object != null)
            {
                //Удаление и сохрание данных в таблице БД
                db.MaintenanceWorks.Remove(_object);
                db.SaveChanges();
            }
            //Переадресация на метод MaintenanceWorks с отправкой параметра TechObjectId
            return RedirectToAction("MaintenanceWorks", new {Id= _object.TechObjectId});
        }
    }
}
