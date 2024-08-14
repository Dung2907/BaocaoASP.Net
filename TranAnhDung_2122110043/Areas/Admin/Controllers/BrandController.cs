using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TranAnhDung_2122110043.Context;
using PagedList;

namespace TranAnhDung_2122110043.Areas.Admin.Controllers
{
    public class BrandController : Controller
    {
        private WebsiteAspEntities5 db = new WebsiteAspEntities5();

        // GET: Admin/Brand
        public ActionResult Index(string searchString, int? page)
        {
            var brands = from b in db.Brands select b;

            if (!String.IsNullOrEmpty(searchString))
            {
                brands = brands.Where(b => b.name.Contains(searchString));
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(brands.OrderBy(b => b.name).ToPagedList(pageNumber, pageSize));
        }

        // Other actions remain the same...

        [HttpPost]
        public ActionResult Index(string searchString)
        {
            return RedirectToAction("Index", new { searchString });
        }

        public ActionResult Details(int id)
        {
            var brand = db.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }
        // GET: Admin/Brand/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Admin/Brand/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Brand brand)
        {
            if (ModelState.IsValid)
            {
                db.Brands.Add(brand);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(brand);
        }
        // GET: Admin/Brand/Edit/5
        public ActionResult Edit(int id)
        {
            var brand = db.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }
        // POST: Admin/Brand/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Brand brand)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brand).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(brand);
        }
        // GET: Admin/Brand/Delete/5
        public ActionResult Delete(int id)
        {
            var brand = db.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }
        // POST: Admin/Brand/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var brand = db.Brands.Find(id);
            db.Brands.Remove(brand);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}