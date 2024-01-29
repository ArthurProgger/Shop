using System.Collections.Generic;

namespace Shop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<SaleProduct> SaleProducts { get; set; } = new List<SaleProduct>();
    }
}