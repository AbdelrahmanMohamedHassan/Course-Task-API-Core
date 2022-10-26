using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DomainLayer.Models;
using ServiceLayer.Models;

namespace ServiceLayer.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>();
        }
    }
}
