using System.ComponentModel.DataAnnotations;

namespace _2035Cars_Core.Domain
{
    public class BaseEntity
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime LastUpdateDate { get; set; }
    }
}