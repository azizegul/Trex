using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Trex.Entity.Models;

namespace Trex.Service.Shippers
{
    public interface IShipperService
    {
        Task<IEnumerable<Shipper>> List();
        Task<Shipper> GetById(int id);
        Task<Shipper> Create(Shipper shipper);
        Task<Shipper> Update(Shipper shipper);
        Task<bool> Delete(int id);
    }
}
