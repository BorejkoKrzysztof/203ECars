using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2035Cars_Core.Domain
{
    public class Order : BaseEntity
    {
        public long? AcceptEmployeeId { get; set; }

        public virtual Employee? AcceptEmployee { get; set; }

        [Required]
        public long ClientId { get; set; }

        [Required]
        public virtual Client Client { get; set; }

        [Required]
        public long CarId { get; set; }

        public virtual Car Car { get; set; }

        [Required]
        public long FromRentalId { get; set; }

        [Required]
        public long ToRentalId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal CostOfRental { get; set; }

        [Required]
        public bool Finished { get; set; }

        [Required]
        public Guid UniqueOrderNumber { get; set; }

        public Order()
        {

        }
    }
}