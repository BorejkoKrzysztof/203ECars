using System.Net;
using _2035Cars_application.ViewModels;
using _2035Cars_Application.Commands;
using _2035Cars_Application.DTO;
using _2035Cars_Application.Interfaces;
using _2035Cars_Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTasks.Api.Controllers;

namespace _2035Cars_API.Controllers
{
    [ApiController]
    public class CarController : ApiControllerBase
    {
        private ICarService _service;

        const int pageSize = 4;
        const int adminPageSize = 8;

        public CarController(ICarService service)
        {
            this._service = service;
        }

        [HttpPost("cars/{pageNumber}/{city}/{location}")]
        [ProducesResponseType(typeof(CarsCollectionWithPagination), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCarsByCityAndLocation
                                            ([FromRoute] int pageNumber,
                                            [FromRoute] string city,
                                            [FromRoute] string location,
                                            [FromBody] PreferableCarFeaturesSearchWithLocationCommand carFeatures)
        {
            var model =
                await this._service
                    .GetCollectionOfCarsByRentalCityAndLocation
                                (city, location, carFeatures, pageNumber, pageSize);

            if (model is null)
                return ValidationProblem();


            return Ok(model);
        }

        [HttpGet("cars/getallcars/{pageNumber}")]
        [ProducesResponseType(typeof(CarsCollectionWithPagination), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllCars([FromRoute] int pageNumber)
        {
            var model = await this._service.GetAllCarsAsync(pageNumber, pageSize);

            if (model is null)
                return ValidationProblem();


            return Ok(model);
        }

        [HttpPost("cars/getcarsbytype/{pageNumber}")]
        [ProducesResponseType(typeof(CarsCollectionWithPagination), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCarsByType([FromRoute] int pageNumber, [FromBody] CarsByTypeCommand command)
        {
            var model = await this._service.GetCarsByTypeAsync(pageNumber, pageSize, command);

            if (model is null)
                return ValidationProblem();


            return Ok(model);
        }

        [HttpPost("cars/getcarsbycarequipment/{pageNumber}")]
        [ProducesResponseType(typeof(CarsCollectionWithPagination), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCollectionOfCarsByEquipment
                                                            ([FromRoute] int pageNumber,
                                                             [FromBody] GetCarsByEquipmentCommand command)
        {
            var model = await this._service.GetCarsByLocationAndEquipmentAsync
                                                                        (pageNumber,
                                                                        pageSize,
                                                                        command);

            if (model is null)
                return ValidationProblem();


            return Ok(model);
        }

        [HttpGet("cars/getcarimage/{carId}")]
        [ProducesResponseType(typeof(CarsCollectionWithPagination), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCarImage([FromRoute] long carId)
        {
            byte[] image = await this._service.GetImageForCarById(carId);

            if (image is null || image.Length == 0)
                return ValidationProblem();

            return Ok(image);
        }

        [Authorize]
        [HttpGet("carsforrental/{rentalId}/{currentPage}")]
        [ProducesResponseType(typeof(CarsCollectionWithPaginationBasic), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCarsForRental([FromRoute] long rentalId,
                                                            [FromRoute] int currentPage)
        {
            CarsCollectionWithPaginationBasic model = await this._service
                                                    .GetCarsForRental(rentalId, currentPage, adminPageSize);

            if (model is null)
                return BadRequest();

            return Ok(model);
        }

        [Authorize]
        [HttpGet("getcarinfo/{carId}")]
        [ProducesResponseType(typeof(CarDetailsDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCarInfo([FromRoute] long carId)
        {
            var car = await this._service.ReadCarByIdAsync(carId);

            if (car is null)
                return BadRequest();

            return Ok(car);
        }

        [Authorize]
        [HttpDelete("removecar/{carId}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoveCar([FromRoute] long carId)
        {
            bool result = await this._service.RemoveCarAsync(carId);

            if (!result)
                return BadRequest();

            return NoContent();
        }

        [Authorize]
        [HttpPost("addcartorental")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddCar([FromForm] CreateCarCommand command)
        {
            bool result = await this._service.AddCarToRental(command);

            if (!result)
                return BadRequest();

            return Created(string.Empty, null!);
        }

        [Authorize]
        [HttpPut("editcar")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditCar([FromForm] EditCarCommand command)
        {
            bool result = await this._service.EditCarAsync(command);

            if (!result)
                return BadRequest();

            return NoContent();
        }
    }
}