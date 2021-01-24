using Flurl;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trex.Entity.Models;
using Trex.Service.Customers;
using Trex.Service.Employess;
using Trex.Service.Orders;
using Trex.ViewModel.Orders;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;
        private readonly IEmployeeService _employeeService;

        public OrdersController(IOrderService orderService, ICustomerService customerService, IEmployeeService employeeService)
        {
            _orderService = orderService;
            _customerService = customerService;
            _employeeService = employeeService;
        }

        #region GetAll
        [HttpGet]
        public async Task<IEnumerable<Order>> GetAll()
        {
            var orderList = await _orderService.List();

            return orderList;
        }
        #endregion

        #region GetById
        [HttpGet("Get/{id}")]
        public async Task<Order> GetById(int id)
        {
            var order = await _orderService.GetById(id);

            return order;
        }
        #endregion

        #region Create
        [HttpPost]
        public async Task<Order> Create(Order order)
        {
            //var model = new OrderCreateViewModel
            //{
            //    Customers = await _customerService.List(),
            //    Employees = await _employeeService.List()
            //};

            var result = await _orderService.Create(order);

            return result;
        }
        #endregion

        #region Update
        [HttpPut]
        public async Task<Order> Update(Order order)
        {
            var orderUpdate = await _orderService.Update(order);
            return orderUpdate;
        }
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            await _orderService.Delete(id);

            return true;
        }
        #endregion
    }
}
