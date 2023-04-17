using CPX.Domain.Abstract.Identifiers;

namespace CPX.Domain.Abstract.Entities;

public abstract class Entity
{
    public Identifier Id { get; protected set; }
    public DateTimeOffset CreatedAt { get; protected set; }
    public Guid UpdatedBy { get; protected set; }
    public DateTimeOffset UpdatedAt { get; protected set; }
}