using System;

namespace DomainDriven
{
    public interface IDomainEvent
    {
        Guid AggregateRootId { get; }

        DateTimeOffset TimeStamp { get; }
    }
}
