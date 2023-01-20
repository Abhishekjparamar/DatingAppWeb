using DatingApp.Entities;
using DatingAppWeb.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DatingAppWeb.Repository
{
    public class UserReository : IUserRepository
    {
        public Task<ActionResult<AppUser>> GetAllUserById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<List<AppUser>>> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
