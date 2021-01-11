using Model.DataAccessObject;
using OnlineShop.Common;
using System;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        public ActionResult Index(int pageIndex = 1, int pageSize = CommonConstants.NUMBER_ROW_OF_PAGE)
        {
            int totalRecord = 0;
            var content = new ContentDAO().ListAllByPaging(ref totalRecord, pageIndex, pageSize);

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

            return View(content);
        }

        public ActionResult Detail(int id)
        {
            var model = new ContentDAO().GetByID(id);
            ViewBag.Tags = new ContentDAO().ListTag(id);
            return View(model);
        }

        public ActionResult Tag(string tagID, int pageIndex = 1, int pageSize = CommonConstants.NUMBER_ROW_OF_PAGE)
        {
            int totalRecord = 0;
            var content = new ContentDAO().ListAllByPagingAndTag(tagID, ref totalRecord, pageIndex, pageSize);

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
            ViewBag.Tag = new ContentDAO().GetTagByID(tagID);

            return View(content);
        }
    }
}