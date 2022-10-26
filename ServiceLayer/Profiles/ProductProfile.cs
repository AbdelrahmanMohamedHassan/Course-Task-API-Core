using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DomainLayer.Models;
using ServiceLayer.Models;

namespace ServiceLayer.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductsDto>();
            CreateMap<ProductsForCreationsDto,Product>();
            CreateMap<ProductsForUpdateDto,Product>();
        }
    }
}
