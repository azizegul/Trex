using Flurl;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trex.Entity.Models;
using Trex.Service.Shippers;
using Trex.WebUI.Models;

namespace Trex.WebUI.Controllers
{
    public class ShipperController : Controller
    {
        private readonly string _apiEndPoint;

        //private readonly ISupplierService _supplierService;
        public ShipperController(IOptions<ApiSettings> appSettings)
        {
            _apiEndPoint = appSettings.Value.EndPoint;
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var shipperList = await _apiEndPoint.AppendPathSegment("shippers")
              .GetJsonAsync<List<Shipper>>();

            return View(shipperList);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var shipper = await _apiEndPoint.AppendPathSegment("shippers/get").AppendPathSegment(id)
                .GetJsonAsync<Shipper>();

            return View(shipper);
        }

        public async Task<IActionResult> Create()
        {
            var model = new Shipper();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Shipper shipper)
        {
            await _apiEndPoint.AppendPathSegment("shippers")
                           .PostJsonAsync(shipper)
                           .ReceiveJson<Shipper>();

            return RedirectToAction("List");
        }

        public async Task<IActionResult> Update(int id)
        {
            var shipper = await _apiEndPoint.AppendPathSegment("shippers/get")
                .AppendPathSegment(id)
                .GetJsonAsync<Shipper>();

            return View(shipper);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Shipper shipper)
        {
            await _apiEndPoint.AppendPathSegment("shippers")
                             .PutJsonAsync(shipper)
                             .ReceiveJson<Shipper>();


            return RedirectToAction("List");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _apiEndPoint.AppendPathSegment("shippers")
                  .AppendPathSegment(id)
                  .DeleteAsync();
            return RedirectToAction("List");
        }
    }
}
