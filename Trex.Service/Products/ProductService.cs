using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trex.Entity.Models;
using Trex.Service.Categories;
using Trex.Service.Suppliers;

namespace Trex.Service.Products
{
    public class ProductService : IProductService
    {
        private string BaseUrl = "https://northwind.now.sh/";
        private readonly ICategoryService _categoryService;
        private readonly ISupplierService _supplierService;


        public ProductService(ICategoryService categoryService, ISupplierService supplierService)
        {
            _categoryService = categoryService;
            _supplierService = supplierService;
        }

        #region List
        public async Task<IEnumerable<Product>> List()
        {
            var productList = await BaseUrl.AppendPathSegment("api/products")
              .GetJsonAsync<List<Product>>();

            var categoryList = await _categoryService.List();
            var supplierList = await _supplierService.List();

            foreach (var product in productList)
            {
                product.Category = categoryList.FirstOrDefault(k => k.Id == product.CategoryId);
                product.Supplier = supplierList.FirstOrDefault(k => k.Id == product.SupplierId);
            }

            return productList;
        }
        #endregion

        #region GetById
        public async Task<Product> GetById(int id)
        {
            var product = await BaseUrl.AppendPathSegment("api/products")
                 .AppendPathSegment(id)
                 .GetJsonAsync<Product>();

            return product;
        }
        #endregion

        #region Create
        public async Task<Product> Create(Product product)
        {
            var productCreate = await BaseUrl.AppendPathSegment("api/products")
                      .PostJsonAsync(product)
                      .ReceiveJson<Product>();

            return productCreate;
        }
        #endregion

        #region Update
        public async Task<Product> Update(Product product)
        {
            var productUpdate = await BaseUrl.AppendPathSegment("api/products")
                                  .AppendPathSegment(product.Id)
                                  .PutJsonAsync(product)
                                  .ReceiveJson<Product>();

            return productUpdate;
        }
        #endregion

        #region Delete
        public async Task<bool> Delete(int id)
        {
            await BaseUrl.AppendPathSegment("api/products")
                       .AppendPathSegment(id)
                       .DeleteAsync();

            return true;
        }
        #endregion
    }
}
