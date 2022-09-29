using _2035Cars_Core.Domain;
using _2035Cars_Core.ValueObjects;
using _2035Cars_Infrastructure.Database;
using _2035Cars_Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Test.InfrastructureTests.BaseRepository
{
    public class BaseRepositoryTests
    {
        private readonly CarDbContext dbContext;
        private readonly RepositoryBase<Client> repositoryBase;
        private List<Client> collectionOfClients;

        public BaseRepositoryTests()
        {
            DbContextOptionsBuilder dbOptions = new DbContextOptionsBuilder()
                                                .UseInMemoryDatabase(Guid.NewGuid().ToString());  

            this.dbContext = new CarDbContext(dbOptions.Options);
            this.repositoryBase = new RepositoryBase<Client>(this.dbContext);
        }

        [SetUp]
        public void Setup()
        {
            this.collectionOfClients = new List<Client>()
            {
                new Client(
                    new Account("nowak@email.com", "secretPassword1"),
                    new Address("glowna", "1a", "Warsaw", "55-555"),
                    new Person("Jan", "Nowak", "123456789")
                ),
                new Client(
                    new Account("kowalski@email.com", "secretPassword2"),
                    new Address("boczna", "2a", "Poznan", "55-525"),
                    new Person("Adam", "Kowalski", "987654321")
                ),
                new Client(
                    new Account("Malysz@email.com", "secretPassword2"),
                    new Address("boczna", "2a", "Poznan", "55-525"),
                    new Person("Adam", "Malysz", "123454321")
                )
            };
        }

        [Test]
        public void CreateAsync_IncorrectData_EntityIsNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            Client client = null!;

            // Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () => {
                var id = await this.repositoryBase.CreateAsync(client);
            });
        }

        [Test]
        public async Task CreateAsync_CorrectData_ShouldAddNewEntityToDatabase()
        {
            // Arrange
            this.dbContext.Clients.AddRange(this.collectionOfClients.Take(2));
            await this.dbContext.SaveChangesAsync();

            Client client = this.collectionOfClients[2];

            // Act
            var id = await this.repositoryBase.CreateAsync(client);

            // Assert
            Assert.That(id, Is.Not.EqualTo(0));
            int amountOfClientsInDB = await this.dbContext.Clients.CountAsync();
            Assert.That(amountOfClientsInDB, Is.EqualTo(3));
        }

        [Test]
        public void DeleteAsync_IncorrectData_EntityIsNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            Client client = null!;

            // Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () => {
                var id = await this.repositoryBase.DeleteAsync(client);
            });
        }

        [Test]
        public async Task DeleteAsync_CorrectData_ShouldRemoveEntityFromDatabase()
        {
            // Arrange
            await this.dbContext.Clients.AddRangeAsync(this.collectionOfClients);
            await this.dbContext.SaveChangesAsync();
            
            Client client = await this.dbContext.Clients
                                .FirstAsync(x => x.Account.EmailAddress == collectionOfClients[1].Account.EmailAddress);

            // Act
            var id = await this.repositoryBase.DeleteAsync(client);

            // Assert
            Assert.That(id, Is.Not.EqualTo(0));
            int amountOfClientsInDB = await this.dbContext.Clients.CountAsync();
            Assert.That(amountOfClientsInDB, Is.EqualTo(2));
        }

        [Test]
        public async Task ReadByIdAsync_IncorrectData_IdIsZero_ShouldReturnNull()
        {
            // Arrange
            await this.dbContext.Clients.AddAsync(this.collectionOfClients[0]);
            await this.dbContext.SaveChangesAsync();

            // Act
            Client client = await this.repositoryBase.ReadByIDAsync(0);

            // Assert
            Assert.IsNull(client);
        }

        [Test]
        public async Task ReadByIdAsync_CorrectData_ShouldReturnEntityFromDatabase()
        {
            // Arrange
            await this.dbContext.Clients.AddAsync(this.collectionOfClients[0]);
            await this.dbContext.SaveChangesAsync();

            // Act
            Client client = await this.repositoryBase.ReadByIDAsync(1);

            // Assert
            Assert.IsNotNull(client);
            Assert.That(client.Account.EmailAddress, Is.EqualTo(this.collectionOfClients[0].Account.EmailAddress));
        }

        [Test]
        public async Task ReadAllAsync_CorrectData_ShouldReturnCollectionOfEntitiesFromDatabase()
        {
            // Arrange
            await this.dbContext.Clients.AddRangeAsync(this.collectionOfClients);
            await this.dbContext.SaveChangesAsync();

            // Act
            var collectionFromDB = await this.repositoryBase.ReadAllAsync();

            // Assert
            Assert.That(collectionFromDB.Count, Is.EqualTo(3));
        }

        [Test]
        public async Task ReadAllAsync_CorrectData_DBIsEmpty_ShouldReturnEmptyCollectionOfEntitiesFromDatabase()
        {
            // Act
            var collectionFromDB = await this.repositoryBase.ReadAllAsync();

            // Assert
            Assert.NotNull(collectionFromDB);
            Assert.That(collectionFromDB.Count, Is.EqualTo(0));
        }

        [Test]
        public void UpdateAsync_IncorrectData_EntityIsNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            Client clientToUpdate = null!;

            // Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () => {
                var id = await this.repositoryBase.DeleteAsync(clientToUpdate);
            });
        }

        [Test]
        public async Task UpdateAsync_CorrectData_ShouldUpdateEntityInDatabase()
        {
            // Arrange
            await this.dbContext.Clients.AddAsync(this.collectionOfClients[0]);
            await this.dbContext.SaveChangesAsync();

            string newEmail = "newemail@email.com";

            Client clientToUpdate = await this.dbContext.Clients.FirstAsync();
            clientToUpdate.Account.UpdateEmailAddress(newEmail);

            // Act
            var id = await this.repositoryBase.UpdateAsync(clientToUpdate);
            Client clientAfterUpdate = await this.dbContext.Clients.FirstAsync();
            // Assert
            Assert.That(clientAfterUpdate.Account.EmailAddress, Is.EqualTo(newEmail));
            Assert.That(clientToUpdate.Account.Password, Is.EqualTo(clientAfterUpdate.Account.Password));
        }

        [TearDown]
        public void CleanContext()
        {
            this.dbContext.ChangeTracker.Clear();
            this.dbContext.Database.EnsureDeleted();
        }
    }
}