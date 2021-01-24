using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Trex.Entity.Models;

namespace Trex.Service.Categories
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> List();
        Task<Category> GetById(int id);
        Task<Category> Create(Category category);
        Task<Category> Update(Category category);
        Task<bool> Delete(int id);
    }
}
