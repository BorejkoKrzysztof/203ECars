// using _2035Cars_Core.Domain;
// using _2035Cars_Infrastructure.Database;
// using _2035Cars_Infrastructure.Interfaces;

// namespace _2035Cars_Infrastructure.Repositories;

// public class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity
// {
//     protected readonly CarsDbContext _dbContext;

//     public RepositoryBase(CarsDbContext dbContext)
//     {
//         _dbContext = dbContext;
//     }

//     public async Task<Guid> CreateAsync(T entity)
//     {
//         await this._dbContext.Set<T>().AddAsync(entity);
//         await this._dbContext.SaveChangesAsync();

//         return entity.Id;
//     }

//     public async Task<Guid> DeleteAsync(T entity)
//     {
//         this._dbContext.Set<T>().Remove(entity);
//         await this._dbContext.SaveChangesAsync();

//         return entity.Id;
//     }

//     public async Task<T> ReadByIDAsync(Guid id)
//     {
//         return await this._dbContext.Set<T>().FindAsync(id);
//     }

//     public async Task<Guid> UpdateAsync(T entity)
//     {
//         this._dbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
//         await this._dbContext.SaveChangesAsync();

//         return entity.Id;
//     }
// }