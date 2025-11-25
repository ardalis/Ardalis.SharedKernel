using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Ardalis.SharedKernel.UnitTests.GuidGeneratorTest;
public class GenerateSequentialGuids
{

  [Fact]
  public void GeneratesSequentialGuids()
  {
    // Arrange

    var services = new ServiceCollection();

    services.RegisterSequentialGuidGenerator();

    var serviceProvider = services.BuildServiceProvider();

    var sequentialGuidGenerator = serviceProvider.GetRequiredService<ISequentialGuidGenerator>();


    // Act

    var guid1 = sequentialGuidGenerator.NewSequentialGuid();
    var guid2 = sequentialGuidGenerator.NewSequentialGuid();
    var guid3 = sequentialGuidGenerator.NewSequentialGuid();


    // Assert

    /// To sort in the same order as as SQL Server sort by, we need to compare the last 6 bytes of the Guid.
    var s1 = guid1.ToString().Substring(24);
    var s2 = guid2.ToString().Substring(24);
    var s3 = guid3.ToString().Substring(24);

    s1.CompareTo(s2).Should().BeLessThan(0);
    s2.CompareTo(s3).Should().BeLessThan(0);

  }
}

