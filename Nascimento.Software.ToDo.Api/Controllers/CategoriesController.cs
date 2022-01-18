using Domain.ToDos;
using Infra.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nascimento.Software.ToDo.Api.DTO.ToDos;

namespace Nascimento.Software.ToDo.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IDAL<Category> _dalCategory;
        public CategoriesController(IDAL<Category> _dal)
        {
            _dalCategory = _dal;
        }
        [HttpGet]
        [Route("get-all-categories")]
        public async Task<ActionResult> GetCategoriesAsync()
        {
            return Ok(await _dalCategory.GetAllAsync());
        }
        [HttpGet]
        [Route("get-category-by-id")]
        public async Task<ActionResult> GetCategoryByIdAsync
            ([FromHeader] Guid Id)
        {
            return Ok(await _dalCategory.GetAsync(Id));
        }
        [HttpPost]
        [Route("insert-category")]
        public async Task<ActionResult> InsertCategory
            ([FromBody] CategoryDTO dto)
        {
            var category = new Category()
            {
                Description = dto.Description,
                Name = dto.Name,
            };
            var inserted = await _dalCategory.InsertAsync(category);
            if (inserted) return Ok();

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

    }
}
