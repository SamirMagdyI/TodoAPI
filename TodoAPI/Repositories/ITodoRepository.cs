using TodoAPI.Models;

namespace TodoAPI.Repositories
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> GetAllTodosAsync();
        Task<IEnumerable<Todo>> GetTodosByUserIdAsync(int userId);
        Task<Todo> GetTodoByIdAsync(int id);
        Task<Todo> GetTodoByIdAndUserIdAsync(int id, int userId);
        Task AddTodoAsync(Todo todo);
        void UpdateTodoAsync(Todo todo);
        Task DeleteTodoAsync(int id);
    }
}
