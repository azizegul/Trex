using Flurl;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trex.Entity.Models;
using Trex.Service.Categories;
using Trex.Service.Products;
using Trex.Service.Suppliers;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ISupplierService _supplierService;


        public ProductsController(IProductService productService, ICategoryService categoryService, ISupplierService supplierService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _supplierService = supplierService;
        }

        #region GetAll
        [HttpGet]
        public async Task<IEnumerable<Product>> GetAll()
        {
            var productList = await _productService.List();
            return productList;
        }
        #endregion

        #region GetById
        [HttpGet("Get/{id}")]
        public async Task<Product> GetById(int id)
        {
            var product = await _productService.GetById(id);

            return product;
        }
        #endregion

        #region Create
        [HttpPost]
        public async Task<Product> Create(Product product)
        {
            var productCreate = await _productService.Create(product);

            //_logger.LogTrace($"GetAll methods executed with paramters : {category} and response : {categoryPost}  ");

            return productCreate;
        }
        #endregion

        #region Update
        [HttpPut]
        public async Task<Product> Update(Product product)
        {
            var productUpdate = await _productService.Update(product);

            return productUpdate;
        }
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            await _productService.Delete(id);

            return true;
        }
        #endregion
    }
}
