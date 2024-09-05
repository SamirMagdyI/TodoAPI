using TodoAPI.Dtos;

namespace TodoAPI.Services
{
    public interface IExternalTodoService
    {
        Task<IEnumerable<TodoDto>> FetchTodosAsync(int page = 1, int pageSize = 10);
    }
}
