namespace Sample.Components.Consumers;

using System;
using System.Threading.Tasks;
using MassTransit;

public class State1Request
{
    public Guid CorrelationId { get; init; }
}

public class State1Response
{
    public Guid CorrelationId { get; init; }
}

public class State1Consumer : IConsumer<State1Request>
{
    public async Task Consume(
        ConsumeContext<State1Request> context
    )
    {
        await Task.Delay(1000);
        await context.Publish(new State1Response {CorrelationId = context.Message.CorrelationId});
    }
}

// public class State1ConsumerDefinition :
//     ConsumerDefinition<State1Consumer>
// {
//     protected override void ConfigureConsumer(
//         IReceiveEndpointConfigurator endpointConfigurator,
//         IConsumerConfigurator<State1Consumer> consumerConfigurator
//     )
//     {
//         // Add retry policy
//         endpointConfigurator.UseMessageRetry(
//             r => { r.Exponential(300, TimeSpan.FromSeconds(1), TimeSpan.FromMinutes(30), TimeSpan.FromSeconds(1)); }
//         );
//     }
// }