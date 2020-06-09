using System;
using System.Collections.Generic;

namespace DomainDriven
{
    public interface IDomainEventStream : IEnumerable<IDomainEvent>
    {
        Guid AggregateRootId { get; }

        int DomainEventCount { get; }
    }
}
