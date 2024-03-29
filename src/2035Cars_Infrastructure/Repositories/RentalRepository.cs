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

        public async Task<object> GetRentalByCityAndLocationAsync(string city, string location)
        {
            var info = this._dbContext.Rentals
                                .Where(x => x.Address.City == city && 
                                                    x.Title == location)
                                .Select(s => new {
                                    Id = s.Id,
                                    Title = s.Title,
                                    ShortTitle = s.ShortTitle
                                });

            return await Task.FromResult(info);
        }

        public async Task<List<string>> GetRentalCitiesWithTitlesAsync()
        {
            var citiesWithTitles = 
                    this._dbContext.Rentals.Select(x => $"{x.Address.City}, {x.Title}")
                                            .ToList();

            return await Task.FromResult(citiesWithTitles);
        }

        public async Task<List<string>> ReadAllLocationsByCityAsync(string rentalCity)
        {
            return await this._dbContext.Rentals
                                .Where(x => string.Equals(x.Address.City, rentalCity))
                                .Select(x => x.Title)
                                .ToListAsync();
        }

        public async Task<List<string>> ReadAllRentalCitiesAsync()
        {
            return await this._dbContext.Rentals
                                    .Select(x => x.Address.City)
                                    .Distinct()
                                    .ToListAsync();
        }

        public async Task<long> ReturnRentalIdAsync(string city, string location)
        {
            long id = this._dbContext.Rentals.First(x => x.Address.City == city &&
                                                    x.Title == location).Id;

            return await Task.FromResult(id);
        }
    }
}