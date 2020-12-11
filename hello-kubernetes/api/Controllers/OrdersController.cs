using Dapr.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers
{
    [ApiController]
    public class OrdersController : ControllerBase
    {
        public DaprClient DaprClient { get; }
        public OrdersController(DaprClient daprClient)
        {
            DaprClient = daprClient;
        }
        [HttpGet]
        [Route("order")]
        public async Task<Order> Order() => await DaprClient.GetStateAsync<Order>(DaprSettings.StateStoreName, DaprSettings.Key);

        [HttpPost]
        [Route("neworder")]
        public async Task NewOrder(string orderId) => await DaprClient.SaveStateAsync(DaprSettings.StateStoreName, DaprSettings.Key, new Order(orderId));
    }

    public record Order(string OrderId);
}
