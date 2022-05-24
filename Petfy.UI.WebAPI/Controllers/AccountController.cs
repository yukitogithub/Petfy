using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Petfy.Data;
using Petfy.Data.Models;
using Petfy.UI.WebAPI.DTO;

namespace Petfy.UI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly PetfyDbContext _context;

        public AccountController(PetfyDbContext context)
        {
            _context = context;
        }

        //Post
        //login
        [HttpPost("login")]
        public ActionResult<User> Login(LoginDTO login)
        {
            var user = _context.Users.SingleOrDefault(x => x.UserName == login.Username);

            if (user == null) return BadRequest("Username doesn't exist");

            if (user.Password != login.Password) return BadRequest("Password Invalid");

            return Ok(user);
        }

        //Post
        //register
        [HttpPost("register")]
        public ActionResult<User> Register(RegisterDTO user)
        {
            if (UserExists(user.Username)) return BadRequest("User already taken");

            var newUser = new User()
            {
                UserName = user.Username,
                Password = user.Password
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            return Ok(newUser);
        }

        private bool UserExists(string username)
        {
            return _context.Users.Any(u => u.UserName == username);
        }
    }
}
