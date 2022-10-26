using DomainLayer.Models;
using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Interfaces
{
    public interface ICategoryService
    {
        CustomReturnObject GetCategories();
        Category CategoryExist(int categoryId);
    }
}
