namespace CPX.Domain.Abstract.Identifiers;

public class Identifier
{
    protected Identifier(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public bool Equals(Identifier? identifier)
    {
        if (identifier is null) throw new ArgumentNullException(nameof(identifier));

        return Value == identifier.Value;
    }

    public override bool Equals(object? obj)
    {
        var identifier = obj as Identifier;

        return Equals(identifier);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static bool operator ==(Identifier first, Identifier second)
    {
        if (first is null) throw new ArgumentNullException(nameof(first));

        return first.Equals(second);
    }

    public static bool operator !=(Identifier first, Identifier second)
    {
        if (first is null) throw new ArgumentNullException(nameof(first));

        return first.Equals(second) == false;
    }

    public static implicit operator Guid(Identifier identifier)
    {
        if (identifier is null) throw new ArgumentNullException(nameof(identifier));

        return identifier.Value;
    }

    public static implicit operator Identifier(string value)
    {
        if (Guid.TryParse(value, out Guid id).Equals(false))
            throw new ArgumentException($"Cannot convert '{value}' to Guid");

        return new Identifier(id);
    }
}