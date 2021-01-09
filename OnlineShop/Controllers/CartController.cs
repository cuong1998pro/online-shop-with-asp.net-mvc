using Common;
using Model.DataAccessObject;
using Model.EntityFramework;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet]
        public ActionResult Payment()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        [HttpPost]
        public ActionResult Payment(string name, string mobile, string address, string email)
        {
            var order = new Order() { CreatedDate = DateTime.Now, ShipAddress = address, ShipMobile = mobile, ShipName = name, ShipEmail = email };
            int total = 0;
            var orderID = new OrderDAO().Insert(order);
            if (orderID > 0)
            {
                var cart = (List<CartItem>)Session[CartSession];
                var orderDetailDAO = new OrderDetailDAO();
                foreach (var item in cart)
                {
                    var orderDetail = new OrderDetail() { ProductID = item.Product.ID, OrderID = orderID, Price = item.Product.Price, Quantity = item.Quantity };
                    orderDetailDAO.Insert(orderDetail);
                    total += (int)item.Product.Price.GetValueOrDefault(0) * item.Quantity;
                }
            }

            string content = System.IO.File.ReadAllText(Server.MapPath(@"\Assets\Client\newOrder.html"));
            content = content.Replace("{{CustomerName}}", name);
            content = content.Replace("{{Phone}}", mobile);
            content = content.Replace("{{Email}}", email);
            content = content.Replace("{{Address}}", address);
            content = content.Replace("{{Total}}", total.ToString("N0"));

            new MailHelper().SendMail(email, "Đơn hàng mới", content);
            return Redirect("/hoan-thanh");
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}