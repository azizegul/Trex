using Flurl;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trex.Entity.Models;
using Trex.Service.Categories;
using Trex.Service.Products;
using Trex.Service.Suppliers;
using Trex.ViewModel;
using Trex.WebUI.Models;

namespace Trex.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly string _apiEndPoint;

        //private readonly ISupplierService _supplierService;
        public ProductController(IOptions<ApiSettings> appSettings)
        {
            _apiEndPoint = appSettings.Value.EndPoint;
        }


        [HttpGet]
        public async Task<IActionResult> List()
        {
            var productList = await _apiEndPoint.AppendPathSegment("products")
               .GetJsonAsync<List<Product>>();

            return View(productList);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _apiEndPoint.AppendPathSegment("products/get").AppendPathSegment(id)
             .GetJsonAsync<Product>();

            return View(product);
        }

        public async Task<IActionResult> Create()
        {
            var categories = await _apiEndPoint.AppendPathSegment("categories")
               .GetJsonAsync<List<Category>>();

            var suppliers = await _apiEndPoint.AppendPathSegment("suppliers")
              .GetJsonAsync<List<Supplier>>();

            var model = new ProductCreateViewModel
            {
                Categories = categories,
                Suppliers = suppliers
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            await _apiEndPoint.AppendPathSegment("products")
                            .PostJsonAsync(product)
                            .ReceiveJson<Product>();

            return RedirectToAction("List");
        }

        public async Task<IActionResult> Update(int id)
        {

            var productUpdate = await _apiEndPoint.AppendPathSegment("products/get")
              .AppendPathSegment(id)
              .GetJsonAsync<Product>();

            return View(productUpdate);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Product product)
        {
            await _apiEndPoint.AppendPathSegment("products")
                              .PutJsonAsync(product)
                              .ReceiveJson<Product>();

            return RedirectToAction("List");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _apiEndPoint.AppendPathSegment("products")
                  .AppendPathSegment(id)
                  .DeleteAsync();

            return RedirectToAction("List");
        }
    }
}
