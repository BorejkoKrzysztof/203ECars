using _2035Cars_Core.Domain;
using _2035Cars_Infrastructure.Database;
using _2035Cars_Infrastructure.Interfaces;

namespace _2035Cars_Infrastructure.Repositories
{
    public class ContactRepository : RepositoryBase<ContactMessage>, IContactRepository
    {
                public ContactRepository(CarDbContext dbContext) : base(dbContext)
        {
        }
    }
}