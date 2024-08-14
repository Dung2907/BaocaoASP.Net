using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TranAnhDung_2122110043.Context;

namespace TranAnhDung_2122110043.Controllers
{
    public class CategoryController : Controller
    {
        WebsiteAspEntities5 objWebsiteAspEntities4 = new WebsiteAspEntities5();
        // GET: Category
        public ActionResult Index()
        {
            var listCategory = objWebsiteAspEntities4.Categories.ToList();
            return View(listCategory);
        }
        public ActionResult ProductCategory(int id)
        {
            var listProduct = objWebsiteAspEntities4.Products.Where(n => n.category_id==id).ToList();
        return View(listProduct); 
        }
    
    }
}