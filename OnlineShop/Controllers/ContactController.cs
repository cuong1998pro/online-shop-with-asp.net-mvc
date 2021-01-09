using Model.DataAccessObject;
using Model.EntityFramework;
using OnlineShop.Areas.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class ContactController : BaseController
    {
        // GET: Contact
        public ActionResult Index()
        {
            var content = new ContactDAO().GetActiveContact();
            return View(content);
        }

        [HttpPost]
        public ActionResult Create(string hoten, string dienthoai, string diachi, string email, string yeucau)
        {
            var newFeedBack = new Feedback() { Name = hoten, Phone = dienthoai, CreatedDate = DateTime.Now, Address = diachi, Email = email, Content = yeucau };
            new ContactDAO().Insert(newFeedBack);
            SetAlert("Gửi thông tin thành công", "success");
            return RedirectToAction("Index");
        }
    }
}