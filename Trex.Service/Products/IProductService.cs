using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Trex.Entity.Models;

namespace Trex.Service.Products
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> List();
        Task<Product> GetById(int id);
        Task<Product> Create(Product product);
        Task<Product> Update(Product product);
        Task<bool> Delete(int id);
    }
}
