namespace Sample.Components.Consumers;

using System;
using System.Threading.Tasks;
using MassTransit;

public class State3Request
{
    public Guid CorrelationId { get; init; }
}

public class State3Response
{
    public Guid CorrelationId { get; init; }
}

public class State3Consumer : IConsumer<State3Request>
{
    public async Task Consume(
        ConsumeContext<State3Request> context
    )
    {
        await Task.Delay(1000);
        await context.Publish(new State3Response {CorrelationId = context.Message.CorrelationId});
    }
}

// public class State3ConsumerDefinition :
//     ConsumerDefinition<State3Consumer>
// {
//     protected override void ConfigureConsumer(
//         IReceiveEndpointConfigurator endpointConfigurator,
//         IConsumerConfigurator<State3Consumer> consumerConfigurator
//     )
//     {
//         // Add retry policy
//         endpointConfigurator.UseMessageRetry(
//             r => { r.Exponential(300, TimeSpan.FromSeconds(1), TimeSpan.FromMinutes(30), TimeSpan.FromSeconds(1)); }
//         );
//     }
// }