using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TodoAPI.Data;
using TodoAPI.Dtos;
using TodoAPI.Models;

namespace TodoAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TodoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTodos()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.PrimarySid));
            var todos = await _unitOfWork.Todos.GetTodosByUserIdAsync(userId);
            var todosDto = _mapper.Map<IEnumerable<TodoDto>>(todos);
            return Ok(todosDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoById(int id)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.PrimarySid));
            var todo = await _unitOfWork.Todos.GetTodoByIdAndUserIdAsync(id, userId);
            if (todo == null) return NotFound();

            var todoDto = _mapper.Map<TodoDto>(todo);
            return Ok(todoDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodo([FromBody] TodoDto todoDto)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.PrimarySid));
            var todo = _mapper.Map<Todo>(todoDto);
            todo.SetUserId(userId);
            await _unitOfWork.Todos.AddTodoAsync(todo);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetTodoById), new {Id = todo.Id});
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodo(int id, [FromBody] TodoDto todoDto)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.PrimarySid));
            var todo = await _unitOfWork.Todos.GetTodoByIdAndUserIdAsync(id, userId);
            if (todo == null) return NotFound();

            _mapper.Map(todoDto, todo);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.PrimarySid));
            var todo = await _unitOfWork.Todos.GetTodoByIdAndUserIdAsync(id, userId);
            if (todo == null) return NotFound();

            await _unitOfWork.Todos.DeleteTodoAsync(id);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}
