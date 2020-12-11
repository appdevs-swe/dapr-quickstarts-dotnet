using Dapr;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace subscriber.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        public MessagesController(ILogger<MessagesController> logger)
        {
            Logger = logger;
        }

        public ILogger<MessagesController> Logger { get; }

        [Topic(DaprSettings.PubSubName, DaprSettings.Topic)]
        public async Task<ActionResult> Sub([FromBody] string messageId)
        {
            Logger.LogInformation($"Message Id:{messageId} received");
            return Ok(messageId);
        }
    }
}
