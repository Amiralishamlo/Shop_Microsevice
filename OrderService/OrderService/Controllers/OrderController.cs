using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Model.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            string UserId = "1";
            var orders = orderService.GetOrdersForUser(UserId);
            return Ok(orders);
        }

        [HttpGet("{OrderId}")]
        public IActionResult Get(Guid OrderId)
        {
            var order = orderService.GetOrderById(OrderId);
            return Ok(order);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddOrderDto order)
        {
            orderService.AddOrder(order);
            return Ok();
        }

    }
}
