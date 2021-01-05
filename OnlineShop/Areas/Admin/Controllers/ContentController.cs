using CKSource.CKFinder.Connector.Core.Commands.Dtos;
using Model.DataAccessObject;
using Model.EntityFramework;
using OnlineShop.Common;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ContentController : Controller
    {
        // GET: Admin/Content
        public ActionResult Index(string searchString, int page = 1, int pageSize = CommonConstants.NUMBER_ROW_OF_PAGE)
        {
            var dao = new ContentDAO();
            var model = dao.ListAllByPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(Model.EntityFramework.Content model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ContentDAO();
                int result = dao.Insert(model);
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Có lỗi xảy ra thử lại sau.");
                }
            }

            SetViewBag((int)model.CategoryID);
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var content = new ContentDAO().GetByID(id);
            SetViewBag((int)content.CategoryID);

            return View(content);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(Model.EntityFramework.Content content)
        {
            if (ModelState.IsValid)
            {
                var dao = new ContentDAO();
                int result = dao.Update(content);
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Có lỗi xảy ra thử lại sau.");
                }
            }

            SetViewBag((int)content.CategoryID);
            return View(content);
        }

        public ActionResult Delete(int id)
        {
            new ContentDAO().Delete(id);
            return RedirectToAction("Index");
        }

        public void SetViewBag(int? selectedID = null)
        {
            var dao = new CategoryDAO();
            ViewBag.CategoryID = new SelectList(dao.ListAll(), "ID", "Name", selectedID);
        }
    }
}