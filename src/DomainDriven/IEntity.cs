using System;

namespace DomainDriven
{
    public interface IEntity
    {
        Guid Id { get; }

        DateTimeOffset Created { get; }

        DateTimeOffset Updated { get; }

        DateTimeOffset? Deleted { get; }
    }
}
