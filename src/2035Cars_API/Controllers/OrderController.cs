using System.Net;
using _2035Cars_Application.Commands;
using _2035Cars_Application.DTO;
using _2035Cars_Application.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTasks.Api.Controllers;

namespace _2035Cars_API.Controllers
{
    [ApiController]
    public class OrderController : ApiControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            this._service = service;
        }

        [HttpPost("performOrder")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateOrder([FromBody] MakeOrderCommand orderCommand)
        {

            var orderId = await this._service.MakeOrder(orderCommand);

            if (orderId == 0)
                return BadRequest();


            return NoContent();
        }

        [Authorize]
        [HttpGet("getorders/{rentalId}")]
        [ProducesResponseType(typeof(List<OrderDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOrders([FromRoute] long rentalId)
        {
            List<OrderDTO> orders = await this._service.GetOrders(rentalId);

            if (orders is null)
                return BadRequest();

            return Ok(orders);
        }

        [Authorize]
        [HttpGet("finishorder/{orderId}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FinishOrder([FromRoute] long orderId)
        {
            await this._service.FinishOrderAsync(orderId, accountId);

            return NoContent();
        }

    }
}