using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TranAnhDung_2122110043.Context;
namespace TranAnhDung_2122110043.Controllers
{
    public class ProductController : Controller
    {
        WebsiteAspEntities5 db = new WebsiteAspEntities5();
        // GET: Product
        public ActionResult Index(string searchString, int? page)
        {
            var products = from p in db.Products
                           select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.name.Contains(searchString)
                                            || p.description.Contains(searchString)
                                            || p.Brand.name.Contains(searchString)
                                            || p.Category.name.Contains(searchString));
            }

            int pageSize = 12; // Change this to set how many products per page
            int pageNumber = (page ?? 1);

            return View(products.OrderBy(p => p.name).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Pagelistinglarge(string searchString, int? page)
        {
            var products = from p in db.Products
                           select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.name.Contains(searchString)
                                            || p.description.Contains(searchString)
                                            || p.Brand.name.Contains(searchString)
                                            || p.Category.name.Contains(searchString));
            }

            int pageSize = 8; // Change this to set how many products per page
            int pageNumber = (page ?? 1);

            return View(products.OrderBy(p => p.name).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Detail(int id)
        {
            using (WebsiteAspEntities5 objWebsiteAspEntities5 = new WebsiteAspEntities5())
            {
                var item = objWebsiteAspEntities5.Products.FirstOrDefault(p => p.id == id);
                if (item == null)
                {
                    return HttpNotFound();
                }
                return View(item);
            }
        }
    }
}