namespace _2035Cars_Application.Commands
{
    public class MakeOrderCommand
    {
        public long CarId { get; set; }
        public string FromRentalCity { get; set; }
        public string FromRentalLocation { get; set; }
        public string ToRentalCity { get; set; }
        public string ToRentalLocation { get; set; }
        public DateTime RentFromDate { get; set; }
        public DateTime RentToDate { get; set; }
        public decimal OrderPrice { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhoneNumber { get; set; }
    }
}