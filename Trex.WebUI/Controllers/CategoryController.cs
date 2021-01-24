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
using Trex.WebUI.Models;

namespace Trex.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly string _apiEndPoint;

        public CategoryController(IOptions<ApiSettings> appSettings)
        {
            _apiEndPoint = appSettings.Value.EndPoint;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var categoryList = await _apiEndPoint.AppendPathSegment("categories")
               .GetJsonAsync<List<Category>>();

            return View(categoryList);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _apiEndPoint.AppendPathSegment("categories/get")
              .AppendPathSegment(id)
              .GetJsonAsync<Category>();

            return View(category);
        }

        public async Task<IActionResult> Create()
        {
            var model = new Category();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            await _apiEndPoint.AppendPathSegment("categories")
                                       .PostJsonAsync(category)
                                       .ReceiveJson<Category>();

            return RedirectToAction("List");
        }

        public async Task<IActionResult> Update(int id)
        {
            var category = await _apiEndPoint.AppendPathSegment("categories/get")
              .AppendPathSegment(id)
              .GetJsonAsync<Category>();

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Category category)
        {
           await _apiEndPoint.AppendPathSegment("categories")
                               .PutJsonAsync(category)
                               .ReceiveJson<Category>();

            return RedirectToAction("List");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _apiEndPoint.AppendPathSegment("categories")
                   .AppendPathSegment(id)
                   .DeleteAsync();

            return RedirectToAction("List");
        }
    }
}
