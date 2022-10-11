using _2035Cars_Core.Domain;
using _2035Cars_Infrastructure.Database;
using _2035Cars_Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace _2035Cars_Infrastructure.Repositories
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(CarDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> IsClientExistingAsync(string firstName, 
                                                        string lastName, 
                                                        string emailAddress)
        {
            return await this._dbContext.Clients
                                    .AnyAsync(x => x.Person.FirstName == firstName &&
                                                x.Person.LastName == lastName &&
                                                x.EmailAddress == emailAddress);
        }

        public async Task<Client> ReadClientByPersonalData(string firstName, string lastName, string emailAddress)
        {
           return await this._dbContext.Clients.FirstOrDefaultAsync(x => x.Person.FirstName == firstName &&
                                                x.Person.LastName == lastName &&
                                                x.EmailAddress == emailAddress);
        }
    }
}