using Flurl;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trex.Entity.Models;
using Trex.Service.Suppliers;
using Trex.WebUI.Models;

namespace Trex.WebUI.Controllers
{
    public class SupplierController : Controller
    {
        private readonly string _apiEndPoint;

        //private readonly ISupplierService _supplierService;
        public SupplierController(IOptions<ApiSettings> appSettings)
        {
            _apiEndPoint = appSettings.Value.EndPoint;
        }


        [HttpGet]
        public async Task<IActionResult> List()
        {
            var supplierList = await _apiEndPoint.AppendPathSegment("suppliers")
              .GetJsonAsync<List<Supplier>>();

            return View(supplierList);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var supplier = await _apiEndPoint.AppendPathSegment("suppliers/get").AppendPathSegment(id)
               .GetJsonAsync<Supplier>();

            return View(supplier);
        }

        public async Task<IActionResult> Create()
        {
            var model = new Supplier();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Supplier supplier)
        {
            await _apiEndPoint.AppendPathSegment("suppliers")
                             .PostJsonAsync(supplier)
                             .ReceiveJson<Supplier>();

            return RedirectToAction("List");
        }

        public async Task<IActionResult> Update(int id)
        {
            var supplier = await _apiEndPoint.AppendPathSegment("suppliers/get")
              .AppendPathSegment(id)
              .GetJsonAsync<Supplier>();

            return View(supplier);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Supplier supplier)
        {
            await _apiEndPoint.AppendPathSegment("suppliers")
                              .PutJsonAsync(supplier)
                              .ReceiveJson<Supplier>();

            return RedirectToAction("List");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _apiEndPoint.AppendPathSegment("suppliers")
                   .AppendPathSegment(id)
                   .DeleteAsync();

            return RedirectToAction("List");
        }
    }
}
