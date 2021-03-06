using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Petfy.Data;
using Petfy.Data.Models;
using Petfy.Domain.Services;
using Petfy.Domain.DTO;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;

namespace Petfy.UI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AccountController(ITokenService tokenService, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IMapper mapper)
        {
            _tokenService = tokenService;
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        //Post
        //login
        [HttpPost("login")]
        public async Task<ActionResult<OwnerDTO>> Login(LoginDTO login)
        {
            var user = _userManager.Users.SingleOrDefault(x => x.UserName == login.Username);

            if (user == null) return Unauthorized("Username or password incorrect");

            var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);

            if (!result.Succeeded) return Unauthorized();

            var token = await _tokenService.CreateToken(user);

            //var userDto = new UserDTO()
            //{
            //    UserName = login.Username,
            //    Token = token
            //};
            var ownerDTO = _mapper.Map<OwnerDTO>(user);
            ownerDTO.Token = token;

            return Ok(ownerDTO);
        }

        //Post
        //register
        [HttpPost("register")]
        public async Task<ActionResult<OwnerDTO>> Register(RegisterDTO user)
        {
            if (UserExists(user.Username)) return BadRequest("User already taken");

            //var newUser = new AppUser()
            //{
            //    UserName = user.Username,
            //    //PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password)),
            //    //PasswordSalt = hmac.Key
            //};

            var newOwner = _mapper.Map<Owner>(user);
            //var newUser = _mapper.Map<AppUser>(user);
            newOwner.UserName = user.Username;

            var result = await _userManager.CreateAsync(newOwner, user.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            var roleResult = await _userManager.AddToRoleAsync(newOwner, "Owner");

            if(!roleResult.Succeeded) return BadRequest(roleResult.Errors);

            var token = await _tokenService.CreateToken(newOwner);

            //var userDto = new UserDTO()
            //{
            //    UserName = user.Username,
            //    Token = token
            //};

            var ownerDTO = _mapper.Map<OwnerDTO>(newOwner);
            ownerDTO.Token = token;

            return Ok(ownerDTO);
        }

        private bool UserExists(string username)
        {
            return _userManager.Users.Any(u => u.UserName == username);
        }
    }
}
