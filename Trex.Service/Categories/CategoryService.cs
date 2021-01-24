using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Trex.Entity.Models;

namespace Trex.Service.Categories
{
    public class CategoryService : ICategoryService
    {
        private string BaseUrl = "https://northwind.now.sh/";

        #region List
        public async Task<IEnumerable<Category>> List()
        {
            var categoryList = await BaseUrl.AppendPathSegment("api/categories")
                  .GetJsonAsync<List<Category>>();

            return categoryList;
        }
        #endregion

        #region GetById
        public async Task<Category> GetById(int id)
        {
            var category = await BaseUrl.AppendPathSegment("api/categories")
                .AppendPathSegment(id)
                .GetJsonAsync<Category>();

            return category;
        }
        #endregion

        #region Create
        public async Task<Category> Create(Category category)
        {
            var categoryCreate = await BaseUrl.AppendPathSegment("api/categories")
                             .PostJsonAsync(category)
                             .ReceiveJson<Category>();


            return categoryCreate;
        }
        #endregion

        #region Update
        public async Task<Category> Update(Category category)
        {
            var categoryUpdate = await BaseUrl.AppendPathSegment("api/categories")
                               .AppendPathSegment(category.Id)
                               .PutJsonAsync(category)
                               .ReceiveJson<Category>();

            return categoryUpdate;
        }

        #endregion

        #region Delete
        public async Task<bool> Delete(int id)
        {
            await BaseUrl.AppendPathSegment("api/categories")
                   .AppendPathSegment(id)
                   .DeleteAsync();

            return true;
        }
        #endregion
    }
}
