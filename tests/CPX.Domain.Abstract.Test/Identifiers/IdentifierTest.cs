using CPX.Domain.Abstract.Identifiers;

namespace CPX.Domain.Abstract.Test.Identifiers;

public class IdentifierTest
{
    [Fact]
    public void Should_be_able_to_create()
    {
        // Arrange
        var id = Guid.NewGuid();
        // Act
        var identifier = Identifier.New(id);
        // Assert
        Assert.Equal(id, identifier.Value);
    }

    [Fact]
    public void Should_be_able_to_check_equality()
    {
        // Arrange
        var id = Guid.NewGuid();
        var firstIdentifier = Identifier.New(id);
        var secondIdentifier = Identifier.New(id);
        // Act
        var areEqualsUsingMethod = firstIdentifier.Equals(secondIdentifier);
        var areEqualsUsingOperator = firstIdentifier == secondIdentifier;
        // Assert
        Assert.True(areEqualsUsingMethod);
        Assert.True(areEqualsUsingOperator);
    }

    [Fact]
    public void Should_be_able_to_check_inequality()
    {
        // Arrange
        var firstId = Guid.NewGuid();
        var secondId = Guid.NewGuid();
        var firstIdentifier = Identifier.New(firstId);
        var secondIdentifier = Identifier.New(secondId);
        // Act
        var areEqualsUsingMethod = firstIdentifier.Equals(secondIdentifier);
        var areEqualsUsingOperator = firstIdentifier != secondIdentifier;
        // Assert
        Assert.False(areEqualsUsingMethod);
        Assert.True(areEqualsUsingOperator);
    }

    [Fact]
    public void Should_be_able_to_implict_convert_to_Guid()
    {
        // Arrange
        var id = Guid.NewGuid();
        var identifier = Identifier.New(id);
        // Act
        Guid convertedId = identifier;
        // Assert
        Assert.Equal(id, convertedId);
    }
}