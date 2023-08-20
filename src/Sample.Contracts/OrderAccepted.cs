namespace Sample.Contracts
{
    using System;


    public record OrderAccepted
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Status { get; init; }
    }
}