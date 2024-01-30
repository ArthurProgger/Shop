using System;
using System.Collections.Generic;

namespace Shop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public List<SaleProduct> SaleProducts { get; set; } = new List<SaleProduct>();
    }
}