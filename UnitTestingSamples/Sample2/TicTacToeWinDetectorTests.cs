namespace UnitTestingSamples;

// Should_ExpectedBehavior_When_StateUnderTest
public class TicTacToeWinDetectorTests
{
  [Fact]
  public void Should_TicWins_When_VerticalLineIsFilled()
  {
    // Arrange
    var board = new[]
    {
      new[] { 'X', '-', '-' },
      new[] { 'X', '-', '-' },
      new[] { 'X', '-', '-' },
    };

    // Act
    var result = TicTacToeWinDetector.IsWin(board, 'X');

    // Assert
    Assert.True(result);
  }

  [Fact]
  public void Should_TacWins_When_VerticalLineIsFilled()
  {
    // Arrange
    var board = new[]
    {
      new[] { '0', '-', '-' },
      new[] { '0', '-', '-' },
      new[] { '0', '-', '-' },
    };

    // Act
    var result = TicTacToeWinDetector.IsWin(board, '0');

    // Assert
    Assert.True(result);
  }

  [Fact]
  public void Should_TicWins_When_HorizontalLineIsFilled()
  {
    // Arrange
    var board = new[]
    {
      new[] { 'X', 'X', 'X' },
      new[] { '0', '-', '-' },
      new[] { '0', '-', '-' },
    };

    // Act
    var result = TicTacToeWinDetector.IsWin(board, 'X');

    // Assert
    Assert.True(result);
  }

  [Fact]
  public void Should_TicWins_When_MainDiagonalLineIsFilled()
  {
    // Arrange
    var board = new[]
    {
      new[] { 'X', '-', '0' },
      new[] { '0', 'X', '-' },
      new[] { '0', '-', 'X' },
    };

    // Act
    var result = TicTacToeWinDetector.IsWin(board, 'X');

    // Assert
    Assert.True(result);
  }

  [Fact]
  public void Should_NobodyWins_When_NoFullLinesAreFilled()
  {
    // Arrange
    var board = new[]
    {
      new[] { 'X', '-', '0' },
      new[] { '0', '0', '-' },
      new[] { '-', '-', 'X' },
    };

    // Act
    var ticWin = TicTacToeWinDetector.IsWin(board, 'X');
    var tacWin = TicTacToeWinDetector.IsWin(board, '0');

    // Assert
    Assert.False(ticWin);
    Assert.False(tacWin);
  }

  [Fact]
  public void Should_NobodyWins_When_BoardIsEmpty()
  {
    // Arrange
    var board = new[]
    {
      new[] { '-', '-', '-' },
      new[] { '-', '-', '-' },
      new[] { '-', '-', '-' },
    };

    // Act
    var ticResult = TicTacToeWinDetector.IsWin(board, 'X');
    var tacResult = TicTacToeWinDetector.IsWin(board, '0');

    // Assert
    Assert.False(ticResult);
    Assert.False(tacResult);
  }

  [Fact]
  public void Should_TacWins_When_MainDiagonalIsFilled()
  {
    // Arrange
    var board = new[]
    {
      new[] { '0', '-', 'X' },
      new[] { '-', '0', '-' },
      new[] { 'X', '-', '0' },
    };

    // Act
    var ticResult = TicTacToeWinDetector.IsWin(board, 'X');
    var tacResult = TicTacToeWinDetector.IsWin(board, '0');

    // Assert
    Assert.False(ticResult);
    Assert.True(tacResult);
  }

  [Fact]
  public void Should_TicWins_When_SecondaryDiagonalIsFilled()
  {
    // Arrange
    var board = new[]
    {
      new[] { '0', '-', 'X' },
      new[] { '-', 'X', '-' },
      new[] { 'X', '-', '0' },
    };

    // Act
    var ticResult = TicTacToeWinDetector.IsWin(board, 'X');
    var tacResult = TicTacToeWinDetector.IsWin(board, '0');

    // Assert
    Assert.True(ticResult);
    Assert.False(tacResult);
  }
}