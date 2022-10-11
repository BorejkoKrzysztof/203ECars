using System.Net;
using _2035Cars_Application.Commands;
using _2035Cars_Application.Interfaces;
using AutoMapper;
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
        public async Task<IActionResult> CreateOrder([FromBody]MakeOrderCommand orderCommand)
        {

            var orderId = await this._service.MakeOrder(orderCommand);

            if (orderId == 0)
                return BadRequest();
                

            return NoContent();
        }
    }
}