using Flurl;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trex.Entity.Models;
using Trex.Service.Categories;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly ILogger<CategoriesController> _logger;
        private readonly ICategoryService _categoryService;

        public CategoriesController(ILogger<CategoriesController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        #region GetAll
        [HttpGet]
        public async Task<IEnumerable<Category>> GetAll()
        {
            var categoryList = await _categoryService.List();
            return categoryList;
        }
        #endregion

        #region GetById
        [HttpGet("Get/{id}")]
        public async Task<Category> GetById(int id)
        {
            var categoryId = await _categoryService.GetById(id);
            return categoryId;
        }
        #endregion

        #region Create
        [HttpPost]
        public async Task<Category> Create(Category category)
        {
            var categoryCreate = await _categoryService.Create(category);
            return categoryCreate;
        }
        #endregion

        #region Update
        [HttpPut]
        public async Task<Category> Update(Category category)
        {
            var categoryUpdate = await _categoryService.Update(category);

            return categoryUpdate;
        }
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            await _categoryService.Delete(id);

            return true;
        }
        #endregion
    }
}
