using DatingApp.Data;
using DatingApp.Entities;
using DatingAppWeb.DTOs;
using DatingAppWeb.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace DatingAppWeb.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenRepository _tokenService;
        public AccountController(DataContext context,ITokenRepository tokenService)
        {
            _tokenService = tokenService;
            _context = context;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<AppUser>> Login(LoginDTO loginDTO)
        {
            var user= await _context.Users.SingleOrDefaultAsync(x=>x.UserName==loginDTO.UserName);
            if(user==null) return Unauthorized("Invalid Username");

            using var hmac=new HMACSHA512(user.PasswordSalt);

            var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));

            for(int i=0; i<computeHash.Length; i++)
            {
                if (computeHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid Password");
            }
            var token = _tokenService.GetToken(loginDTO);
            return Ok(new TokenResponse { Token=token,UserName=loginDTO.UserName});
        }

        [HttpPost("Register")]
        public async Task<ActionResult<AppUser>> Register(AppUserDTO usermodel)
        {
            if (await UserExist(usermodel.UserName.ToLower())) return BadRequest("Username is taken");
            using var hmac = new HMACSHA512();

            var user = new AppUser
            {
                UserName = usermodel.UserName.ToLower(),
                PasswordHash=hmac.ComputeHash(Encoding.UTF8.GetBytes(usermodel.Password)),
                PasswordSalt=hmac.Key
            };

            _context.Users.Add(user);
           await  _context.SaveChangesAsync();
            return Ok(user);

        }


        private async Task<bool> UserExist(string username)
        {
           return  await _context.Users.AnyAsync(x => x.UserName == username);

        }
    }
}
