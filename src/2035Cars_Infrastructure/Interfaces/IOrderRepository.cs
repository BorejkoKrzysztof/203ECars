using _2035Cars_Core.Domain;

namespace _2035Cars_Infrastructure.Interfaces
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        Task<long> OrderTransactionForExistingUser(
            Car car,
            Order order
        );
        Task<List<BasicInfoOrder>> GetOrdersBasicInfo(long rentalId);
        Task<long> GetCarIdByOrderId(long orderId);
        Task FinishOrderAsync(long orderId, long carId, long accountId);
    }
}