using Model.DataAccessObject;
using OnlineShop.Areas.Admin.Models;
using OnlineShop.Common;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        #region Dang nhap bang session

        //public ActionResult Login(LoginModel model)
        //{
        //    if (ModelState.IsValid )
        //    {
        //        var dao = new UserDAO();
        //        var user = dao.GetByUsername(model.Username);
        //        var result = dao.Login(model.Username, Encryptor.MD5Hash(model.Pasword));
        //        if (result is bool)
        //        {
        //            var userSession = new UserLogin() { Username = user.UserName, UserID = user.ID };
        //            Session.Add(CommonConstants.USER_SESSION.ToString(), userSession);
        //            return RedirectToAction("Index", "Home");
        //        }
        //        else if ((string)result != "")
        //        {
        //            ModelState.AddModelError("", (string)result);
        //        }
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "Hãy nhập đủ thông tin.");
        //    }
        //    return View("Index");
        //}

        #endregion Dang nhap bang session

        //Dang nhap bang membership
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                if (Membership.ValidateUser(model.Username, Encryptor.MD5Hash(model.Pasword)))
                {
                    //set cookie
                    FormsAuthentication.SetAuthCookie(model.Username, model.RememberMe);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    string result = (string)dao.Login(model.Username, Encryptor.MD5Hash(model.Pasword));
                    ModelState.AddModelError("", result);
                }
            }
            else
            {
                ModelState.AddModelError("", "Hãy nhập đủ thông tin.");
            }
            return View("Index");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View();
        }
    }
}