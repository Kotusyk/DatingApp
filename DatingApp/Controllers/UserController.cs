using DatingApp.Data;
using DatingApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(DataContext dataContext) : ControllerBase
    {

        [HttpGet("/ping", Name = "Ping")]
        public ActionResult Ping()
        {
            return Ok("Everything is fine!");
        }

        [HttpGet(Name = "GetUser")]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await dataContext.Users.ToListAsync();
            
            return Ok(users);
        }


        [HttpGet("{id:int}", Name = "GetUserById")]
        public async Task<ActionResult<AppUser>> GetUserById(int id)
        {
            var user = await dataContext.Users.FindAsync(id);

            if(user is null) return NotFound();

            return Ok(user);
        }
    }
}
