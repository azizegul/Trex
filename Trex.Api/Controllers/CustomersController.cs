using Flurl;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trex.Entity.Models;
using Trex.Service.Customers;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        #region GetAll
        [HttpGet]
        public async Task<IEnumerable<Customer>> GetAll()
        {
            var customerList = await _customerService.List();
            return customerList;
        }
        #endregion

        #region GetById
        [HttpGet("Get/{id}")]
        public async Task<Customer> GetById(string id)
        {
            var customer = await _customerService.GetById(id);
              
            return customer;
        }
        #endregion

        #region Create
        [HttpPost]
        public async Task<Customer> Create(Customer customer)
        {
            var customerCreate = await _customerService.Create(customer);

            return customerCreate;
        }
        #endregion

        #region Update
        [HttpPut]
        public async Task<Customer> Update(Customer customer)
        {
            var customerUpdate = await _customerService.Update(customer);

            return customerUpdate;
        }
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public async Task<bool> Delete(string id)
        {
            await _customerService.Delete(id);

            return true;
        }
        #endregion
    }
}
