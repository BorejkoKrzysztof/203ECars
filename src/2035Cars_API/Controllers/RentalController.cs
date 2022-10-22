using System.Net;
using _2035Cars_Application.DTO;
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRentalCities()
        {
            var rentalCities = await this._service.GetRentalCitiesAsync();

            if (rentalCities is null)
                return NotFound();

            return Ok(rentalCities);
        }

        [HttpGet("locations/{city}")]
        [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRentalLocations(string city)
        {
            var rentalLocations = await this._service.GetRentalLocationsAsync(city);

            if (rentalLocations is null)
                return NotFound();

            return Ok(rentalLocations);
        }


        [HttpGet("{city}/{location}")]
        [ProducesResponseType(typeof(RentalBasicInfo), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRentalBasicInfo([FromRoute]string city, [FromRoute]string location)
        {
            var rentalInfo = await this._service.GetRentalInfo(city, location);

            if (rentalInfo is null)
                    return NotFound();

            return Ok(rentalInfo);
        }

        [HttpGet("allcitieswithlocations")]
        [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRentalCitiesWithTitles()
        {
            List<string> rentalCitiesWithTitles = 
                                await this._service.GetRentalCitiesWithTitles();

            if (rentalCitiesWithTitles.Count == 0)
                            return NotFound();

            return Ok(rentalCitiesWithTitles);
        }


        // FAKE FAKE        ====> do usuniecie pozniej
        [HttpGet("fakecities")]
        public IActionResult GetFakeCities()
        {
            var cities = new List<string>();
            cities.Add("Warszawa");
            cities.Add("Wroclaw");
            cities.Add("Poznań");

            return Ok(cities);
        }
    }
}