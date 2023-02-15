using MassTransit;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Events;

namespace WebApplication1.Controllers
{
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IBus _bus;

        public TestController(IBus bus)
        {
            _bus = bus;
        }

        [HttpPost]
        [Route("testPostAsync")]
        public Task<string> PostAsync(string value)
        {

            Person person = new Person(){ Id = 1, Name = "Alice", Position = "Developer" };
            person.Events.Add(new PersonCreated() { Id = person.Id });
            person.Events.Add(new PersonPositionCreated() { Position = person.Position });

            foreach (IDomainEvent personEvent in person.Events)
            {
                _bus.Publish(personEvent);
            }

            // Of course this two lines works!
            //_bus.Publish<PersonCreated>(new PersonCreated() { Id = 1 });
            //_bus.Publish<PersonPositionCreated>(new PersonPositionCreated() { Position  = "Developer" });



            return Task.FromResult("ok");
        }
    }
}
