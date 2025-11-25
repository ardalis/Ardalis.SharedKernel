using Microsoft.Extensions.DependencyInjection;

namespace Acme.SharedKernel.UnitTests.GuidGeneratorTest;
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

    // For GUID v7 the timestamp is the first 48 bits (12 hex chars) in the canonical hex representation.
    // Use ToString("N") (no dashes) and parse the first 12 hex chars as an unsigned integer.
    static ulong ExtractV7Timestamp(Guid g)
    {
      var hex = g.ToString("N").Substring(0, 12); // first 12 hex chars = 48 bits
      return Convert.ToUInt64(hex, 16);
    }

    var t1 = ExtractV7Timestamp(guid1);
    var t2 = ExtractV7Timestamp(guid2);
    var t3 = ExtractV7Timestamp(guid3);

    t1.Should().BeLessThan(t2);
    t2.Should().BeLessThan(t3);

  }
}

