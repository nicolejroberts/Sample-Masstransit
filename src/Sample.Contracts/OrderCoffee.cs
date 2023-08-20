namespace Sample.Contracts
{
    using System;
    using System.Runtime.CompilerServices;
    using MassTransit;


    public record OrderCoffee
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
    }
}