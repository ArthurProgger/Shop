using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Shop.Models;

namespace Shop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private ShopContext _shopContext;
        public OrderController(ShopContext shopContext) => _shopContext = shopContext;

        [HttpGet(nameof(AllOrders))]
        public IEnumerable AllOrders() => _shopContext.Orders;

        [HttpPost(nameof(NewOrder))]
        public void NewOrder([FromBody] IEnumerable<SaleProduct> sales)
        {
            Order order = new Order();
            foreach (SaleProduct saleProduct in sales)
            {
                try
                {
                    Product product = _shopContext.Products.First(product => product.Id == saleProduct.ProductId);
                    double salesProductCount = _shopContext.SalesProducts.Where(sale => sale.ProductId == product.Id).Sum(sale => sale.Count), 
                        purchasesProductCount = _shopContext.PurchasesProducts.Where(purchase => purchase.ProductId == product.Id).Sum(purchase => purchase.Count),
                        factCount = purchasesProductCount - salesProductCount;
                    if (saleProduct.Count <= factCount)
                    {
                        _shopContext.SalesProducts.Add(saleProduct);
                        order.SaleProducts.Add(saleProduct);
                    }
                }
                catch (System.InvalidOperationException)
                {
                    continue;
                }
            }

            if (order.SaleProducts.Count() > 0)
            {
                _shopContext.Orders.Add(order);
                _shopContext.SaveChanges();
            }
        }

        [HttpDelete(nameof(DeleteOrder))]
        public void DeleteOrder(int id)
        {
            Order order = _shopContext.Orders.First(order => order.Id == id);
            _shopContext.Orders.Remove(order);
            _shopContext.SaveChanges();
        }
    }
}