
namespace LeaveManagement.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAll();    
        Task<T> Get(Guid id);    
        Task<T> Add(T entity);
       // Task<bool> Exists(int id);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
