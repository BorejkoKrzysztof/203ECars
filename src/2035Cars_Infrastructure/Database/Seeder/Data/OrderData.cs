using _2035Cars_Core.Domain;

namespace _2035Cars_Infrastructure.Database.Seeder.Data
{
    public class OrderData
    {
        private readonly List<Rental> _rentalCollection;
        private readonly List<Client> _clientsCollection;

        public OrderData(List<Rental> rentalsCollection, List<Client> clientsCollection)
        {
            this._rentalCollection = rentalsCollection;
            this._clientsCollection = clientsCollection;
        }

        public List<Order> GetOrders()
        {
            var orders = new List<Order>();

            orders.Add(new Order()
            {
                AcceptEmployee = this._rentalCollection[7].Employees[2],
                Client = this._clientsCollection[2],
                Car = this._rentalCollection[4].Cars[2],
                FromRentalId = this._rentalCollection[4].Id,
                ToRentalId = this._rentalCollection[7].Id,
                StartDate = new DateTime(2022, 2, 12, 13, 30, 0),
                EndDate = new DateTime(2022, 2, 14, 10, 0, 0),
                CostOfRental = 1200.00M,
                Finished = true,
                UniqueOrderNumber = Guid.NewGuid(),
                CreatedDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow
            });

            orders.Add(new Order()
            {
                AcceptEmployee = this._rentalCollection[8].Employees[3],
                Client = this._clientsCollection[1],
                Car = this._rentalCollection[4].Cars[1],
                FromRentalId = this._rentalCollection[4].Id,
                ToRentalId = this._rentalCollection[8].Id,
                StartDate = new DateTime(2022, 4, 20, 13, 30, 0),
                EndDate = new DateTime(2022, 4, 25, 10, 0, 0),
                CostOfRental = 2800.00M,
                Finished = true,
                UniqueOrderNumber = Guid.NewGuid(),
                CreatedDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow
            });

            orders.Add(new Order()
            {
                AcceptEmployee = this._rentalCollection[0].Employees[3],
                Client = this._clientsCollection[1],
                Car = this._rentalCollection[1].Cars[1],
                FromRentalId = this._rentalCollection[1].Id,
                ToRentalId = this._rentalCollection[0].Id,
                StartDate = new DateTime(2022, 4, 20, 13, 30, 0),
                EndDate = new DateTime(2022, 4, 25, 10, 0, 0),
                CostOfRental = 3000.00M,
                Finished = true,
                UniqueOrderNumber = Guid.NewGuid(),
                CreatedDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow
            });

            orders.Add(new Order()
            {
                AcceptEmployee = this._rentalCollection[4].Employees[3],
                Client = this._clientsCollection[1],
                Car = this._rentalCollection[1].Cars[1],
                FromRentalId = this._rentalCollection[1].Id,
                ToRentalId = this._rentalCollection[4].Id,
                StartDate = new DateTime(2022, 1, 20, 13, 30, 0),
                EndDate = new DateTime(2022, 1, 25, 10, 0, 0),
                CostOfRental = 3000.00M,
                Finished = true,
                UniqueOrderNumber = Guid.NewGuid(),
                CreatedDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow
            });

            return orders;
        }
    }
}