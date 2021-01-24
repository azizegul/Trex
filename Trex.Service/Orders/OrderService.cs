using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Trex.Entity.Models;

namespace Trex.Service.Orders
{
    public class OrderService : IOrderService
    {
        private string BaseUrl = "https://northwind.now.sh/";

        #region List
        public async Task<IEnumerable<Order>> List()
        {
            var orderList = await BaseUrl.AppendPathSegment("api/orders")
                .GetJsonAsync<List<Order>>();

            return orderList;
        }
        #endregion

        #region GetById
        public async Task<Order> GetById(int id)
        {
            var order = await BaseUrl.AppendPathSegment("api/orders")
                   .AppendPathSegment(id)
                   .GetJsonAsync<Order>();

            return order;
        }
        #endregion

        #region Create
        public async Task<Order> Create(Order order)
        {
            var orderPost = await BaseUrl.AppendPathSegment("api/orders")
                           .PostJsonAsync(order)
                           .ReceiveJson<Order>();

            return orderPost;
        }

        #endregion

        #region Update
        public async Task<Order> Update(Order order)
        {
            var orderUpdate = await BaseUrl.AppendPathSegment("api/orders")
                              .AppendPathSegment(order.Id)
                              .PutJsonAsync(order)
                              .ReceiveJson<Order>();

            return orderUpdate;
        }
        #endregion

        #region Delete
        public async Task<bool> Delete(int id)
        {
            await BaseUrl.AppendPathSegment("api/orders")
                        .AppendPathSegment(id)
                        .DeleteAsync();

            return true;
        }
        #endregion
    }
}
