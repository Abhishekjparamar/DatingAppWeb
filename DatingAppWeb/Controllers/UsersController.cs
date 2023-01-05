using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatingAppWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetUsers")]
        public async Task<ActionResult<List<AppUser>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet]
        [Route("GetAllUserById/{Id}")]
        public async Task<ActionResult<AppUser>> GetAllUserById(int Id)
        {
            return await _context.Users.FindAsync(Id);
        }

    }
}
