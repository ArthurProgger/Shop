using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using System.Linq;
using System.Collections;

namespace Shop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        public ShopContext _shopContext;
        public ProductController(ShopContext shopContext) => _shopContext = shopContext;

        [HttpGet]
        public IEnumerable AllProducts() => _shopContext.Products;

        [HttpPost]
        public void NewProduct([FromBody] Product product)
        {
            _shopContext.Products.Add(product);
            _shopContext.SaveChanges();
        }

        [HttpPut]
        public void UpdateProduct([FromBody] Product product)
        {
            _shopContext.Products.Update(product);
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                Product product = _shopContext.Products.First(product => product.Id == id);
                if (product is null)
                    return NotFound();

                _shopContext.Products.Remove(product);
                return Ok();
            }
            catch (System.InvalidOperationException)
            {
                return BadRequest();
            }
        }
    }
}