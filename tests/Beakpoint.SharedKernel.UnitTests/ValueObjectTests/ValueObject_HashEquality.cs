using FluentAssertions;
using Xunit;

namespace Ardalis.SharedKernel.UnitTests.ValueObjectTests;
public class ValueObject_HashEquality
{
  [Fact]
  public void WithSameValuesHaveSameHashCode()
  {
    // Arrange
    var valueObject1 = new TestValueObject(1);
    var valueObject2 = new TestValueObject(1);

    // Act & Assert
    valueObject1.GetHashCode().Should().Be(valueObject2.GetHashCode());
  }

  [Fact]
  public void WithDifferentValuesAreNotEqual()
  {
    // Arrange
    var valueObject1 = new TestValueObject(1);
    var valueObject2 = new TestValueObject(2);

    // Act & Assert
    valueObject1.Should().NotBe(valueObject2);
  }
}
