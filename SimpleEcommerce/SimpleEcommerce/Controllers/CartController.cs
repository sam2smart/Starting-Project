using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.EntityFrameworkCore;
using SimpleEcommerce.Data;
using SimpleEcommerce.Models;

namespace SimpleEcommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : Controller
    {
     
        private readonly AppDbContext _context;
        private Product carts;

        public CartController(AppDbContext context)
        {
            _context = context;
        }

        // get all products
        [HttpGet]
        public async Task<ActionResult> GetCarts()
        {
            var cart = await _context.CartItems.ToListAsync();
            return Ok(cart);
        }

        // get Carts by id
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCart(int id)
        {
            var cart = await _context.CartItems.FindAsync(id);
            return Ok(cart);
        }

        // create new Carts API
        [HttpPost]
        public async Task<ActionResult> CreateCart(Carts cartItems)
        {
            cartItems.Id = Guid.NewGuid();

            _context.Carts.Add(carts);
            await _context.SaveChangesAsync();

            return Ok("Carts created successfully");
        }

        // --update any Carts
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCart(Guid id, Carts cartItems)
        {
            if (id != cartItems.Id)
            {
                return BadRequest();
            }

            _context.Entry(carts).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok("Carts updated successfully");
        }

        //-- Delete Carts API
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var carts = await _context.Carts.FindAsync(id);

            if (carts == null)
            {
                return NotFound();
            }

            _context.Carts.Remove(carts);
            await _context.SaveChangesAsync();
            return Ok("Carts deleted successfully");
        }
    }
}
