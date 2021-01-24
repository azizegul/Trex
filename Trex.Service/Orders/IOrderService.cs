using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Trex.Entity.Models;

namespace Trex.Service.Orders
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> List();
        Task<Order> GetById(int id);
        Task<Order> Create(Order order);
        Task<Order> Update(Order order);
        Task<bool> Delete(int id);
    }
}
