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
using Trex.WebUI.Models;

namespace Trex.WebUI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly string _apiEndPoint;

        public CustomerController(IOptions<ApiSettings> appSettings)
        {
            _apiEndPoint = appSettings.Value.EndPoint;
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var customerList = await _apiEndPoint.AppendPathSegment("customers")
               .GetJsonAsync<List<Customer>>();

            return View(customerList);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(string id)
        {
            var customer = await _apiEndPoint.AppendPathSegment("customers/get")
             .AppendPathSegment(id)
             .GetJsonAsync<Customer>();

            return View(customer);
        }

        public async Task<IActionResult> Create()
        {
            var model = new Customer();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            await _apiEndPoint.AppendPathSegment("customers")
                                      .PostJsonAsync(customer)
                                      .ReceiveJson<Customer>();

            return RedirectToAction("List");
        }

        public async Task<IActionResult> Update(string id)
        {
            var customerUpdate = await _apiEndPoint.AppendPathSegment("customers/get")
                .AppendPathSegment(id)
                .GetJsonAsync<Customer>();

            return View(customerUpdate);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Customer customer)
        {
            await _apiEndPoint.AppendPathSegment("customers")
                               .PutJsonAsync(customer)
                               .ReceiveJson<Customer>();

            return RedirectToAction("List");
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _apiEndPoint.AppendPathSegment("customers")
               .AppendPathSegment(id)
               .DeleteAsync();

            return RedirectToAction("List");
        }
    }
}
