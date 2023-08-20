namespace Sample.Contracts
{
    using System;


    public record Coffee
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Status { get; init; }
    }
}