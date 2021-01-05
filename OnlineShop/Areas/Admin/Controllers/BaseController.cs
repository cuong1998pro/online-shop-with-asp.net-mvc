using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
        //protected override void OnActionExecuted(ActionExecutedContext filterContext)
        //{
        //    var session = (UserLogin)Session[CommonConstants.USER_SESSION.ToString()];
        //    if (session == null)
        //    {
        //        filterContext.Result = new RedirectToRouteResult(
        //            new System.Web.Routing.RouteValueDictionary(new { controller = "Login", action = "Index", Area = "Admin" })
        //            );
        //    }
        //    base.OnActionExecuted(filterContext);
        //}

        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "Warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }
    }
}