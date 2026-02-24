using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleEcommerce.Data;
using SimpleEcommerce.Models;

namespace SimpleEcommerce.Controllers
{
    public class UsersController : Controller
    {
        private AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        // get all Users
        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        // get Users by id
        [HttpGet("{id}")]
        public async Task<ActionResult> GetUser(int id)
        {
            var users = await _context.Users.FindAsync(id);
            return Ok(users);
        }

        // create new Users API
        [HttpPost]
        public async Task<ActionResult> CreateUsers(Users users)
        {
            users.Id = Guid.NewGuid();

            _context.Users.Add(users);
            await _context.SaveChangesAsync();

            return Ok("Users created successfully");
        }

        // --update any Users
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(Guid id, Users users)
        {
            if (id != users.Id)
            {
                return BadRequest();
            }

            _context.Entry(users).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok("Users updated successfully");
        }

        //-- Delete Users API
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var users = await _context.Users.FindAsync(id);

            if (users == null)
            {
                return NotFound();
            }

            _context.Users.Remove(users);
            await _context.SaveChangesAsync();
            return Ok("Users deleted successfully");
        }

    }
}
