using System.Runtime.InteropServices;

namespace Domain.Entities
{
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; } = Guid.NewGuid();
    }
}
