using LR3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace LR3.Controllers
{
    public class DictController : Controller
    {

        // GET: Dict
        public Models.SpravochnikDict spdict = new Models.SpravochnikDict();
        public ActionResult Index()
        {
            ViewBag.Phones = spdict.GetAll();
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        public RedirectResult AddSave()
        {
            spdict.Insert(HttpContext.Request.Form["surname"], HttpContext.Request.Form["number"]);

            return Redirect("~/Dict/Index");
        }
        public ActionResult Update()
        {
            ViewBag.Phones = spdict.GetAll();
            return View();
        }
        public RedirectResult UpdateSave()
        {
            spdict.Update(Convert.ToInt32(HttpContext.Request.Form["id"]), HttpContext.Request.Form["surname"], HttpContext.Request.Form["number"]);

            return Redirect("~/Dict/Index");
        }

        public ActionResult Delete()
        {
            ViewBag.Phones = spdict.GetAll();
            return View();
        }
        public RedirectResult DeleteSave(int id)
        {
            /*   spdict.Delete(Convert.ToInt32(HttpContext.Request.Form["id"]));*/
            spdict.Delete(id);
            return Redirect("~/Dict/Index");
        }
    }
}