using System.Net;
using _2035Cars_Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MyTasks.Api.Controllers;

namespace _2035Cars_API.Controllers
{
    [ApiController]
    public class RentalController : ApiControllerBase
    {
        private readonly IRentalService _service;

        public RentalController(IRentalService service)
        {
            this._service = service;
        }

        [HttpGet("cities")]
        [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetRentalCities()
        {
            var rentalCities = await this._service.GetRentalCities();


            return Ok(rentalCities);
        }

        [HttpGet("locations/{city}")]
        [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetRentalLocations(string city)
        {
            var rentalLocations = await this._service.GetRentalLocations(city);


            return Ok(rentalLocations);
        }
    }
}