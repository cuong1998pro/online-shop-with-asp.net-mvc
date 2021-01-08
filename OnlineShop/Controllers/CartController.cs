using Model.DataAccessObject;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace OnlineShop.Controllers
{
    public class CartController : Controller
    {
        private const string CartSession = "CartSession";

        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        public ActionResult AddItem(int id, int quantity)
        {
            var cart = Session[CartSession];
            var product = new ProductDAO().ViewDetail(id);
            if (cart != null)
            {
                //da co gio hang
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Product.ID == id))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.ID == id)
                        {
                            item.Quantity++;
                        }
                    }
                }
                else
                {
                    var item = new CartItem() { Product = product, Quantity = quantity };
                    list.Add(item);
                    Session[CartSession] = list;
                }
            }
            else
            {
                //Tao moi doi tuong cart item
                var item = new CartItem() { Product = product, Quantity = quantity };
                var list = new List<CartItem>();
                list.Add(item);
                Session[CartSession] = list;
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Update(string cartModel)
        {
            var jsoncart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var session = (List<CartItem>)Session[CartSession];
            foreach (var item in session)
            {
                var jsonItem = jsoncart.SingleOrDefault(x => x.Product.ID == item.Product.ID);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CartSession] = session;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Delete(int id)
        {
            var session = (List<CartItem>)Session[CartSession];
            session.RemoveAll(x => x.Product.ID == id);
            Session[CartSession] = session;
            return Json(new
            {
                status = true
            });
        }

        public ActionResult Payment()
        {
            return View();
        }
    }
}