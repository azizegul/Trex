using Flurl;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trex.Entity.Models;
using Trex.Service.Employess;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployessController : ControllerBase
    {

        private readonly IEmployeeService _employeeService;

        public EmployessController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        #region GetAll
        [HttpGet]
        public async Task<IEnumerable<Employee>> GetAll()
        {
            var employeeList = await _employeeService.List();

            return employeeList;
        }
        #endregion

        #region GetById
        [HttpGet("Get/{id}")]
        public async Task<Employee> GetById(int id)
        {
            var employee = await _employeeService.GetById(id);

            return employee;
        }
        #endregion

        #region Create
        [HttpPost]
        public async Task<Employee> Create(Employee employee)
        {
            var employeeCreate = await _employeeService.Create(employee);


            return employeeCreate;
        }
        #endregion

        #region Update
        [HttpPut]
        public async Task<Employee> Update(Employee employee)
        {
           
            var employeeUpdate = await _employeeService.Update(employee);

            return employeeUpdate;
        }
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            await _employeeService.Delete(id);

            return true;
        }
        #endregion
    }
}
