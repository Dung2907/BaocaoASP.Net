//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TranAnhDung_2122110043.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderDetail
    {
        public long id { get; set; }
        public long order_id { get; set; }
        public long product_id { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
    
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
