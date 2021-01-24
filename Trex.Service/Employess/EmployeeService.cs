using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Trex.Entity.Models;

namespace Trex.Service.Employess
{
    public class EmployeeService : IEmployeeService
    {

        private readonly string BaseUrl = "https://northwind.now.sh/";

        #region List
        public async Task<IEnumerable<Employee>> List()
        {
            var employeeList = await BaseUrl.AppendPathSegment("api/employess")
               .GetJsonAsync<List<Employee>>();

            return employeeList;
        }
        #endregion

        #region GetById
        public async Task<Employee> GetById(int id)
        {
            var employee = await BaseUrl.AppendPathSegment("api/employess")
               .AppendPathSegment(id)
               .GetJsonAsync<Employee>();

            return employee;
        }
        #endregion

        #region Create
        public async Task<Employee> Create(Employee employee)
        {
            var employeeCreate = await BaseUrl.AppendPathSegment("api/employess")
                              .PostJsonAsync(employee)
                              .ReceiveJson<Employee>();


            return employeeCreate;
        }
        #endregion

        #region Update
        public async Task<Employee> Update(Employee employee)
        {
            var employeeUpdate = await BaseUrl.AppendPathSegment("api/employess")
                             .AppendPathSegment(employee.Id)
                             .PutJsonAsync(employee)
                             .ReceiveJson<Employee>();

            return employeeUpdate;
        }
        #endregion

        #region Delete
        public async Task<bool> Delete(int id)
        {
            await BaseUrl.AppendPathSegment("api/employess")
              .AppendPathSegment(id)
              .DeleteAsync();

            return true;
        }
        #endregion

    }
}
