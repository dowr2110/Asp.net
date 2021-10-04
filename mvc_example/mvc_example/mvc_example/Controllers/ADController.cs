using mvc_example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_example.Controllers
{
    public class ADController : Controller
    {
        // GET: AD
        BookContext db = new BookContext();

        public ActionResult Index()
        {
            // получаем из бд все объекты Book
            IEnumerable<Book> books = db.Books;
            // передаем все объекты в динамическое свойство Books в ViewBag
            ViewBag.Books = books;
            // возвращаем представление
            return View();
        }

        [HttpGet]
        public ActionResult A()
        {
            return Content("Action A");
        }

        [HttpPost]
        public ActionResult B()
        {
            return Content("Action B");
        }

        [AcceptVerbs("post","get")]
        public ActionResult C()
        {
            return Content("Action C");
        }

  
        public ActionResult D()
        {
            return Content("Action D");
        }

        

        public class Parms
        {
            public int X { get; set; }
            public int Y { get; set; }

            public string s { get; set; }

            public int? n;

            public DateTime? d;

        }

        public ActionResult Parameters()
        {
            int x = Int32.MaxValue;
            Int32.TryParse(this.Request.Params["x"], out x);
            int y = Int32.MaxValue;
            Int32.TryParse(this.Request.Params["y"], out y);
            ViewBag.Parmss = new Parms
            {
                X = x,
                Y = y,
                s = this.Request.Params["string"],
                n = this.Request.Params["number"] == null ? null : (int?)Int32.Parse(this.Request.Params["number"]),
                d = this.Request.Params["date"] == null ? (DateTime?)null : DateTime.Parse(this.Request.Params["date"])
            };
            return View();
        }
    }
}