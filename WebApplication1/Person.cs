using WebApplication1.Events;

namespace WebApplication1
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Position { get; set; }

        public List<IDomainEvent> Events { get; set; } = new List<IDomainEvent>();
    }
}
