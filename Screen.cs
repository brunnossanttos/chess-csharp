namespace ChessBoard
{
  public class Screen
  {
    public static void PrintBoard(Board board)
    {
      for (int i = 0; i < board.Lines; i++)
      {
        Console.Write(8 - i + " ");
        for (int j = 0; j < board.Columns; j++)
        {
          Piece? piece = board.GetPiece(i, j);
          if (piece == null)
          {
            Console.Write("- ");
          }
          else
          {
            Console.Write(piece + " ");
          }
        }
        Console.WriteLine();
      }
      Console.WriteLine("  a b c d e f g h");
    }

    public static Position ReadPosition()
    {
      string? input = Console.ReadLine();
      if (string.IsNullOrEmpty(input) || input.Length < 2)
      {
        throw new ChessBoardException("Posição inválida!");
      }

      char column = input[0];
      int line = int.Parse(input[1].ToString());

      return new Position(8 - line, column - 'a');
    }

    public static void PrintMatch(Chess.ChessMatch match)
    {
      PrintBoard(match.Board);
      Console.WriteLine();
      Console.WriteLine($"Turno: {match.Turn}");
      Console.WriteLine($"Aguardando jogada: {match.CurrentPlayer}");
    }

    public static void PrintPiece(Piece? piece)
    {
      if (piece == null)
      {
        Console.WriteLine("No piece at this position.");
      }
      else
      {
        Console.WriteLine("Piece: " + piece);
        Console.WriteLine("Color: " + piece.Color);
        Console.WriteLine("Position: " + piece.Position);
        Console.WriteLine("Move Count: " + piece.MoveCount);
      }
    }
  }
}