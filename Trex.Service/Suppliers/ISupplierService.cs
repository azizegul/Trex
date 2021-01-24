using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Trex.Entity.Models;

namespace Trex.Service.Suppliers
{
    public interface ISupplierService
    {
        Task<IEnumerable<Supplier>> List();
        Task<Supplier> GetById(int id);
        Task<Supplier> Create(Supplier supplier);
        Task<Supplier> Update(Supplier supplier);
        Task<bool> Delete(int id);
    }
}
