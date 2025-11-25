namespace Ardalis.SharedKernel.UnitTests.EntityBaseTests;
public class TestClass : EntityBase<RoleId>
{
  protected TestClass() { }

  public TestClass(RoleId id)
  {
    Id = id;
  }
}

public record RoleId
{
  public RoleId(Guid value) => Value = value;

  public Guid Value { get; init; }
}
