using System;

namespace Shop.Models
{
    public class PurchaseProduct
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public double Count { get; set; }
    }
}