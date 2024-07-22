using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YourProjectName.Data;
using YourProjectName.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;

namespace YourProjectName.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginItemsController : ControllerBase
    {
        private readonly LoginDbContext _context;

        public LoginItemsController(LoginDbContext context)
        {
            _context = context;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetTodoItems()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetTodoItem(int id)
        {
            var todoItem = await _context.Users.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        // POST: api/TodoItems
        [HttpPost]
        


        public async Task<ActionResult<bool>> PostLoginItem(User user)
        {
            // Fetch the user from the database based on the provided username

            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == user.Username);

            // Check if a user with the provided username exists
            if (existingUser != null)
            {
                // Compare the passwords
                bool passwordsMatch = existingUser.Password == user.Password;

                // Return true if passwords match, false otherwise
                return Ok(passwordsMatch);
            }
            else
            {
                // If no user with the provided username is found, return false
                return Ok(false);
            }
        }
    }
}
