namespace Sample.Contracts
{
    using System;
    using System.Runtime.CompilerServices;
    using MassTransit;


    public record MakeCoffee
    {
        public Guid Id { get; init; }
    }
}