namespace CPX.Domain.Abstract.Identifiers;

public abstract class Identifier
{
    protected Identifier(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public bool Equals(Identifier identifier)
    {
        return Value == identifier.Value;
    }

    public override bool Equals(object? obj)
    {
        var identifier = obj as Identifier;

        return identifier is not null && Equals(identifier);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static bool operator ==(Identifier first, Identifier second)
    {
        return first.Equals(second);
    }

    public static bool operator !=(Identifier first, Identifier second)
    {
        return first.Equals(second) == false;
    }

    public static implicit operator Guid(Identifier identifier)
    {
        return identifier.Value;
    }
}