using Model.DataAccessObject;
using Model.EntityFramework;
using OnlineShop.Common;
using System;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(string searchString, int page = 1, int pageSize = CommonConstants.NUMBER_ROW_OF_PAGE)
        {
            var dao = new UserDAO();
            var model = dao.ListAllByPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                user.Password = Encryptor.MD5Hash(user.Password);
                user.CreatedDate = DateTime.Now;
                user.CreatedBy = HttpContext.User.Identity.Name;
                int result = dao.Insert(user);
                if (result > 0)
                {
                    SetAlert("Thêm User mới thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Đã xảy ra lỗi, thử lại sau.");
                }
            }

            return View("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = new UserDAO().ViewDetail(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                user.Password = Encryptor.MD5Hash(user.Password);
                bool result = dao.Update(user);
                if (result)
                {
                    SetAlert("Cập nhật User thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Đã xảy ra lỗi, thử lại sau.");
                }
            }

            return View("Edit", user);
        }

        public ActionResult Delete(int id)
        {
            new UserDAO().Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var result = new UserDAO().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}