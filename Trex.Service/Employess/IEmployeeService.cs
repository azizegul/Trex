using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Trex.Entity.Models;

namespace Trex.Service.Employess
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> List();
        Task<Employee> GetById(int id);
        Task<Employee> Create(Employee employee);
        Task<Employee> Update(Employee employee);
        Task<bool> Delete(int id);
    }
}
