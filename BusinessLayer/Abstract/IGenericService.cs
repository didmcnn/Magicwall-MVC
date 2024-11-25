using System.Linq.Expressions;

namespace BusinessLayer.Abstract;

public interface IGenericService<T>
{
    Task<T> CreateAsync(T t);
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<T> GetWithIncludeById(int id);
    Task<T> GetByFilterAsync(Expression<Func<T, bool>> predicate);
    Task<T> UpdateAsync(T t);
    Task<bool> DeleteAsync(int id);
}
