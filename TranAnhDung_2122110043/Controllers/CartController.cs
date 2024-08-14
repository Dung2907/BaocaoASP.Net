using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TranAnhDung_2122110043.Context;
using TranAnhDung_2122110043.Models;

namespace TranAnhDung_2122110043.Controllers
{
    public class CartController : Controller
    {
        private readonly WebsiteAspEntities5 _context = new WebsiteAspEntities5();

        public ActionResult Index()
        {
            return View((List<CartModel>)Session["cart"] ?? new List<CartModel>());
        }

        [HttpPost]
        public ActionResult AddToCart(int id, int quantity)
        {
            try
            {
                if (Session["cart"] == null)
                {
                    List<CartModel> cart = new List<CartModel>();
                    cart.Add(new CartModel { Product = _context.Products.Find(id), Quantity = quantity });
                    Session["cart"] = cart;
                    Session["count"] = 1;
                }
                else
                {
                    List<CartModel> cart = (List<CartModel>)Session["cart"];
                    int index = IsExist(id);
                    if (index != -1)
                    {
                        cart[index].Quantity += quantity;
                    }
                    else
                    {
                        cart.Add(new CartModel { Product = _context.Products.Find(id), Quantity = quantity });
                        Session["count"] = Convert.ToInt32(Session["count"]) + 1;
                    }
                    Session["cart"] = cart;
                }

                return Json(new { Success = true, Message = "Thêm giỏ hàng thành công!", CartCount = Session["count"] });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = "Lỗi: " + ex.Message });
            }
        }

        [HttpPost]
        public ActionResult Remove(int id)
        {
            List<CartModel> li = (List<CartModel>)Session["cart"];
            li.RemoveAll(x => x.Product.id == id);
            Session["cart"] = li;
            Session["count"] = Convert.ToInt32(Session["count"]) - 1;
            return Json(new { Success = true, Message = "Xóa sản phẩm thành công", CartCount = Session["count"] });
        }

        private int IsExist(int id)
        {
            List<CartModel> cart = (List<CartModel>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Product.id == id)
                    return i;
            return -1;
        }
    }
}