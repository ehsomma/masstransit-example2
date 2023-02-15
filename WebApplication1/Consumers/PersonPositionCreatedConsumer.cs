using System.Diagnostics;
using MassTransit;
using WebApplication1.Events;

namespace WebApplication1.Consumers
{
    public class PersonPositionCreatedConsumer : IConsumer<PersonPositionCreated>
    {
        public Task Consume(ConsumeContext<PersonPositionCreated> context)
        {
            Debug.Print(context.Message.Position);
            return Task.CompletedTask;
        }
    }
}