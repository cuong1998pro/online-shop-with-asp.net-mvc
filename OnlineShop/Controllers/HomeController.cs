using Model.DataAccessObject;
using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var slides = new SlideDAO().ListAll();
            var productDao = new ProductDAO();
            ViewBag.NewProduct = productDao.ListNewProduct(4);
            ViewBag.FeatureProduct = productDao.ListFeatureProduct(4);
            ViewBag.Slides = slides;
            return View();
        }

        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var model = new MenuDAO().ListByGroupId(1);
            return PartialView("_MainMenu", model);
        }

        [ChildActionOnly]
        public ActionResult TopMenu()
        {
            var model = new MenuDAO().ListByGroupId(2);
            return PartialView("_TopMenu", model);
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            var model = new FooterDAO().GetFooter();
            return PartialView("_Footer", model);
        }
    }
}