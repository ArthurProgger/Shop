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

        [HttpGet(nameof(AllProducts))]
        public IEnumerable AllProducts() => _shopContext.Products;

        [HttpPost(nameof(NewProduct))]
        public void NewProduct([FromQuery] Product product)
        {
            _shopContext.Products.Add(product);
            _shopContext.SaveChanges();
        }

        [HttpPut(nameof(UpdateProduct))]
        public IActionResult UpdateProduct([FromQuery] Product product)
        {
            try
            {
                Product updatingProduct = _shopContext.Products.First(prod => prod.Id == product.Id);

                foreach (var prop in typeof(Product).GetProperties())
                    prop.SetValue(updatingProduct, prop.GetValue(product));

                _shopContext.SaveChanges();
                return Ok();
            }
            catch (System.InvalidOperationException)
            {
                return NotFound();
            }
        }

        [HttpDelete(nameof(DeleteProduct))]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                Product product = _shopContext.Products.First(product => product.Id == id);
                _shopContext.Products.Remove(product);
                _shopContext.SaveChanges();
                return Ok();
            }
            catch (System.InvalidOperationException)
            {
                return NotFound();
            }
        }

        [HttpPost(nameof(Purchase))]
        public IActionResult Purchase(int productId, double count)
        {
            try
            {
                Product product = _shopContext.Products.First(product => product.Id == productId);
                _shopContext.PurchasesProducts.Add(new PurchaseProduct
                {
                    Product = product,
                    Count = count
                });
                _shopContext.SaveChanges();
                return Ok();
            }
            catch (System.InvalidOperationException)
            {
                return NotFound();
            }
        }

        [HttpGet(nameof(CountOfProduct))]
        public double CountOfProduct(int id) => _shopContext.PurchasesProducts.Where(purchase => purchase.Product.Id == id).Sum(purchase => purchase.Count);
    }
}