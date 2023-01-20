using DatingApp.Entities;
using DatingAppWeb.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DatingAppWeb.Interfaces
{
    public interface IAccountRepository
    {
        public  Task<ActionResult<AppUser>> Login(LoginDTO loginDTO);
        public Task<ActionResult<AppUser>> Register(AppUserDTO usermodel);
    }
}
