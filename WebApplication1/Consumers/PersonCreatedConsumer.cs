using System.Diagnostics;
using MassTransit;
using WebApplication1.Events;

namespace WebApplication1.Consumers
{
    public class PersonCreatedConsumer : IConsumer<PersonCreated>
    {
        public Task Consume(ConsumeContext<PersonCreated> context)
        {
            Debug.Print(context.Message.Id.ToString());
            return Task.CompletedTask;
        }
    }
}
