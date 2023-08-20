namespace Sample.Contracts
{
    using System;


    public record CoffeeNotFound
    {
        public Guid Id { get; init; }
    }
}