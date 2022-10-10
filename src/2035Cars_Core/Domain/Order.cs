using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2035Cars_Core.Domain
{
    public class Order : BaseEntity
    {
        [Required]
        public long PublishEmployeeId { get; set; }

        // [Required]
        // [ForeignKey("PublishEmployeeId")]
        // public virtual Employee PublishEmployee { get; set; }

        public long? AcceptEmployeeId { get; set; }

        // [ForeignKey("AcceptEmployeeId")]
        // public virtual Employee? AcceptEmployee { get; set; }

        [Required]
        public long ClientId { get; set; }

        // [Required]
        // [ForeignKey("ClientId")]
        // public virtual Client Client { get; set; }

        [Required]
        public long CarId { get; set; }

        // [Required]
        // [ForeignKey("CarId")]
        // public virtual Car Car { get; set; }

        [Required]
        public long FromRentalId { get; set; }

        // [Required]
        // [ForeignKey("FormRentalId")]
        // public virtual Rental FormRental { get; set; }

        [Required]
        public long ToRentalId { get; set; }

        // [Required]
        // [ForeignKey("ToRentalId")]
        // public virtual Rental ToRental { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal CostOfRental { get; set; }

        [Required]
        public bool Finished { get; set; }

        public Order()
        {

        }

        // public Order(long publishEmployeeId, long clientId, long carId, long fromRental, long toRental, DateTime startDate, DateTime endDate, decimal costOfRental)
        // {
        //     PublishEmployeeId = publishEmployeeId;
        //     ClientId = clientId;
        //     CarId = carId;
        //     FromRentalId = fromRental;
        //     ToRentalId = toRental;
        //     StartDate = startDate;
        //     EndDate = endDate;
        //     CostOfRental = costOfRental;
        //     Finished = false;
        //     // CreatedDate = DateTime.UtcNow;
        //     // LastUpdateDate = DateTime.UtcNow;
        // }
    }
}