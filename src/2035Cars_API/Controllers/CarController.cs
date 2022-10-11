using System.Net;
using _2035Cars_application.ViewModels;
using _2035Cars_Application.Commands;
using _2035Cars_Application.DTO;
using _2035Cars_Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MyTasks.Api.Controllers;

namespace _2035Cars_API.Controllers
{
    [ApiController]
    public class CarController : ApiControllerBase
    {
        private ICarService _service;

        const int pageSize = 4;

        public CarController(ICarService service)
        {
            this._service = service;
        }

        [HttpGet("cars/{pageNumber}/{city}/{location}")]
        [ProducesResponseType(typeof(CarsCollectionWithPagination), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCarsByCityAndLocation
                                            ([FromRoute]int pageNumber,
                                            [FromRoute]string city, 
                                            [FromRoute]string location, 
                                            [FromBody]PreferableCarFeaturesCommand carFeatures)
        {
            var carsCollection = 
                await this._service
                    .GetCollectionOfCarsByRentalCityAndLocation
                                (city, location, carFeatures, pageNumber, pageSize);

            if (carsCollection is null)
                return ValidationProblem();


            return Ok(carsCollection);
        }

        [HttpGet("cars/{pageNumber}/{rentalId}")]
        [ProducesResponseType(typeof(CarsCollectionWithPagination), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetCarsByCityAndLocation
                                            ([FromRoute]int pageNumber,
                                             [FromRoute]long rentalId,
                                             [FromBody]PreferableCarFeaturesCommand carFeatures)
        {
            var carsCollection = 
                await this._service.GetCollectionOfCarsByRentalId
                                        (rentalId, carFeatures, pageNumber, pageSize);

            if (carsCollection is null)
                return BadRequest();

            return Ok(carsCollection);
        }
    }
}