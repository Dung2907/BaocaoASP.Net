using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TranAnhDung_2122110043.Context;

namespace TranAnhDung_2122110043.Models
{
    public class HomeModel
    {
        public List<Product> ListProduct { get; set; }
        public List<Category> ListCategory { get; set; }
        public List<Brand> ListBrand {  get; set; }
        public List<Product> ListProductbyCat { get; set; }
        public List<Product> ListProductbyCat2 { get; set; }
    }
}