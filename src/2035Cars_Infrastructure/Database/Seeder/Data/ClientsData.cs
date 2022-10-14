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
                    EmailAddress = "andrzejpopczyk@gmail.com",
                    Person = new Person("Andrzej", "Popczyk", "642983213"),
                    Orders = new List<Order>(),
                    CreatedDate = DateTime.UtcNow,
                    LastUpdateDate = DateTime.UtcNow
                },
                new Client()
                {
                    EmailAddress = "robertmatejko@gmail.com",
                    Person = new Person("Robert", "Matejko", "364923764"),
                    Orders = new List<Order>(),
                    CreatedDate = DateTime.UtcNow,
                    LastUpdateDate = DateTime.UtcNow
                },
                new Client()
                {
                    EmailAddress = "paulinapuchala@gmail.com",
                    Person = new Person("Paulina", "Puchała", "837483293"),
                    Orders = new List<Order>(),
                    CreatedDate = DateTime.UtcNow,
                    LastUpdateDate = DateTime.UtcNow
                },
                new Client()
                {
                    EmailAddress = "marekpazdzior@gmail.com",
                    Person = new Person("Marek", "Paździor", "837477284"),
                    Orders = new List<Order>(),
                    CreatedDate = DateTime.UtcNow,
                    LastUpdateDate = DateTime.UtcNow
                },
                new Client()
                {
                    EmailAddress = "borysosowski@gmail.com",
                    Person = new Person("Borys", "Osowski", "273837263"),
                    Orders = new List<Order>(),
                    CreatedDate = DateTime.UtcNow,
                    LastUpdateDate = DateTime.UtcNow
                },
            };
        }
    }
}