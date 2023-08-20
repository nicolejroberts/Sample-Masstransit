namespace Sample.Contracts
{
    using System;
    using System.Runtime.CompilerServices;
    using MassTransit;


    public record GetCoffee
    {
        public Guid Id { get; init; }
    }
}