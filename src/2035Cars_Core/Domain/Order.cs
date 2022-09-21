namespace _2035Cars_Core.Domain
{
    public class Order : BaseEntity
    {
        public Guid PublishEmployeeId { get; private set; }
        public Guid AcceptEmployeeId { get; set; }
        public Guid ClientId { get; private set; }
        public Guid CarId { get; private set; }
        public Guid FromRental { get; private set; }
        public Guid ToRental { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public decimal CostOfRental { get; private set; }
    }
}