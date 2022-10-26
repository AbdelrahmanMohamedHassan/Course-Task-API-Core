using DomainLayer.Models;
using Microsoft.AspNetCore.JsonPatch;
using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Interfaces
{
    public interface IProductService
    {
        CustomReturnObject GetAllProducts(PagingParameters pagingParameters);
        CustomReturnObject GetAllProductsByCategory(int categoryID);
        CustomReturnObject GetProductById(int id);
        CreateUpdateReturnObject CreateProduct(ProductsForCreationsDto ProductsForCreationsDto);
        CreateUpdateReturnObject UpdateProduct(ProductsForUpdateDto productsForUpdateDto);
        CustomReturnObject DeleteProduct(int id);
        CustomReturnObject PartiallyUpdateProduct(int productId, JsonPatchDocument<ProductsForUpdateDto> productsPatch);
    }
}
