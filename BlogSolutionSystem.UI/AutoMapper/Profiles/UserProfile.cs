using AutoMapper;
using BlogSolutionSystem.Entities.Concrete;
using BlogSolutionSystem.Entities.Dtos.UserD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSolutionSystem.UI.AutoMapper.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserAddDto, User>();
            CreateMap<UserUpdateDto, User>().ReverseMap();
        }
    }
}
