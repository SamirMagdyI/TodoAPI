using TodoAPI.Repositories;

namespace TodoAPI.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private ITodoRepository _todos;
        private IUserRepository _users;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public ITodoRepository Todos => _todos ??= new TodoRepository(_context);
        public IUserRepository Users => _users ??= new UserRepository(_context);

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
