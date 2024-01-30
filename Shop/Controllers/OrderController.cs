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
        public void NewOrder()
        {
            _shopContext.Orders.Add(new Order());
            _shopContext.SaveChanges();
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