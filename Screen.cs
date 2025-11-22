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