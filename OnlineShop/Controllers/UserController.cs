using BotDetect.Web.Mvc;
using Model.DataAccessObject;
using Model.EntityFramework;
using OnlineShop.Areas.Admin.Controllers;
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
                        Password = model.Password,
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
            return View();
        }
    }
}