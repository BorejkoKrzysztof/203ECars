using _2035Cars_Application.Commands;
using _2035Cars_Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MyTasks.Api.Controllers;

namespace _2035Cars_API.Controllers
{
    [ApiController]
    public class ContactController : ApiControllerBase
    {
        private readonly IContactService _service;

        public ContactController(IContactService service)
        {
            this._service = service;
        }

        [HttpPost("/kontakt")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetContactMessage(GetContactMessageCommand command)
        {
            await this._service.SaveContactMessageAsync(command);

            return NoContent();
        }
    }
}