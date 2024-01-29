using System.Collections.Generic;

namespace Shop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<SaleProduct> SaleProducts { get; set; }
        public List<PurchaseProduct> PurchasesProduct { get; set; }
    }
}