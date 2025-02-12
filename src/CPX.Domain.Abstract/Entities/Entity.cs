using CPX.Domain.Abstract.Identifiers;

namespace CPX.Domain.Abstract.Entities;

public abstract class Entity(Identifier id, DateTimeOffset createdAt, Guid updatedBy, DateTimeOffset updatedAt)
{
    public Identifier Id { get; init; } = id;
    public DateTimeOffset CreatedAt { get; init; } = createdAt;
    public Guid UpdatedBy { get; protected set; } = updatedBy;
    public DateTimeOffset UpdatedAt { get; protected set; } = updatedAt;
}
