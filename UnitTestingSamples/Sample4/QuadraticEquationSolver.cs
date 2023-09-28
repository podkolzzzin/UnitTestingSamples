namespace UnitTestingSamples.Sample4;

public class QuadraticEquationSolver
{
  /// <summary>
  /// Returns empty array if there are no roots.
  /// Returns one-element array if there is one root.
  /// Returns two-element array if there are two roots.
  /// </summary>
  /// <param name="a"></param>
  /// <param name="b"></param>
  /// <param name="c"></param>
  /// <returns></returns>
  /// <exception cref="NotImplementedException"></exception>
  public static double[] Solve(double a, double b, double c)
  {
    var D = b * b - 4 * a * c;
    if (D < 0)
      return Array.Empty<double>();
    else if (D == 0)
      return new[] { -b / (2 * a) };
    else
    {
      var x1 = (-b + Math.Sqrt(D)) / (2 * a);
      var x2 = (-b - Math.Sqrt(D)) / (2 * a);
      return new[] { x1, x2 };
    }
  }

  public class QuadraticEquationSolverTests
  {
    [Fact]
    public void Should_ReturnEmptyArray_When_DiscriminantIsNegative()
    {
      // Arrange
      var a = 1;
      var b = 2;
      var c = 3;

      // Act
      var result = QuadraticEquationSolver.Solve(a, b, c);

      // Assert
      Assert.Empty(result);
    }

    [Fact]
    public void Should_ReturnOneElementArray_When_DiscriminantIsZero()
    {
      // Arrange
      var a = 1;
      var b = 2;
      var c = 1;


      // Act
      var result = QuadraticEquationSolver.Solve(a, b, c);

      // Assert
      Assert.Single(result);
      Assert.Equal(-1, result[0]);
    }

    [Fact]
    public void Should_ReturnTwoElementArray_When_DiscriminantIsPositive()
    {
      // Arrange
      var a = 1;
      var b = 5;
      var c = 1;

      // D = 25 - 4 = 21

      // Act
      var result = QuadraticEquationSolver.Solve(a, b, c);

      // Assert
      Assert.Equal(2, result.Length);
      Assert.Equal(-0.20871215252208009, result[0]);
      Assert.Equal(-4.7912878474779191, result[1]);
    }
  }
}