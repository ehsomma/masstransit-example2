namespace WebApplication1.Events
{
    public class PersonCreated : IDomainEvent
    {
        public int Id { get; set; }
    }
}
