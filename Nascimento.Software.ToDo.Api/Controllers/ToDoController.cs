using Infra.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nascimento.Software.ToDo.Api.DTO.ToDos;

namespace Nascimento.Software.ToDo.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IDAL<Domain.ToDos.ToDo> _toDoDAL;
        public ToDoController(IDAL<Domain.ToDos.ToDo> _toDoDAL)
        {
            this._toDoDAL = _toDoDAL;
        }
        [HttpGet]
        [Route("get-all-todos")]
        public async Task<ActionResult> GetAllToDosAsync()
        {
            return Ok(await _toDoDAL.GetAllAsync());
        }
        [HttpGet]
        [Route("get-todo-by-id")]
        public async Task<ActionResult> GetToDoByIdAsync
            ([FromHeader] Guid Id)
        {
            return Ok(await _toDoDAL.GetAsync(Id));
        }
        [HttpPost]
        [Route("insert-todo")]
        public async Task<ActionResult> InsertToDoAsync
            ([FromBody] ToDoDTO dto)
        {
            var toDo = new Domain.ToDos.ToDo()
            {
                Title = dto.Title,
                CategoryId = dto.CategoryId,
                Description = dto.Description,
                IsCompleted = dto.IsCompleted,
                UserId = dto.UserId,
            };
            var inserted = await _toDoDAL.InsertAsync(toDo);
            if (inserted) return Ok();

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

    }
}
