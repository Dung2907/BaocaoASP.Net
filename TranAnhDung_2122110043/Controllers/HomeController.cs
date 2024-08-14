using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TranAnhDung_2122110043.Context;
using TranAnhDung_2122110043.Models;

namespace TranAnhDung_2122110043.Controllers
{
    public class HomeController : Controller
    {
        WebsiteAspEntities5 objWebsiteAspEntities4 = new WebsiteAspEntities5();

        public ActionResult Index()
        {
            HomeModel objHomeModel = new HomeModel();
            objHomeModel.ListProduct = objWebsiteAspEntities4.Products.ToList();
            objHomeModel.ListCategory = objWebsiteAspEntities4.Categories.ToList();
            objHomeModel.ListBrand = objWebsiteAspEntities4.Brands.ToList();
            if (objHomeModel.ListCategory.Any())
            {
                var firstCategoryId = objHomeModel.ListCategory.First().id;
                objHomeModel.ListProductbyCat = objWebsiteAspEntities4.Products
                    .Where(n => n.category_id == firstCategoryId)
                    .ToList();
            }
            else
            {
                objHomeModel.ListProductbyCat = new List<Product>();
            }
             if (objHomeModel.ListCategory.Count() > 1)
    {
        var secondCategoryId = objHomeModel.ListCategory[1].id;
        objHomeModel.ListProductbyCat2 = objWebsiteAspEntities4.Products
            .Where(n => n.category_id == secondCategoryId)
            .ToList();
    }
    else
    {
        objHomeModel.ListProductbyCat2 = new List<Product>();
    }
            return View(objHomeModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}