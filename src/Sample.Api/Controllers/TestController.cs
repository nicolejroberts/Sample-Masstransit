namespace Sample.Api.Controllers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Components.StateMachines;
    using MassTransit;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;


    [ApiController]
    [Route("[controller]")]
    public class TestController :
        ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public TestController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task Get(CancellationToken cancellationToken)
        {
            await _publishEndpoint.Publish<StartProcessRequest>(new() { CorrelationId = Guid.NewGuid() });
        }
    }
}