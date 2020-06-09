using System;

namespace DomainDriven
{
    public class Entity : IEntity
    {
        #region Properties

        public Guid Id { get; }

        public DateTimeOffset Created { get; protected set; }

        public DateTimeOffset Updated { get; protected set; }

        public DateTimeOffset? Deleted { get; protected set; }

        #endregion

        #region Constructors

        public Entity(Guid entityId)
        {
            Id = entityId;
            Created = DateTimeOffset.UtcNow;
            Updated = DateTimeOffset.UtcNow;
        }

        public Entity(Guid entityId, DateTimeOffset created, DateTimeOffset updated)
        {
            Id = entityId;
            Created = created;
            Updated = updated;
        }

        #endregion

        #region Methods

        public virtual bool IsSameAs(IEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return Id == entity.Id;
        }

        #endregion Methods
    }
}
