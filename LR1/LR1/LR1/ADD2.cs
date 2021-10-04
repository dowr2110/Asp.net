using System;
using System.Web;

namespace LR1
{
    public class ADD2 : IHttpHandler
    {
        /// <summary>
        /// Вам потребуется настроить этот обработчик в файле Web.config вашего 
        /// веб-сайта и зарегистрировать его с помощью IIS, чтобы затем воспользоваться им.
        /// см. на этой странице: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region Члены IHttpHandler

        public bool IsReusable
        {
            // Верните значение false в том случае, если ваш управляемый обработчик не может быть повторно использован для другого запроса.
            // Обычно значение false соответствует случаю, когда некоторые данные о состоянии сохранены по запросу.
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            //разместите здесь вашу реализацию обработчика.
            HttpRequest rq = context.Request;
            HttpResponse rs = context.Response;
            int aaa = int.Parse(rq.Form["ParmA"]);
            int bbb = int.Parse(rq.Form["ParmB"]);
            rs.Write("POST-Http-ADD: ParmA = " + aaa + " , ParmB = " + bbb);
        }

        #endregion
    }
}
