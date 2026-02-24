using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleEcommerce.Data;
using SimpleEcommerce.Models;

namespace SimpleEcommerce.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        // get all products
        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _context.Carts.ToListAsync();
            return Ok(products);
        }

        // get product by id
        [HttpGet("{id}")]
        public async Task<ActionResult> GetProduct(int id)
        {
            var product = await _context.Carts.FindAsync(id);
            return Ok(product);
        }

        // create new product API
        [HttpPost]
        public async Task<ActionResult> CreateProduct(Product product)
        {
            product.Id = Guid.NewGuid();

            _context.Carts.Add(product);
            await _context.SaveChangesAsync();

            return Ok("Product created successfully");
        }

        // --update any product
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(Guid id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok("Product updated successfully");
        }

        //-- Delete product API
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await _context.Carts.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            _context.Carts.Remove(product);
            await _context.SaveChangesAsync();
            return Ok("Product deleted successfully");
        }
    }
}
