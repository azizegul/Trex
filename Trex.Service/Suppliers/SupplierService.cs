using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Trex.Entity.Models;

namespace Trex.Service.Suppliers
{
    public class SupplierService : ISupplierService
    {
        private string BaseUrl = "https://northwind.now.sh/";

        #region List
        public async Task<IEnumerable<Supplier>> List()
        {
            var supplierList = await BaseUrl.AppendPathSegment("api/suppliers")
             .GetJsonAsync<List<Supplier>>();

            return supplierList;
        }
        #endregion

        #region GetById
        public async Task<Supplier> GetById(int id)
        {
            var supplier = await BaseUrl.AppendPathSegment("api/suppliers")
                  .AppendPathSegment(id)
                  .GetJsonAsync<Supplier>();

            return supplier;
        }
        #endregion

        #region Create
        public async Task<Supplier> Create(Supplier supplier)
        {
            var supplierCreate = await BaseUrl
                           .AppendPathSegment("api/suppliers")
                           .PostJsonAsync(supplier)
                           .ReceiveJson<Supplier>();

            return supplierCreate;
        }
        #endregion

        #region Update
        public async Task<Supplier> Update(Supplier supplier)
        {
            var supplierUpdate = await BaseUrl
                         .AppendPathSegment("api/suppliers")
                         .AppendPathSegment(supplier.Id)
                         .PutJsonAsync(supplier)
                         .ReceiveJson<Supplier>();

            return supplierUpdate;
        }
        #endregion

        #region Delete
        public async Task<bool> Delete(int id)
        {

            await BaseUrl
                .AppendPathSegment("api/suppliers")
                .AppendPathSegment(id)
                .DeleteAsync();

            return true;
        }
        #endregion

    }
}
