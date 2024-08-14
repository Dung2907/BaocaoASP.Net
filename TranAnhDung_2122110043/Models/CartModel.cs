using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TranAnhDung_2122110043.Context;

namespace TranAnhDung_2122110043.Models
{
    public class CartModel
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}