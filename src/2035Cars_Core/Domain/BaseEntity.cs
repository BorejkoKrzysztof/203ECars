
using System.ComponentModel.DataAnnotations;

namespace _2035Cars_Core.Domain;

public class BaseIdentity
{
    [Required]
    public Guid Id { get; set; }
}