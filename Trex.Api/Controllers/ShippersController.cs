using Flurl;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trex.Entity.Models;
using Trex.Service.Shippers;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShippersController : ControllerBase
    {
        private readonly IShipperService _shipperService;

        public ShippersController(IShipperService shipperService)
        {
            _shipperService = shipperService;
        }
        #region GetAll
        [HttpGet]
        public async Task<IEnumerable<Shipper>> GetAll()
        {
            var shipperList = await _shipperService.List();

            return shipperList;
        }
        #endregion

        #region GetById
        [HttpGet("Get/{id}")]
        public async Task<Shipper> GetById(int id)
        {
            var shipper = await _shipperService.GetById(id);

            return shipper;
        }
        #endregion

        #region Create
        [HttpPost]
        public async Task<Shipper> Create(Shipper shipper)
        {
            var shipperCreate = await _shipperService.Create(shipper);

            return shipperCreate;
        }
        #endregion

        #region Update
        [HttpPut]
        public async Task<Shipper> Update(Shipper shipper)
        {
            var shipperUpdate = await _shipperService.Update(shipper);
            return shipperUpdate;
        }
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            await _shipperService.Delete(id);

            return true;
        }
        #endregion
    }
}
