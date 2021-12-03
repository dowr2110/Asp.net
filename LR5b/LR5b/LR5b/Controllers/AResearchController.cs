using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LR5b.Controllers
{
    public class AResearchController : Controller
    {
        [AAFilter]// фильтр акции
        public ActionResult AA()
        {
            Response.Write("<p>AA:Body</p>");

            return Content("<p>AA:Result Return</p>");
        }

        public class AAFilter : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                filterContext.HttpContext.Response.Write("<p>AA:OnActionExecuting</p>");
            }

            public override void OnActionExecuted(ActionExecutedContext filterContext)
            {
                filterContext.HttpContext.Response.Write("<p>AA:OnActionExecuted</p>");
            }
            //public override void OnResultExecuting(ResultExecutingContext filterContext)
            //{

            //    filterContext.HttpContext.Response.Write("<p>AA:OnResultExecuting</p>");
            //}

            //public override void OnResultExecuted(ResultExecutedContext filterContext)
            //{

            //    filterContext.HttpContext.Response.Write("<p>AA:OnResultExecuted</p>");
            //}

        }

        [ARFilter]
        public ActionResult AR()
        {
            Response.Write("<p>AR:Body</p>");

            return Content("<p>AR:Result Return</p>");
        }

        public class ARFilter : FilterAttribute, IResultFilter
        {
            public void OnResultExecuted(ResultExecutedContext filterContext)
            {
                filterContext.HttpContext.Response.Write("<p>AR:OnResultExecuted</p>");
            }

            public void OnResultExecuting(ResultExecutingContext filterContext)
            {
                filterContext.HttpContext.Response.Write("<p>AR:OnResultExecuting</p>");
            }
        }

        [AEFilter]
        public ActionResult AE()
        {
            Response.Write("<p>AE:Body Start</p>");

            throw new Exception("Exception");

            Response.Write("<p>AE:Body End</p>");
            return Content($"<p>AE</p>"); ;
        }

        public class AEFilter : FilterAttribute, IExceptionFilter
        {
            public void OnException(ExceptionContext filterContext)
            {
                filterContext.HttpContext.Response.Write("<p>AE:OnException</p>");
                ViewResult vr = new ViewResult();
                vr.ViewName = "Error";
                filterContext.Result = vr;
                filterContext.ExceptionHandled = true;
            }
        }
    }
}