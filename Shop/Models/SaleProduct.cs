namespace Shop.Models
{
    public class SaleProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public double Count { get; set; }
    }
}