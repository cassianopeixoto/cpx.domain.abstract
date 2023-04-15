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
        ThrowArgumentNullException(identifier);
        return identifier != null && identifier.Value == Value;
    }

    public override bool Equals(object? obj)
    {
        ThrowArgumentNullException(obj);
        var identifier = obj as Identifier;
        return Equals(identifier);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static bool operator ==(Identifier? first, Identifier? second)
    {
        ThrowArgumentNullException(first, second);
        return first != null && first.Equals(second);
    }

    public static bool operator !=(Identifier? first, Identifier? second)
    {
        ThrowArgumentNullException(first, second);
        return first != null && first.Equals(second) == false;
    }

    public static implicit operator Guid(Identifier? identifier)
    {
        ThrowArgumentNullException(identifier);

        if (identifier == null)
            return Guid.Empty;

        return identifier.Value;
    }

    public static implicit operator Identifier(string value)
    {
        if (Guid.TryParse(value, out Guid id).Equals(false))
            throw new ArgumentException($"Cannot convert '{value}' to Guid");

        return new Identifier(id);
    }

    private static void ThrowArgumentNullException(object? first, object? second)
    {
        ThrowArgumentNullException(first);
        ThrowArgumentNullException(second);
    }

    private static void ThrowArgumentNullException(object? identifier)
    {
        if (identifier == null) throw new ArgumentNullException(nameof(identifier));
    }
}