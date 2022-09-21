using _2035Cars_Core.Domain;

namespace _2035Cars_Infrastructure.Interfaces;

public interface IRepositoryBase<T> where T : BaseEntity
{
    Task<Guid> CreateAsync(T entity);
    Task<T> ReadByIDAsync(Guid id);
    Task<Guid> UpdateAsync(T entity);
    Task<Guid> DeleteAsync(T entity);
}