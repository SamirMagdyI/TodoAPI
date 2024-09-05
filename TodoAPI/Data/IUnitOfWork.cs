using TodoAPI.Repositories;

namespace TodoAPI.Data
{
    public interface IUnitOfWork
    {
        ITodoRepository Todos { get; }
        IUserRepository Users { get; }
        Task<int> CompleteAsync();
    }
}
