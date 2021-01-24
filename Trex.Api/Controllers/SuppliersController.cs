using Flurl;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trex.Entity.Models;
using Trex.Service.Suppliers;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }
        #region GetAll
        [HttpGet]
        public async Task<IEnumerable<Supplier>> GetAll()
        {
            var supplierList = await _supplierService.List();

            return supplierList;
        }
        #endregion

        #region GetById
        [HttpGet("Get/{id}")]
        public async Task<Supplier> GetById(int id)
        {
            var supplier = await _supplierService.GetById(id);
            return supplier;
        }
        #endregion

        #region Create
        [HttpPost]
        public async Task<Supplier> Create(Supplier supplier)
        {
            var supplierCreate = await _supplierService.Create(supplier);

            //_logger.LogTrace($"GetAll methods executed with paramters : {category} and response : {categoryPost}  ");

            return supplierCreate;
        }
        #endregion

        #region Update
        [HttpPut]
        public async Task<Supplier> Update(Supplier supplier)
        {
            var supplierUpdate = await _supplierService.Update(supplier);

            return supplierUpdate;
        }
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            await _supplierService.Delete(id);

            return true;
        }
        #endregion
    }
}
