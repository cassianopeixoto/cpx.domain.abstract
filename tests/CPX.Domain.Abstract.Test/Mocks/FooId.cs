using CPX.Domain.Abstract.Identifiers;

namespace CPX.Domain.Abstract.Test.Mocks;

public class FooId : Identifier
{
    public FooId(Guid value) : base(value)
    {
    }
}