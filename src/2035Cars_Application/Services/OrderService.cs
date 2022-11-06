using _2035Cars_Application.Commands;
using _2035Cars_Application.DTO;
using _2035Cars_Application.Interfaces;
using _2035Cars_Core.Domain;
using _2035Cars_Core.ValueObjects;
using _2035Cars_Infrastructure.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace _2035Cars_Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IClientRepository _clientRepository;
        private readonly ICarRepository _carRepository;
        private readonly IRentalRepository _rentalRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<OrderService> _logger;

        public OrderService(IOrderRepository repository,
                                IClientRepository clientRepository,
                                ICarRepository carRepository,
                                IRentalRepository rentalRepository,
                                IMapper mapper,
                                ILogger<OrderService> logger)
        {
            this._repository = repository;
            this._clientRepository = clientRepository;
            this._carRepository = carRepository;
            this._rentalRepository = rentalRepository;
            this._mapper = mapper;
            this._logger = logger;
        }

        public async Task FinishOrderAsync(long orderId, long accountId)
        {
            try
            {
                long orderCarID = await this._repository.GetCarIdByOrderId(orderId);
                this._logger.LogInformation($"Car Id from Order id downloaded.");
                await this._repository.FinishOrderAsync(orderId, orderCarID, accountId);
                this._logger.LogInformation($"Order with id: {orderId} is finished by employee with id: {accountId}.");
            }
            catch (System.Exception ex)
            {
                this._logger.LogError($"Something went wrong with finishing order with Id: {orderId} by employee with Id: {accountId}, error => {ex.Message}");
            }
        }

        public async Task<List<OrderDTO>> GetOrders(long rentalId)
        {
            List<OrderDTO> orders;
            try
            {
                var objectOrders = await this._repository.GetOrdersBasicInfo(rentalId);
                orders = new List<OrderDTO>();
                foreach (var item in objectOrders)
                {
                    orders.Add(new OrderDTO()
                    {
                        Id = item.Id,
                        Price = item.Price,
                        CustomerFirstName = item.CustomerFirstName,
                        CustomerLastName = item.CustomerLastName
                    });
                }
                this._logger.LogInformation($"Order collection for rental with id: {rentalId} is downloaded");
            }
            catch (System.Exception ex)
            {
                this._logger.LogError($"Error occurred while downloading orders for rental with id: {rentalId}, error => {ex.Message}");
                return null!;
            }

            return orders;
        }

        public async Task<long> MakeOrder(MakeOrderCommand orderCommand)
        {
            long createdOrderId;

            try
            {
                var client = await this._clientRepository
                                            .ReadClientByPersonalData
                                            (
                                                orderCommand.CustomerFirstName,
                                                orderCommand.CustomerLastName,
                                                orderCommand.CustomerEmail
                                            );

                if (client is null)
                {
                    var newClient = new Client()
                    {
                        EmailAddress = orderCommand.CustomerEmail,
                        Person = new Person(orderCommand.CustomerFirstName,
                                               orderCommand.CustomerLastName,
                                               orderCommand.CustomerPhoneNumber),
                        Orders = new List<Order>()
                    };
                    long newCreatedClientId = await this._clientRepository.CreateAsync(newClient);
                    client = await this._clientRepository.ReadByIDAsync(newCreatedClientId);
                }

                var carToOrder = await this._carRepository.ReadByIDAsync(orderCommand.CarId);

                var newOrder = new Order()
                {
                    Client = client,
                    Car = carToOrder,
                    FromRentalId = await this._rentalRepository
                                    .ReturnRentalIdAsync(orderCommand.FromRentalCity,
                                                                        orderCommand.FromRentalLocation),
                    ToRentalId = await this._rentalRepository
                                    .ReturnRentalIdAsync(orderCommand.ToRentalCity,
                                                                        orderCommand.ToRentalLocation),
                    StartDate = orderCommand.RentFromDate.ToUniversalTime(),
                    EndDate = orderCommand.RentToDate.ToUniversalTime(),
                    CostOfRental = orderCommand.OrderPrice,
                    Finished = false
                };

                carToOrder.IsRented = true;

                createdOrderId = await this._repository
                                        .OrderTransactionForExistingUser(carToOrder, newOrder);

            }
            catch (Exception ex)
            {
                this._logger.LogError($"Issue with Creating Order => {ex.Message}");
                return 0;
            }


            return createdOrderId;
        }
    }
}