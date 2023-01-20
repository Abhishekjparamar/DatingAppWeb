using DatingApp.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DatingAppWeb.Interfaces
{
    public interface IUserRepository
    {
        public Task<ActionResult<List<AppUser>>> GetUsers();
        public Task<ActionResult<AppUser>> GetAllUserById(int Id);
    }
}
