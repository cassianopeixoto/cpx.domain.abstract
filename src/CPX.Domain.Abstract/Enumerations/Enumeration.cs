namespace CPX.Domain.Abstract.Enumerations;

public abstract class Enumeration(string code, string name)
{
    public string Code { get; init; } = code;
    public string Name { get; init; } = name;
}