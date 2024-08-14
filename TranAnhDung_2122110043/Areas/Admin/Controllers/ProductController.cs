using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TranAnhDung_2122110043.Context;
namespace TranAnhDung_2122110043.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private WebsiteAspEntities5 db = new WebsiteAspEntities5();

        // GET: Admin/Product
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

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(products.OrderBy(p => p.name).ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        public ActionResult Index(string searchString)
        {
            return RedirectToAction("Index", new { searchString });
        }

        // GET: Admin/Product/Details/{id}
        public ActionResult Details(int id)
        {
            var product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Product/Create
        public ActionResult Create()
        {
            ViewBag.category_id = new SelectList(db.Categories, "id", "name");
            ViewBag.brand_id = new SelectList(db.Brands, "id", "name");
            return View();
        }

        // POST: Admin/Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,category_id,brand_id,name,slug,description,specs,image,price,sale_price,stock,created_at,updated_at,status")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.category_id = new SelectList(db.Categories, "id", "name", product.category_id);
            ViewBag.brand_id = new SelectList(db.Brands, "id", "name", product.brand_id);
            return View(product);
        }

        // GET: Admin/Product/Edit/{id}
        public ActionResult Edit(int id)
        {
            ViewBag.category_id = new SelectList(db.Categories, "id", "name");
            ViewBag.brand_id = new SelectList(db.Brands, "id", "name");
            var product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Product/Edit/{id}
        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Admin/Product/Delete/{id}
        public ActionResult Delete(int id)
        {
            var product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Product/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}