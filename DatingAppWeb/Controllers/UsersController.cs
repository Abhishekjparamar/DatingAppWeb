using AutoMapper;
using DatingApp.Data;
using DatingApp.Entities;
using DatingAppWeb.DTOs;
using DatingAppWeb.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingAppWeb.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public UsersController(DataContext context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        [Route("GetUsers")]
        public async Task<ActionResult<List<MemberDTO>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            var usersToReturn=_mapper.Map<IEnumerable<MemberDTO>>(users);
            return Ok(usersToReturn);
        }

        [HttpGet]
        [Route("GetAllUserById")]
        public async Task<ActionResult<MemberDTO>> GetAllUserById(int Id)
        {
            var data= await _context.Users.SingleOrDefaultAsync(x => x.Id == Id);
            var usersToReturn = _mapper.Map<MemberDTO>(data);
            return usersToReturn;
        }

    }
}
