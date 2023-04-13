using CPX.Domain.Abstract.Identifiers;

namespace CPX.Domain.Abstract.Entities;

public abstract class Entity
{
    protected Entity() {}

    protected Entity(Identifier id, DateTimeOffset createdAt)
    {
        Id = id;
        CreatedAt = createdAt;
    }

    public Identifier? Id { get; protected set; }
    public DateTimeOffset CreatedAt { get; protected set; }
    public DateTimeOffset UpdatedAt { get; protected set; }
}