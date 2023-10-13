namespace UnitTestingSamples.Sample6;

public class TriangleChecker
{
  public static bool Check(float a, float b, float c)
  {
    if (a <= 0 || b <= 0 || c <= 0)
      return false;
    else if (a >= b + c || b >= a + c || c >= a + b)
      return false;
    else
      return true;
  }
}

public class TriangleCheckerTests
{
  // -1, 3, 1 -> false
  // 1, 0, 3 -> false
  // 1, 2, -2 -> false
  
  // 2, 2, 2 -> true
  
  // 20, 2, 2 -> false
  // 2, 20, 2 -> false
  // 2, 2, 20 -> false
  
  [InlineData(-1, 3, 1)]
  [InlineData(1, 0, 3)]
  [InlineData(1, 2, -2)]
  [Theory]
  public void When_OneOfTheSidesIsNegative_Should_ReturnFalse(int a, int  b, int c)
  {
    // Act
    var result = TriangleChecker.Check(a, b, c);
    
    // Assert
    Assert.False(result);
  }

  [Fact]
  public void When_AllSidesAreEqual_Should_ReturnTrue() => Assert.True(TriangleChecker.Check(2, 2, 2));

  [InlineData(20, 2, 2)]
  [InlineData(2, 20, 2)]
  [InlineData(2, 2, 20)]
  [Theory]
  public void When_OneSideIsGreaterOrEqualThenTheSumOfTwoOthers_Should_Return_False(float a, float b, float c)
  {
    Assert.False(TriangleChecker.Check(a, b, c));
  }
}