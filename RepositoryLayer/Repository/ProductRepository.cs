using DomainLayer.Models;
using RepositoryLayer.Data;
using RepositoryLayer.Core;
using System;

namespace RepositoryLayer.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
    }
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDBContext context) : base(context)
        {}

    }
}
