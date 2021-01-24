using Flurl;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trex.Entity.Models;
using Trex.Service.Customers;
using Trex.Service.Employess;
using Trex.Service.Orders;
using Trex.ViewModel.Orders;
using Trex.WebUI.Models;

namespace Trex.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly string _apiEndPoint;

        public OrderController(IOptions<ApiSettings> appSettings)
        {
            _apiEndPoint = appSettings.Value.EndPoint;
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var orderList = await _apiEndPoint.AppendPathSegment("orders")
                 .GetJsonAsync<List<Order>>();

            return View(orderList);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _apiEndPoint.AppendPathSegment("orders/get")
              .AppendPathSegment(id)
              .GetJsonAsync<Order>();

            return View(order);
        }

        public async Task<IActionResult> Create()
        {
            var customers = await _apiEndPoint.AppendPathSegment("customers")
              .GetJsonAsync<IList<Customer>>();

            var employees = await _apiEndPoint.AppendPathSegment("employess")
              .GetJsonAsync<IList<Employee>>();

            var model = new OrderCreateViewModel {
                Customers = customers,
                Employees = employees
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Order order)
        {
            await _apiEndPoint.AppendPathSegment("orders")
                                     .PostJsonAsync(order)
                                     .ReceiveJson<Order>();

            return RedirectToAction("List");
        }

        public async Task<IActionResult> Update(int id)
        {
            var orderUpdate = await _apiEndPoint.AppendPathSegment("orders/get")
                .AppendPathSegment(id)
                .GetJsonAsync<Order>();

            return View(orderUpdate);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Order order)
        {
            await _apiEndPoint.AppendPathSegment("orders")
                              .PutJsonAsync(order)
                              .ReceiveJson<Order>();

            return RedirectToAction("List");
        }

        public async Task<IActionResult> Delete(int id)
        {

            await _apiEndPoint.AppendPathSegment("orders")
               .AppendPathSegment(id)
               .DeleteAsync();

            return RedirectToAction("List");
        }
    }


}
