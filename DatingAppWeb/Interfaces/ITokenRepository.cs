using DatingApp.Entities;
using DatingAppWeb.DTOs;

namespace DatingAppWeb.Interfaces
{
    public interface ITokenRepository
    {
        string GetToken(LoginDTO userDTO);
    }
}
