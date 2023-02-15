namespace WebApplication1.Events
{
    public class PersonPositionCreated : IDomainEvent
    {
        public string Position { get; set; }
    }
}