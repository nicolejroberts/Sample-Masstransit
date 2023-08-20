namespace Sample.Components.StateMachines
{
    using System;
    using Consumers;
    using MassTransit;


    public class TestState :
        SagaStateMachineInstance
    {
        public string CurrentState { get; set; }

        public Guid CorrelationId { get; set; }
    }


    public class TestStateSagaDefinition : SagaDefinition<TestState>
    {
        private const int ConcurrencyLimit = 20; // this can go up, depending upon the database capacity
    
        protected override void ConfigureSaga(IReceiveEndpointConfigurator endpointConfigurator, ISagaConfigurator<TestState> sagaConfigurator)
        {
            endpointConfigurator.UseRetry(r => r.Interval(20, 100));
            // endpointConfigurator.UseInMemoryOutbox();
        }
    }
}