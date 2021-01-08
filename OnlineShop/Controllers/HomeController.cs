using Model.DataAccessObject;
using OnlineShop.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        private const string CartSession = "CartSession";

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

        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return PartialView("_HeaderCart", list);
        }
    }
}