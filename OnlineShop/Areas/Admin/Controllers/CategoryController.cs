using Model.DataAccessObject;
using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        public ActionResult Index(string searchString, int page = 1, int pageSize = CommonConstants.NUMBER_ROW_OF_PAGE)
        {
            var dao = new CategoryDAO();
            var model = dao.ListAllByPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}