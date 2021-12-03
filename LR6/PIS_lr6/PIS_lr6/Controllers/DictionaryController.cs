using Ninject;
using Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PIS_lr6.Controllers
{
    public class DictionaryController : Controller
    {
        IElementsDictionary<Telephone> phone_storage; 

        public DictionaryController(IElementsDictionary<Telephone> phonesDictionary)
        {
            phone_storage = phonesDictionary;
        }

        public ActionResult Index()
        {
            ViewBag.Telephones = phone_storage.GetElements();
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public RedirectResult AddSave(string surname, string number)
        {
            phone_storage.AddElement(new Telephone(surname, number));
            ViewBag.Telephones = phone_storage.GetElements();

            return Redirect("~/Dictionary/Index");
        }

        public ActionResult Update()
        {
            ViewBag.Telephones = phone_storage.GetElements();
            return View();
        }

        [HttpPost]
        public RedirectResult UpdateSave(int id, string surname, string number)
        {
            phone_storage.UpdateElement(new Telephone(id, surname, number));
            ViewBag.Telephones = phone_storage.GetElements();
            return Redirect("~/Dictionary/Index");
        }

        public ActionResult Delete()
        {
            ViewBag.Telephones = phone_storage.GetElements();

            return View();
        }

        [HttpPost]
        public RedirectResult DeleteSave(int id)
        {
            phone_storage.DeleteElement(id);
            ViewBag.Telephones = phone_storage.GetElements();

            return Redirect("~/Dictionary/Index");
        }
    }
}