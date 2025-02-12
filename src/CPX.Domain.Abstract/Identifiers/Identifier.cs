namespace CPX.Domain.Abstract.Identifiers;

public class Identifier
{
    protected Identifier(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static Identifier New() => new(Guid.NewGuid());

    public static Identifier New(Guid value) => new(value);

    public bool Equals(Identifier identifier)
    {
        return identifier is not null && identifier.Value == Value;
    }

    public override bool Equals(object? obj)
    {
        return obj is Identifier identifier && Equals(identifier);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public override string ToString()
    {
        return Value.ToString();
    }

    public static implicit operator Guid(Identifier identifier)
    {
        if (identifier is null)
            return Guid.Empty;

        return identifier.Value;
    }

    public static implicit operator Identifier(Guid value)
    {
        return new Identifier(value);
    }

    public static implicit operator Identifier(string value)
    {
        if (Guid.TryParse(value, out Guid id).Equals(false))
            throw new ArgumentException($"Cannot convert '{value}' to Guid");

        return new Identifier(id);
    }
    public static bool operator ==(Identifier left, Identifier right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Identifier left, Identifier right)
    {
        return !(left == right);
    }
}