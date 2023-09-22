namespace UnitTestingSamples;

public class MathOpsTests
{
  [Fact]
  public void Test1()
  {
    // Arrange
    // We use real implementation of IHistoryWriter for app code and use Mock for tests
    var writer = new MockHistoryWriter();
    // Act
    var x = MathOps.Sum(writer, 10, 30);
    Assert.Equal(40, x);

    // Assert
    Assert.Equal("10+30", writer.Operation);
    Assert.Equal(40, writer.Result);
  }

}