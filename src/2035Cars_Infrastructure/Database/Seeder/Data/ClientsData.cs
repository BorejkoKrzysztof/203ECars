using _2035Cars_Core.Domain;
using _2035Cars_Core.ValueObjects;

namespace _2035Cars_Infrastructure.Database.Seeder.Data
{
    public class ClientsData
    {
        public List<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client()
                {
                    EmailAddress = "leone.heathcote@yahoo.com",
                    Person = new Person("Andrzej", "Popczyk", "642983213"),
                    Orders = new List<Order>(),
                    CreatedDate = DateTime.UtcNow,
                    LastUpdateDate = DateTime.UtcNow
                }
            };
        }
    }
}