using BotDetect.Web.Mvc;
using Model.DataAccessObject;
using Model.EntityFramework;
using OnlineShop.Areas.Admin.Controllers;
using OnlineShop.Common;
using OnlineShop.Models;
using System;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class UserController : BaseController
    {
        // GET: User
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [CaptchaValidationActionFilter("CaptchaCode", "ExampleCaptcha", "Wrong Captcha!")]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                //validate them
                if (dao.CheckUserName(model.UserName))
                {
                    ModelState.AddModelError("", "Tài khoản đã tồn tại");
                }
                else if (dao.CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                }
                else
                {
                    //tao user
                    var user = new User()
                    {
                        UserName = model.UserName,
                        Password = Encryptor.MD5Hash(model.Password),
                        Email = model.Email,
                        Name = model.Name,
                        Address = model.Address,
                        Phone = model.Phone,
                        CreatedDate = DateTime.Now,
                        Status = true,
                    };
                    var result = dao.Insert(user);
                    if (result > 0)
                    {
                        SetAlert("Đăng ký thành công", "success");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Có lỗi xảy ra, thử lại sau");
                    }
                }
            }
            MvcCaptcha.ResetCaptcha("ExampleCaptcha");
            return View(model);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var result = dao.Login(model.Username, Encryptor.MD5Hash(model.Password));
                if (result is bool)
                {
                    var user = dao.GetByUsername(model.Username);
                    var userSession = new UserLogin();
                    userSession.Username = user.UserName;
                    userSession.UserID = user.ID;
                    Session.Add(CommonConstants.USER_SESSION.ToString(), userSession);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng");
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Remove(CommonConstants.USER_SESSION.ToString());
            return RedirectToAction("Index", "Home");
        }
    }
}