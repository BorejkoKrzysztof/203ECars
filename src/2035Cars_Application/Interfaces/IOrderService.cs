using _2035Cars_Application.Commands;
using _2035Cars_Application.DTO;

namespace _2035Cars_Application.Interfaces
{
    public interface IOrderService
    {
        Task<long> MakeOrder(MakeOrderCommand orderCommand);
        Task<List<OrderDTO>> GetOrders(long rentalId);
        Task FinishOrderAsync(long orderId, long accountId);
    }
}