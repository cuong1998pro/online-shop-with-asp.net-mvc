using Model.DataAccessObject;
using Model.EntityFramework;
using OnlineShop.Common;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        public ActionResult Index(int page = 1, int pageSize = 1)
        {
            var dao = new UserDAO();
            //var model = dao.ListAllByPaging(page, pageSize);
            var model = dao.ListAll();
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
                int result = dao.Insert(user);
                if (result > 0)
                {
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
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Đã xảy ra lỗi, thử lại sau.");
                }
            }

            return View("Edit", user);
        }
    }
}