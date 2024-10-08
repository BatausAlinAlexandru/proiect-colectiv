namespace Domain.Entities
{
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; private set; }

        protected BaseEntity() { 
            Id = Guid.NewGuid();
        }
    }
}
