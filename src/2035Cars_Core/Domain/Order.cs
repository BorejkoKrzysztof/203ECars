using System.ComponentModel.DataAnnotations;

namespace _2035Cars_Core.Domain
{
    public class Order : BaseEntity
    {
        [Required]
        public long PublishEmployeeId { get; private set; }

        public long? AcceptEmployeeId { get; private set; }

        [Required]
        public long ClientId { get; private set; }

        [Required]
        public long CarId { get; private set; }

        [Required]
        public long FromRentalId { get; private set; }

        [Required]
        public long ToRentalId { get; private set; }

        [Required]
        public DateTime StartDate { get; private set; }

        [Required]
        public DateTime EndDate { get; private set; }

        [Required]
        public decimal CostOfRental { get; private set; }

        [Required]
        public bool Finished { get; private set; }


        public Order(long publishEmployeeId, long clientId, long carId, long fromRental, long toRental, DateTime startDate, DateTime endDate, decimal costOfRental)
        {
            PublishEmployeeId = publishEmployeeId;
            ClientId = clientId;
            CarId = carId;
            FromRentalId = fromRental;
            ToRentalId = toRental;
            StartDate = startDate;
            EndDate = endDate;
            CostOfRental = costOfRental;
            Finished = false;
            // CreatedDate = DateTime.UtcNow;
            // LastUpdateDate = DateTime.UtcNow;
        }

        public void FinishOrder(long employeeId)
        {
            if (employeeId is 0)
                throw new ArgumentOutOfRangeException(nameof(employeeId));

            AcceptEmployeeId = employeeId;
            Finished = true;
            // LastUpdateDate = DateTime.UtcNow;
        }
    }
}