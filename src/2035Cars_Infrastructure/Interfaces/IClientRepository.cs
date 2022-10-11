using _2035Cars_Core.Domain;

namespace _2035Cars_Infrastructure.Interfaces
{
    public interface IClientRepository : IRepositoryBase<Client>
    {
        Task<bool> IsClientExistingAsync(string firstName, string lastName, string emailAddress);
        Task<Client> ReadClientByPersonalData(string firstName, string lastName, string emailAddress);
    }
}