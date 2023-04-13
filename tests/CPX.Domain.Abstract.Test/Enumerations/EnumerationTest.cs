using CPX.Domain.Abstract.Enumerations;

namespace CPX.Domain.Abstract.Test.Enumerations;

public class EnumerationTest
{
    [Fact]
    public void Should_be_able_to_create()
    {
        // Arrange
        var code = "CODE";
        var name = "Code";
        // Act
        var mockEnumeration = new Mock<Enumeration>(code, name);
        var enumeration = mockEnumeration.Object;
        // Assert
        Assert.Equal(code, enumeration.Code);
        Assert.Equal(name, enumeration.Name);
    }
}