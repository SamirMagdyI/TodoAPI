using Microsoft.EntityFrameworkCore;
using TodoAPI.Data;
using TodoAPI.Models;

namespace TodoAPI.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ApplicationDbContext _context;

        public TodoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Todo>> GetAllTodosAsync()
        {
            return await _context.Todos.ToListAsync();
        }

        public async Task<IEnumerable<Todo>> GetTodosByUserIdAsync(int userId)
        {
            return await _context.Todos.Where(t => t.UserId == userId).ToListAsync();
        }

        public async Task<Todo> GetTodoByIdAsync(int id)
        {
            return await _context.Todos.FindAsync(id);
        }

        public async Task<Todo> GetTodoByIdAndUserIdAsync(int id, int userId)
        {
            return await _context.Todos.FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);
        }

        public async Task AddTodoAsync(Todo todo)
        {
           await _context.Todos.AddAsync(todo);
        }

        public void UpdateTodoAsync(Todo todo)
        {
            _context.Todos.Update(todo);
        }

        public async Task DeleteTodoAsync(int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo != null)
            {
                _context.Todos.Remove(todo);
            }
        }
    }
}
