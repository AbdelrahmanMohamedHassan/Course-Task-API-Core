using DomainLayer.Models;
using RepositoryLayer.Data;
using RepositoryLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {
    }
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDBContext context) : base(context)
        {

        }

    }
}
