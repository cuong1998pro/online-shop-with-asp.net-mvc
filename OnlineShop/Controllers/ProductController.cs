using Model.DataAccessObject;
using System;
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

        public ActionResult Category(int id, int pageIndex = 1, int pageSize = 1)
        {
            var category = new ProductCategoryDAO().ViewDetail(id);
            ViewBag.Category = category;
            int totalRecord = 0;
            var products = new ProductDAO().ListAllByCategory(id, ref totalRecord, pageIndex, pageSize);

            //Phân trang
            ViewBag.Total = totalRecord;
            ViewBag.PageIndex = pageIndex;

            int totalPage = 0, maxPage = 5;
            totalPage = (int)Math.Ceiling((float)totalRecord / pageSize);

            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = maxPage;
            ViewBag.Next = pageIndex + 1;
            ViewBag.Prev = pageIndex - 1;

            return View(products);
        }

        [OutputCache(CacheProfile = "CacheForProduct")]
        public ActionResult ProductDetail(int id)
        {
            var product = new ProductDAO().ViewDetail(id);
            ViewBag.Category = new ProductCategoryDAO().ViewDetail((int)product.CategoryID);
            ViewBag.RelatedProduct = new ProductDAO().ListRelatedProduct(id);
            return View(product);
        }

        public JsonResult ListName(string q)
        {
            var result = new ProductDAO().ListName(q);
            return Json(new
            {
                data = result,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Search(string keyword, int pageIndex = 1, int pageSize = 1)
        {
            int totalRecord = 0;
            var products = new ProductDAO().Search(keyword, ref totalRecord, pageIndex, pageSize);

            //Phân trang
            ViewBag.Total = totalRecord;
            ViewBag.PageIndex = pageIndex;

            int totalPage = 0, maxPage = 5;
            totalPage = (int)Math.Ceiling((float)totalRecord / pageSize);

            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = maxPage;
            ViewBag.Next = pageIndex + 1;
            ViewBag.Prev = pageIndex - 1;

            ViewBag.Keyword = keyword;

            return View(products);
        }
    }
}