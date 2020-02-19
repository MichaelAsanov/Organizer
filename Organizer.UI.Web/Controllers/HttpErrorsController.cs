using System.Web.Mvc;

namespace Organizer.UI.Web.Controllers
{
    /// <summary>
    /// Контроллер с обработчиками ошибок
    /// </summary>
    public class HttpErrorsController : Controller
    {
        public ActionResult NotAuthorized()
        {
            Response.StatusCode = 401;
            return View();
        }

        public ActionResult Forbidden()
        {
            Response.StatusCode = 403;
            return View();
        }

        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            return View();
        }

        public ActionResult InternalServerError()
        {
            Response.StatusCode = 500;
            return View();
        }
    }
}