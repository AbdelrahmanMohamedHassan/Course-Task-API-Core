using AutoMapper;
using DomainLayer.Models;
using Microsoft.AspNetCore.JsonPatch;
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
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public CreateUpdateReturnObject CreateProduct(ProductsForCreationsDto ProductsForCreationsDto)
        {
            var category = _unitOfWork.CategoryRepository.Get(ProductsForCreationsDto.CategoryID);
            var customObj = new CreateUpdateReturnObject { 
                customReturn = new CustomReturnObject(){
                Success = false, Message = "No Category Found"
                }
            };
            
            if (category == null)
            {
                return customObj;
            }
            var product = _mapper.Map<ProductsForCreationsDto, Product>(ProductsForCreationsDto);
            _unitOfWork.ProductRepository.Insert(product);
            _unitOfWork.SaveChanges();

            customObj.customReturn.Success = true;
            customObj.customReturn.Message = string.Empty;
            customObj.customReturn.Results = _mapper.Map<Product, ProductsDto>(product);
            customObj.ProductId = product.ID;
            return customObj;
        }

        public CustomReturnObject GetAllProducts(PagingParameters pagingParameters)
        {
            var products = _unitOfWork.ProductRepository.GetAll()
                .OrderBy(x => x.ID)
                .Skip((pagingParameters.PageNumber - 1) * pagingParameters.PageSize)
                .Take(pagingParameters.PageSize).ToList();
            CustomReturnObject customObj = new CustomReturnObject { Success = false, Message = "No Data Found" };
            if (products.Any())
            {
                customObj.Success = true;
                customObj.Message = string.Empty;
                customObj.Results = _mapper.Map<List<Product>, List<ProductsDto>>(products);
            }
            return customObj;
        }

        public CustomReturnObject GetAllProductsByCategory(int categoryID)
        {
            var products = _unitOfWork.ProductRepository.GetAll().Where(x => x.CategoryID == categoryID).ToList();
            CustomReturnObject customObj = new CustomReturnObject { Success = false, Message = "No Products Found" };
            if (products != null && products.Count() > 0)
            {
                customObj.Success = true;
                customObj.Message = string.Empty;
                customObj.Results = _mapper.Map<List<Product>, List<ProductsDto>>(products);
            }
            return customObj;
        }

        public CustomReturnObject GetProductById(int id)
        {
            var product = _unitOfWork.ProductRepository.Get(id);
            CustomReturnObject customObj = new CustomReturnObject { Success = false, Message = "No Data Found" };
            if (product != null)
            {
                customObj.Success = true;
                customObj.Message = string.Empty;
                customObj.Results = _mapper.Map<Product, ProductsDto>(product);
            }
            return customObj;
        }

        public CreateUpdateReturnObject UpdateProduct(ProductsForUpdateDto productsForUpdateDto)
        {

            var category = _unitOfWork.CategoryRepository.Get(productsForUpdateDto.CategoryID);
            var customObj = new CreateUpdateReturnObject
            {
                customReturn = new CustomReturnObject()
                {
                    Success = false,
                    Message = "No Category Found"
                }
            };
            if (category == null)
            {
                return customObj;
            }

            var product = _unitOfWork.ProductRepository.Get(productsForUpdateDto.Id);

            if (product == null)
            {
                customObj.customReturn.Message = "No Product Found";
                return customObj;
            }

            product = _mapper.Map<ProductsForUpdateDto, Product>(productsForUpdateDto);
            _unitOfWork.ProductRepository.Update(product);
            _unitOfWork.SaveChanges();

            customObj.customReturn.Success = true;
            customObj.customReturn.Message = string.Empty;
            customObj.customReturn.Results = _mapper.Map<Product, ProductsDto>(product);
            customObj.ProductId = product.ID;
            return customObj;
        }

        public CustomReturnObject DeleteProduct(int productId)
        {
            CustomReturnObject customObj = new CustomReturnObject { Success = false, Message = "No Product Found" };


            var product = _unitOfWork.ProductRepository.Get(productId);

            if (product == null)
            {
                customObj.Message = "No Product Found";
                return customObj;
            }

            _unitOfWork.ProductRepository.Delete(product);
            _unitOfWork.SaveChanges();

            customObj.Success = true;
            customObj.Message = "Product Deleted Successfully";

            return customObj;
        }

        public CustomReturnObject PartiallyUpdateProduct(int productId, JsonPatchDocument<ProductsForUpdateDto> productsPatch)
        {
            CustomReturnObject customObj = new CustomReturnObject { Success = false, Message = "No Product Found" };


            var product = _unitOfWork.ProductRepository.Get(productId);

            if (product == null)
            {
                customObj.Message = "No Product Found";
                return customObj;
            }

            var productsDTO = _mapper.Map<ProductsForUpdateDto>(product);
            productsPatch.ApplyTo(productsDTO);
            _mapper.Map(productsDTO, product);
            _unitOfWork.ProductRepository.Update(product);
            _unitOfWork.SaveChanges();

            customObj.Success = true;
            customObj.Message = "Product Updated Successfully";
            customObj.Results = productsDTO;
            return customObj;
        }
    }
}
