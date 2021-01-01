using Model.DataAccessObject;
using OnlineShop.Areas.Admin.Models;
using OnlineShop.Common;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var user = dao.GetByUsername(model.Username);
                var result = dao.Login(model.Username, model.Pasword);
                if (result)
                {
                    var userSession = new UserLogin() { Username = user.UserName, UserID = user.ID };
                    Session.Add(CommonConstants.USER_SESSION.ToString(), userSession);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập, mật khẩu không đúng");
                }
            }
            return View("Index");
        }
    }
}