using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoAPI.Services;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiveTodoController : ControllerBase
    {
        private readonly IExternalTodoService _externalTodoService;

        public LiveTodoController(IExternalTodoService externalTodoService)
        {
            _externalTodoService = externalTodoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetExternalTodos(int page = 1, int pageSize = 10)
        {
            var todos = await _externalTodoService.FetchTodosAsync(page, pageSize);
            return Ok(todos);
        }
    }
}
