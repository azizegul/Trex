using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Trex.Entity.Models;

namespace Trex.Service.Shippers
{
    public class ShipperService : IShipperService
    {
        private string BaseUrl = "https://northwind.now.sh/";

        #region List
        public async Task<IEnumerable<Shipper>> List()
        {
            var shipperList = await BaseUrl.AppendPathSegment("api/shippers")
          .GetJsonAsync<List<Shipper>>();

            return shipperList;
        }
        #endregion

        #region GetById
        public async Task<Shipper> GetById(int id)
        {
            var shipper = await BaseUrl.AppendPathSegment("api/shippers")
                .AppendPathSegment(id)
                .GetJsonAsync<Shipper>();

            return shipper;
        }
        #endregion

        #region Create
        public async Task<Shipper> Create(Shipper shipper)
        {
            var shipperCreate = await BaseUrl.AppendPathSegment("api/shippers")
                            .PostJsonAsync(shipper)
                            .ReceiveJson<Shipper>();

            return shipperCreate;
        }
        #endregion

        #region Update
        public async Task<Shipper> Update(Shipper shipper)
        {
            var shipperUpdate = await BaseUrl.AppendPathSegment("api/shippers")
                             .AppendPathSegment(shipper.Id)
                             .PutJsonAsync(shipper)
                             .ReceiveJson<Shipper>();

            return shipperUpdate;
        }
        #endregion

        #region Delete
        public async Task<bool> Delete(int id)
        {
            await BaseUrl.AppendPathSegment("api/shippers")
                 .AppendPathSegment(id)
                 .DeleteAsync();

            return true;
        }
        #endregion

    }
}
