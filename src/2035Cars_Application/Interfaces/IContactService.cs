using _2035Cars_Application.Commands;

namespace _2035Cars_Application.Interfaces
{
    public interface IContactService
    {
        Task SaveContactMessageAsync(GetContactMessageCommand command);
    }
}