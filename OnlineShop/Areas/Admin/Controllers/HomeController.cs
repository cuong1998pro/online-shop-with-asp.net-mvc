using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Authorize]
    //[AllowAnonymous] cho phep khong dang nhap vao duoc
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}