using AutoMapper;
using DatingApp.Entities;
using DatingAppWeb.DTOs;

namespace DatingAppWeb.Helpers
{
    public class AutoMaperProfile:Profile
    {
        public AutoMaperProfile()
        {
            CreateMap<AppUser,MemberDTO>()
                .ForMember(dest=>dest.Photos,opt=>opt.MapFrom(src=>src.Photos.FirstOrDefault(x=>x.IsMain).Url
                ));
            CreateMap<Photo,PhotoDTO>();
        }
    }
}
