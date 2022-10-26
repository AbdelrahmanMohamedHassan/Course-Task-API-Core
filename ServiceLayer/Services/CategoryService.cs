using AutoMapper;
using DomainLayer.Models;
using RepositoryLayer;
using RepositoryLayer.Core;
using ServiceLayer.Interfaces;
using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public Category CategoryExist(int categoryId)
        {
            if (categoryId == null)
            {
                throw new ArgumentNullException(nameof(categoryId));
            }
            return _unitOfWork.CategoryRepository.Get(categoryId);
        }

        public CustomReturnObject GetCategories()
        {
            List<Category> categories = _unitOfWork.CategoryRepository.GetAll().ToList();
            CustomReturnObject customObj = new CustomReturnObject { Success = false , Message = "No Data Found" };
            if (categories.Any())
            {
                customObj.Success = true;
                customObj.Message = string.Empty;
                customObj.Results = _mapper.Map<List<Category>, List<CategoryDto>>(categories);
            }
            return customObj;
        }
    
    
    }
}
