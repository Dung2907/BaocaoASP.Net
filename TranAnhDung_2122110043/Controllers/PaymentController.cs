using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TranAnhDung_2122110043.Context;
using TranAnhDung_2122110043.Models;
namespace TranAnhDung_2122110043.Controllers
{
    public class PaymentController : Controller
    {
        WebsiteAspEntities5 dbCart = new WebsiteAspEntities5();

        // GET: Payment
        public ActionResult Index()
        {
            if (Session["idUser"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            var listCart = (List<CartModel>)Session["cart"];
            if (listCart == null || !listCart.Any())
            {
                // Xử lý trường hợp giỏ hàng rỗng
                ViewBag.Message = "Giỏ hàng của bạn đang rỗng.";
                return RedirectToAction("Index", "Cart");
            }

            // Tạo đơn hàng
            Order objOrder = new Order
            {
                user_id = int.Parse(Session["idUser"].ToString()),
                total_amount = listCart.Sum(item => item.Quantity * item.Product.price),
                shipping_address = "Toan quoc", // Giả sử bạn có địa chỉ giao hàng trong session
                order_status = "Pending",
                payment_method = "Credit Card",
                payment_status = "Not Paid"
            };

            // Thêm đơn hàng vào cơ sở dữ liệu
            dbCart.Orders.Add(objOrder);
            dbCart.SaveChanges(); 

            long longOrderId = objOrder.id;
            List<OrderDetail> ListOrderDetails = new List<OrderDetail>();

            foreach (var item in listCart)
            {
                OrderDetail objDetail = new OrderDetail
                {
                    order_id = longOrderId,  // Đảm bảo thuộc tính này đúng (có thể là `order_id`)
                    quantity = item.Quantity,
                    product_id = item.Product.id,
                    price = item.Product.price
                };
                ListOrderDetails.Add(objDetail);
            }

            // Thêm chi tiết đơn hàng vào cơ sở dữ liệu
            dbCart.OrderDetails.AddRange(ListOrderDetails);
            dbCart.SaveChanges();

            // Clear the cart after the order has been placed
            Session["cart"] = null; // Xóa giỏ hàng sau khi thanh toán thành công
            return View(objOrder);
        }
    }
}
