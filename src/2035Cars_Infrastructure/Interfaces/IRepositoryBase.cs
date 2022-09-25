using _2035Cars_Core.Domain;

namespace _2035Cars_Infrastructure.Interfaces;

public interface IRepositoryBase<T> where T : BaseEntity
{
    Task<long> CreateAsync(T entity);
    Task<T> ReadByIDAsync(Guid id);
    Task<long> UpdateAsync(T entity);
    Task<long> DeleteAsync(T entity);
}