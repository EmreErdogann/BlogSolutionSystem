using AutoMapper;
using BlogSolutionSystem.Entities.Concrete;
using BlogSolutionSystem.Entities.Dtos.CategoryD;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSolutionSystem.Business.AutoMapper.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryAddDto, Category>().ReverseMap();
            CreateMap<CategoryUpdateDto, Category>().ReverseMap();
        }
    }
}
