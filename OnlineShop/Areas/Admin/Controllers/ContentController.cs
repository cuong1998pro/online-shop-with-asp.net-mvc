using CKSource.CKFinder.Connector.Core.Commands.Dtos;
using Model.DataAccessObject;
using Model.EntityFramework;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ContentController : Controller
    {
        // GET: Admin/Content
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Model.EntityFramework.Content model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ContentDAO();
            }
            SetViewBag((int)model.CategoryID);
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var content = new ContentDAO().GetByID(id);
            SetViewBag((int)content.CategoryID);
            return View();
        }

        public void SetViewBag(int? selectedID = null)
        {
            var dao = new CategoryDAO();
            ViewBag.CategoryID = new SelectList(dao.ListAll(), "ID", "Name", selectedID);
        }
    }
}