using System.Reflection;
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
                // SOLVED: Source: https://stackoverflow.com/questions/75462566/how-to-publish-a-specific-event-from-an-implemented-interface/75466972#75466972
                //_bus.Publish(personEvent);
                _bus.Publish((object)personEvent);
            }

            // Of course this two lines works!
            //_bus.Publish(new PersonCreated() { Id = 1 });
            //_bus.Publish<PersonPositionCreated>(new PersonPositionCreated() { Position  = "Developer" });



            return Task.FromResult("ok");
        }
    }
}
