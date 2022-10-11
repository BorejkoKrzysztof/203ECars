using _2035Cars_Application.Commands;
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

        public async Task<long> MakeOrder(MakeOrderCommand orderCommand)
        {
            long createdOrderId;
            
            try
            {
                var client =  await this._clientRepository
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
                carToOrder.RentedTo = orderCommand.RentToDate.ToUniversalTime();

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