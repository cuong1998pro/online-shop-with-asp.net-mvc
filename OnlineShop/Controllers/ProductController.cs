using Model.DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult ProductCategory()
        {
            var model = new ProductCategoryDAO().ListAll();
            return PartialView("_ProductCategory", model);
        }

        public ActionResult Category(int id)
        {
            var category = new ProductCategoryDAO().ViewDetail(id);
            return View(category);
        }

        public ActionResult ProductDetail(int id)
        {
            var product = new ProductDAO().ViewDetail(id);
            ViewBag.Category = new ProductCategoryDAO().ViewDetail((int)product.CategoryID);
            ViewBag.RelatedProduct = new ProductDAO().ListRelatedProduct(id);
            return View(product);
        }
    }
}