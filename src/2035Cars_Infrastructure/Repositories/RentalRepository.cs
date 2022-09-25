using _2035Cars_Core.Domain;
using _2035Cars_Infrastructure.Database;
using _2035Cars_Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace _2035Cars_Infrastructure.Repositories
{
    public class RentalRepository : RepositoryBase<Rental>, IRentalRepository
    {
        public RentalRepository(CarDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Rental>> ReadAll()
        {
            return await this._dbContext.Rentals.ToListAsync();
        }

        public async Task<List<string>> ReadAllRentalCities()
        {
            return await this._dbContext.Rentals.Select(x => x.Address.City).ToListAsync();
        }
    }
}