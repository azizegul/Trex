using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Trex.Entity.Models;

namespace Trex.Service.Customers
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> List();
        Task<Customer> GetById(string id);
        Task<Customer> Create(Customer customer);
        Task<Customer> Update(Customer customer);
        Task<bool> Delete(string id);
    }
}
