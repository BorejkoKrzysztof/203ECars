using _2035Cars_Core.Domain;
using _2035Cars_Infrastructure.Database;
using _2035Cars_Infrastructure.Interfaces;

namespace _2035Cars_Infrastructure.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(CarDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<long> OrderTransactionForExistingUser(Car car, Order order)
        {
            using var transaction = this._dbContext.Database.BeginTransaction();

            // Update Car
            this._dbContext.Entry(this._dbContext.Cars.First(x => x.Id == car.Id))
                                .CurrentValues.SetValues(car);
            await this._dbContext.SaveChangesAsync(); 
            
            // Create Order
            await this._dbContext.Orders.AddAsync(order);
            await this._dbContext.SaveChangesAsync();

            await transaction.CommitAsync();

            return order.Id;
        }
    }
}