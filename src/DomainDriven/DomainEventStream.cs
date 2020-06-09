using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainDriven
{
    public class DomainEventStream : IDomainEventStream
    {
        #region Declarations

        private readonly IDomainEvent[] _domainEvents;

        #endregion Declarations

        #region Properties

        public Guid AggregateRootId { get; }

        public int DomainEventCount { get; }

        #endregion Properties

        #region Constructors

        public DomainEventStream(Guid aggreggateRootId)
        {
            AggregateRootId = aggreggateRootId;
            _domainEvents = new IDomainEvent[0];
        }

        public DomainEventStream(Guid aggregateRootId, IEnumerable<IDomainEvent> domainEvents)
        {
            if (domainEvents == null)
            {
                throw new ArgumentNullException(nameof(domainEvents));
            }

            _domainEvents = domainEvents.ToArray();

            AggregateRootId = aggregateRootId;
            DomainEventCount = _domainEvents.Length;
        }

        #endregion Constructors

        public DomainEventStream AppendDomainEvent(IDomainEvent domainEventToAppend)
        {
            if (domainEventToAppend == null)
            {
                throw new ArgumentNullException(nameof(domainEventToAppend));
            }

            if (!AggregateRootId.Equals(domainEventToAppend.AggregateRootId))
            {
                throw new InvalidOperationException("Cannot append domain event belonging to a different aggregate root.");
            }

            return new DomainEventStream(AggregateRootId, this.Concat(new[] { domainEventToAppend }));
        }

        public DomainEventStream AppendDomainEventStream(IDomainEventStream streamToAppend)
        {
            if (streamToAppend == null)
            {
                throw new ArgumentNullException(nameof(streamToAppend));
            }

            if (!AggregateRootId.Equals(streamToAppend.AggregateRootId))
            {
                throw new InvalidOperationException("Cannot append domain events belonging to a different aggregate root.");
            }

            return new DomainEventStream(AggregateRootId, this.Concat(streamToAppend));
        }

        public IEnumerator<IDomainEvent> GetEnumerator()
        {
            foreach (IDomainEvent domainEvent in _domainEvents)
            {
                yield return domainEvent;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (IDomainEvent domainEvent in _domainEvents)
            {
                yield return domainEvent;
            }
        }
    }
}
