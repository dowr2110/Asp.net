using LR4.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace LR4.Controllers
{
    public class DictController : Controller
    {
       
        public Models.phoneContext _db = new Models.phoneContext();
        public ActionResult Index()
        {
            var outter = from dict in _db.sp select dict;//linq 

            ViewBag.Phones = outter.OrderBy(u => u.Id).ToList();
            return View();
        }
        public ActionResult Add()
        {

            return View();
        }
        public RedirectResult AddSave(string surname, string number)
        {
            //(HttpContext.Request.Form["surname"], HttpContext.Request.Form["number"]);

            var outher = from dict in _db.sp select dict;
           // List<Spravochnik> m = outher.ToList(); ;
            int id = 0;
            foreach (Spravochnik sp in outher)
            {
                if (sp.Id > id)
                {
                    id = sp.Id;
                }
            }

            var add = new Spravochnik
            {
                Id = id + 1,
                Surname = surname,
                Phone_number = number
            };
            _db.sp.Add(add);//добавляем 
            _db.SaveChanges();//сохраняем

            return Redirect("~/Dict/Index");//переадресация в Index
        }
        public ActionResult Update()
        {
            var outter = from dict in _db.sp select dict;//linq 
            ViewBag.Phones = outter.OrderBy(u => u.Id).ToList(); 

            return View();
        }
        public RedirectResult UpdateSave()
        {
            var outter = from dict in _db.sp select dict;//linq  
            foreach (Spravochnik sp in outter)
            {
                if (sp.Id == Convert.ToInt32(HttpContext.Request.Form["id"]))
                {
                    sp.Surname = HttpContext.Request.Form["surname"];
                    sp.Phone_number = HttpContext.Request.Form["number"];
                    _db.Entry(sp).State = EntityState.Modified;
                }
            }
            _db.SaveChanges();
            return Redirect("~/Dict/Index");
        }

        public ActionResult Delete()
        {
            var outter = from dict in _db.sp select dict;//linq 

            ViewBag.Phones = outter.OrderBy(u => u.Id).ToList();
            return View();
        }
        public RedirectResult DeleteSave(int id)
        {
            /*  (Convert.ToInt32(HttpContext.Request.Form["id"]));*/
            var outter = from dict in _db.sp select dict;//linq 

            foreach (Spravochnik item in outter)
            {
                if (item.Id == id)
                {
                    _db.sp.Remove(item);
                  
                }
            }
            _db.SaveChanges();
            return Redirect("~/Dict/Index");
        }
    }
}