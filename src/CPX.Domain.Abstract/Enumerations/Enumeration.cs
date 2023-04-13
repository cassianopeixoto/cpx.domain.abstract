namespace CPX.Domain.Abstract.Enumerations;

public abstract class Enumeration
{
    public Enumeration(string code, string name)
    {
        Code = code;
        Name = name;
    }

    public string Code { get; }
    public string Name { get; }
}