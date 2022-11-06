using _2035Cars_Core.Domain;
using _2035Cars_Infrastructure.Database;
using _2035Cars_Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace _2035Cars_Infrastructure.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(CarDbContext dbContext) : base(dbContext)
        {
        }

        public async Task FinishOrderAsync(long orderId, long carId, long accountId)
        {
            using var transaction = await this._dbContext.Database.BeginTransactionAsync();

            // Update Car
            this._dbContext.Cars.First(x => x.Id == carId).IsRented = false;
            await this._dbContext.SaveChangesAsync();

            // Add AcceptedEmployee to Order
            this._dbContext.Orders.First(x => x.Id == orderId).AcceptEmployeeId = accountId;
            await this._dbContext.SaveChangesAsync();

            // Set Order Finished
            this._dbContext.Orders.First(x => x.Id == orderId).Finished = true;
            await this._dbContext.SaveChangesAsync();

            await transaction.CommitAsync();
        }

        public async Task<long> GetCarIdByOrderId(long orderId)
        {
            long carId = this._dbContext.Orders.First(x => x.Id == orderId).CarId;

            return await Task.FromResult(carId);
        }

        public async Task<List<BasicInfoOrder>> GetOrdersBasicInfo(long rentalId)
        {
            var orders = this._dbContext.Orders
                        .Where(x => x.ToRentalId == rentalId &&
                                !x.Finished && x.AcceptEmployeeId == null)
                        .Select(x => new BasicInfoOrder()
                        {
                            Id = x.Id,
                            Price = x.CostOfRental,
                            CustomerFirstName = x.Client.Person.FirstName,
                            CustomerLastName = x.Client.Person.LastName
                        }).ToList();

            return await Task.FromResult(orders);
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