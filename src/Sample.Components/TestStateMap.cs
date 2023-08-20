namespace Sample.Components
{
    using MassTransit;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using StateMachines;


    public class TestStateMap :
        SagaClassMap<TestState>
    {
        protected override void Configure(EntityTypeBuilder<TestState> entity, ModelBuilder model)
        {
            base.Configure(entity, model);

            entity.Property(x => x.CurrentState).HasMaxLength(40);
        }
    }
}