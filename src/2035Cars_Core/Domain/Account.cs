
namespace _2035Cars_Core.Domain;

public class Account : BaseIdentity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}