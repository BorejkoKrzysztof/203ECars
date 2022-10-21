using _2035Cars_Application.Commands;
using _2035Cars_Application.Interfaces;
using _2035Cars_Core.Domain;
using _2035Cars_Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;

namespace _2035Cars_Application.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repository;
        private readonly ILogger<ContactService> _logger;

        public ContactService(IContactRepository repository, ILogger<ContactService> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }

        public async Task SaveContactMessageAsync(GetContactMessageCommand command)
        {
            var contactMessage = new ContactMessage()
            {
                PersonName = command.PersonName,
                EmailAddress = command.EmailAddress,
                Phone = command.Phone,
                ReservationId = Guid.Parse(command.ReservationId),
                Message = command.Message
            };

            try
            {
                var id = await this._repository.CreateAsync(contactMessage);
                this._logger.LogInformation("Contact Message Created");
            }
            catch (System.Exception)
            {
                this._logger.LogInformation("Unable to save Contact Message");
            }
        }
    }
}