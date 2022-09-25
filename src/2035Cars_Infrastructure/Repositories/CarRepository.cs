using _2035Cars_Core.Domain;
using _2035Cars_Infrastructure.Database;
using _2035Cars_Infrastructure.Interfaces;

namespace _2035Cars_Infrastructure.Repositories
{
    public class CarRepository : RepositoryBase<Car>, ICarRepository
    {
        public CarRepository(CarDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Car>> GetAllNotRentedCarsByCityAsync()
        {
            throw new NotImplementedException();
        }
    }
}