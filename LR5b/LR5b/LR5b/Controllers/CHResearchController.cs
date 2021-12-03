using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LR5b.Controllers
{
    public class CHResearchController : Controller
    {
        // GET: CHResearch
        static int a = 5;

        [HttpGet, OutputCache(Duration = 5, Location = System.Web.UI.OutputCacheLocation.Any)]
        public ActionResult AD()
        {
            a++;
            long t = DateTime.Now.ToBinary();
            return Content($"GET:/AD:{t}:{a}");
        }

        [HttpPost, OutputCache(Duration = 5, VaryByParam = "x;y", Location = System.Web.UI.OutputCacheLocation.Server)]
        public ActionResult AP(string x, string y)
        {
            long t = DateTime.Now.ToBinary();
            return Content($"GET:/AP:{t}:{x}:{y}");
        }
    }
}