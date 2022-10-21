namespace _2035Cars_Core.Domain
{
    public class ContactMessage : BaseEntity
    {
        public string PersonName { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        public Guid ReservationId { get; set; }
        public string Message { get; set; }
    }
}