using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Trex.Entity.Models;

namespace Trex.Service.Customers
{
    public class CustomerService : ICustomerService
    {
        private string BaseUrl = "https://northwind.now.sh/";

        #region List
        public async Task<IEnumerable<Customer>> List()
        {
            var customerList = await BaseUrl.AppendPathSegment("api/customers")
              .GetJsonAsync<List<Customer>>();

            return customerList;
        }
        #endregion

        #region GetById
        public async Task<Customer> GetById(string id)
        {
            var customer = await BaseUrl.AppendPathSegment("api/customers")
                .AppendPathSegment(id)
                .GetJsonAsync<Customer>();

            return customer;
        }
        #endregion

        #region Create
        public async Task<Customer> Create(Customer customer)
        {
            var customerCreate = await "https://northwind.now.sh/"
                           .AppendPathSegment("api/customers")
                           .PostJsonAsync(customer)
                           .ReceiveJson<Customer>();

            return customerCreate;
        }
        #endregion

        #region Update
        public async Task<Customer> Update(Customer customer)
        {
            var customerUpdate = await "https://northwind.now.sh/"
                            .AppendPathSegment("api/customers")
                            .AppendPathSegment(customer.Id)
                            .PutJsonAsync(customer)
                            .ReceiveJson<Customer>();

            return customerUpdate;
        }
        #endregion

        #region Delete
        public async Task<bool> Delete(string id)
        {
            await "https://northwind.now.sh/"
               .AppendPathSegment("api/customers")
               .AppendPathSegment(id)
               .DeleteAsync();

            return true;
        }
        #endregion
    }
}
