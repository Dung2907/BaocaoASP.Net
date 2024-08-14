using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TranAnhDung_2122110043.Context;

namespace TranAnhDung_2122110043.Controllers
{
    public class BrandController : Controller
    {
        WebsiteAspEntities5 objWebsiteAspEntities4 = new WebsiteAspEntities5();
        // GET: Brand
        public ActionResult Index()
        {
            var listBrand = objWebsiteAspEntities4.Brands.ToList();
            return View(listBrand);
        }
        public ActionResult ProductBrand(int id)
        {
            var listProduct = objWebsiteAspEntities4.Products.Where(n => n.brand_id == id).ToList();
            return View(listProduct);
        }
    }
}