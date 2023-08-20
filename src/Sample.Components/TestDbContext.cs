namespace Sample.Components
{
    using System.Collections.Generic;
    using MassTransit.EntityFrameworkCoreIntegration;
    using Microsoft.EntityFrameworkCore;


    public class TestDbContext :
        SagaDbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options)
            : base(options)
        {
        }

        protected override IEnumerable<ISagaClassMap> Configurations
        {
            get { yield return new TestStateMap(); }
        }
    }
}