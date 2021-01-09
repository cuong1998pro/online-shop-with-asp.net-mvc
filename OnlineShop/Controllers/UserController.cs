using BotDetect.Web.Mvc;
using Facebook;
using Model.DataAccessObject;
using Model.EntityFramework;
using OnlineShop.Areas.Admin.Controllers;
using OnlineShop.Common;
using OnlineShop.Models;
using System;
using System.Configuration;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class UserController : BaseController
    {
        public Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }

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

        public ActionResult LoginFacebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(
                new
                {
                    client_id = ConfigurationManager.AppSettings["FbAppID"],
                    client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                    redirect_uri = RedirectUri.AbsoluteUri,
                    response_type = "code",
                    scope = "email",
                });
            return Redirect(loginUrl.AbsoluteUri);
        }

        public ActionResult FacebookCallback(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = ConfigurationManager.AppSettings["FbAppID"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                code = code
            });

            var accessToken = result.access_token;
            if (!string.IsNullOrEmpty(accessToken))
            {
                fb.AccessToken = accessToken;
                //thanh cong. tao bien get thong tin.
                dynamic me = fb.Get("me?fields=first_name,middle_name,last_name,id,email");
                string email = me.email;
                string userName = me.username;
                string firstname = me.first_name;
                string middlename = me.middle_name;
                string lastname = me.last_name;

                //dong bo vao database
                var dao = new UserDAO();
                var user = new User()
                {
                    Email = email,
                    UserName = email,
                    Name = firstname + " " + middlename + " " + lastname,
                    Status = true,
                    Password = Encryptor.MD5Hash(string.Empty)
                };
                int id = dao.InsertForFacebook(user);

                if (id > 0)
                {
                    var userSession = new UserLogin();
                    userSession.Username = user.UserName;
                    userSession.UserID = user.ID;
                    Session.Add(CommonConstants.USER_SESSION.ToString(), userSession);
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}