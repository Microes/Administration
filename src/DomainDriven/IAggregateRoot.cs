namespace DomainDriven
{
    public interface IAggregateRoot : IEntity
    {
        IDomainEventStream GetDomainEventsMarkedForCommit();

        void MarkDomainEventsAsCommitted();
    }
}
