namespace Sample.Components.Consumers;

using System;
using System.Threading.Tasks;
using MassTransit;

public class State2Request
{
    public Guid CorrelationId { get; init; }
}

public class State2Response
{
    public Guid CorrelationId { get; init; }
}

public class State2Consumer : IConsumer<State2Request>
{
    public async Task Consume(
        ConsumeContext<State2Request> context
    )
    {
        await Task.Delay(1000);
        await context.Publish(new State2Response {CorrelationId = context.Message.CorrelationId});
    }
}

// public class State2ConsumerDefinition :
//     ConsumerDefinition<State2Consumer>
// {
//     protected override void ConfigureConsumer(
//         IReceiveEndpointConfigurator endpointConfigurator,
//         IConsumerConfigurator<State2Consumer> consumerConfigurator
//     )
//     {
//         // Add retry policy
//         endpointConfigurator.UseMessageRetry(
//             r => { r.Exponential(300, TimeSpan.FromSeconds(1), TimeSpan.FromMinutes(30), TimeSpan.FromSeconds(1)); }
//         );
//     }
// }