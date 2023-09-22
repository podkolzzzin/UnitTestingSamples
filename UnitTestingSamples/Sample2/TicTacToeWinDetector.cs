namespace UnitTestingSamples;

public static class TicTacToeWinDetector
{
   public static bool IsWin(char[][] board, char ticOrTac)
   {
      return IsWinInRow(board, ticOrTac) ||
             IsWinInColumn(board, ticOrTac) ||
             IsWinInDiagonal(board, ticOrTac);
   }

   private static bool IsWinInRow(char[][] board, char ticOrTac)
   {
      for (var row = 0; row < board.Length; row++)
      {
         if (board[row][0] == ticOrTac &&
             board[row][1] == ticOrTac &&
             board[row][2] == ticOrTac)
         {
            return true;
         }
      }

      return false;
   }

   private static bool IsWinInColumn(char[][] board, char ticOrTac)
   {
      for (var column = 0; column < board[0].Length; column++)
      {
         if (board[0][column] == ticOrTac &&
             board[1][column] == ticOrTac &&
             board[2][column] == ticOrTac)
         {
            return true;
         }
      }

      return false;
   }

   private static bool IsWinInDiagonal(char[][] board, char ticOrTac)
   {
      if (board[0][0] == ticOrTac &&
          board[1][1] == ticOrTac &&
          board[2][2] == ticOrTac)
      {
         return true;
      }

      if (board[0][2] == ticOrTac &&
          board[1][1] == ticOrTac &&
          board[2][0] == ticOrTac)
      {
         return true;
      }

      return false;
   }
}