using DatingApp.Data;
using DatingApp.Entities;
using DatingAppWeb.DTOs;
using DatingAppWeb.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace DatingAppWeb.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DataContext _context;
        private readonly ITokenRepository _tokenService;
        public AccountRepository(DataContext context, ITokenRepository tokenService)
        {
            _tokenService = tokenService;
            _context = context;
        }
        public async Task<ActionResult<AppUser>> Login(LoginDTO loginDTO)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == loginDTO.UserName);
            if (user == null) return null;

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));

            for (int i = 0; i < computeHash.Length; i++)
            {
                if (computeHash[i] != user.PasswordHash[i]) return null;
            }
            var token = _tokenService.GetToken(loginDTO);
            return user;
        }

        public Task<ActionResult<AppUser>> Register(AppUserDTO usermodel)
        {
            throw new NotImplementedException();
        }
    }
}
