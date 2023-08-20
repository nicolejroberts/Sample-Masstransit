namespace Sample.Components.StateMachines
{
    using System;
    using Consumers;
    using Contracts;
    using MassTransit;


    public class TestStateMachine :
        MassTransitStateMachine<TestState>
    {
        public State Started { get; }
        public State State1Complete { get; }
        public State State2Complete { get; }
        public State State3Complete { get; }

        public TestStateMachine()
        {
            //Setup
            Event(() => StartProcessRequest, x =>
            {
                x.CorrelateById(i => i.Message.CorrelationId);
            });
            Event(() => State1Request, x =>
            {
                x.CorrelateById(i => i.Message.CorrelationId);
            });
            Event(() => State1Response, x =>
            {
                x.CorrelateById(i => i.Message.CorrelationId);
            });
            //Setup
            Event(() => State2Request, x =>
            {
                x.CorrelateById(i => i.Message.CorrelationId);
            });
            Event(() => State2Response, x =>
            {
                x.CorrelateById(i => i.Message.CorrelationId);
            });
            //Setup
            Event(() => State3Request, x =>
            {
                x.CorrelateById(i => i.Message.CorrelationId);
            });
            Event(() => State3Response, x =>
            {
                x.CorrelateById(i => i.Message.CorrelationId);
            });


            InstanceState(x => x.CurrentState);

            Initially(
                When(StartProcessRequest)
                    .TransitionTo(Started)
                    .ThenAsync(async context =>
                    {
                        Console.WriteLine("Requested");
                    })
                    .PublishAsync(context => context.Init<State1Request>(new
                    {
                        CorrelationId = context.Saga.CorrelationId,
                    }))
            );

            During(Started,
                When(State1Response)
                    .TransitionTo(State1Complete)
                    .ThenAsync(async context =>
                    {
                        Console.WriteLine("State1Response");
                    })
                    .PublishAsync(context => context.Init<State2Request>(new
                    {
                        CorrelationId = context.Saga.CorrelationId,
                    }))
            );

            During(State1Complete,
                When(State2Response)
                    .TransitionTo(State2Complete)
                    .ThenAsync(async context =>
                    {
                        Console.WriteLine("State2Response");
                    })
                    .PublishAsync(context => context.Init<State3Request>(new
                    {
                        CorrelationId = context.Saga.CorrelationId,
                    }))
            );

            During(State2Complete,
                When(State3Response)
                    .TransitionTo(State3Complete)
                    .ThenAsync(async context =>
                    {
                        Console.WriteLine("State3Response");
                    })
            );
        }

        public Event<StartProcessRequest> StartProcessRequest { get; }
        public Event<State1Request> State1Request { get; }
        public Event<State1Response> State1Response { get; }
        public Event<State2Request> State2Request { get; }
        public Event<State2Response> State2Response { get; }
        public Event<State3Request> State3Request { get; }
        public Event<State3Response> State3Response { get; }
    }


    public class StartProcessRequest
    {
        public Guid CorrelationId { get; init; }
    }
}