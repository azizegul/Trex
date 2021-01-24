using Flurl;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trex.Entity.Models;
using Trex.Service.Employess;
using Trex.WebUI.Models;

namespace Trex.WebUI.Controllers
{
    public class EmployessController : Controller
    {
        private readonly string _apiEndPoint;

        public EmployessController(IOptions<ApiSettings> appSettings)
        {
            _apiEndPoint = appSettings.Value.EndPoint;
        }


        [HttpGet]
        public async Task<IActionResult> List()
        {
            var employeeList = await _apiEndPoint.AppendPathSegment("employess")
              .GetJsonAsync<List<Employee>>();

            return View(employeeList);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _apiEndPoint.AppendPathSegment("employess/get")
                 .AppendPathSegment(id)
                 .GetJsonAsync<Employee>();

            return View(employee);
        }

        public async Task<IActionResult> Create()
        {
            var model = new Employee();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee, string territoryIdList)
        {
            employee.TerritoryIds = territoryIdList.Split(",").Select(s => int.Parse(s)).ToList();

            await _apiEndPoint.AppendPathSegment("employess")
                                         .PostJsonAsync(employee)
                                         .ReceiveJson<Employee>();

            return RedirectToAction("List");
        }

        public async Task<IActionResult> Update(int id)
        {
            var employeeUpdate = await _apiEndPoint.AppendPathSegment("employess/get")
              .AppendPathSegment(id)
              .GetJsonAsync<Employee>();

            return View(employeeUpdate);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Employee employee, string territoryIdList)
        {
            employee.TerritoryIds = territoryIdList.Split(",").Select(s => int.Parse(s)).ToList();

            await _apiEndPoint.AppendPathSegment("employess")
                               .PutJsonAsync(employee)
                               .ReceiveJson<Employee>();

            return RedirectToAction("List");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _apiEndPoint.AppendPathSegment("employess")
                .AppendPathSegment(id)
                .DeleteAsync();

            return RedirectToAction("List");
        }
    }
}
