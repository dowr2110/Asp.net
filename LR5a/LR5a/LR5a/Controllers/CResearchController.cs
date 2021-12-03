using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LR5a.Controllers
{
    public class CResearchController : Controller
    {
        // GET: CResearch
        [AcceptVerbs("get", "post")]
        public string C01()
        {
            string body;
            string method = Request.HttpMethod;
            string header = Request.Headers.ToString();
            string uri = Request.Url.AbsoluteUri;
            string query_parameters = "";
            foreach (string key in Request.QueryString.AllKeys)
            {
                query_parameters += $"{key}:{Request.QueryString[key]}; ";
            }

            using (StreamReader reader = new StreamReader(Request.InputStream))
            {
                body = reader.ReadToEnd();
            }
            return $"BODY: {body}; " +
                    $"HEADER: {header}; " +
                    $"METHOD: {method}; " +
                    $"URI: {uri}; " +
                    $"PARAMS: {query_parameters}; ";
        }

        [AcceptVerbs("get", "post")]
        public string C02()
        {
            string body;
            string status = HttpContext.Response.StatusCode.ToString();
            string header = Request.Headers.ToString();

            using (StreamReader reader = new StreamReader(Request.InputStream))
            {
                body = reader.ReadToEnd();
            }
            return $"BODY: {body}; " +
                    $"HEADER: {header}; " +
                    $"STATUS: {status} ";
        }
    }
}