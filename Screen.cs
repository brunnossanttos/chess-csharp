namespace ChessBoard
{
  public class Screen
  {
    public static void PrintBoard(Board board, Color currentPlayer)
    {
      if (currentPlayer == Color.White)
      {
        for (int i = 0; i < board.Lines; i++)
        {
          Console.Write(8 - i + " ");
          for (int j = 0; j < board.Columns; j++)
          {
            Piece? piece = board.GetPiece(i, j);
            PrintPieceColor(piece, false);
          }
          Console.WriteLine();
        }
        Console.WriteLine("  a b c d e f g h");
      }
      else
      {
        for (int i = board.Lines - 1; i >= 0; i--)
        {
          Console.Write(8 - i + " ");
          for (int j = board.Columns - 1; j >= 0; j--)
          {
            Piece? piece = board.GetPiece(i, j);
            PrintPieceColor(piece, false);
          }
          Console.WriteLine();
        }
        Console.WriteLine("  h g f e d c b a");
      }
    }

    public static void PrintBoard(Board board, bool[,] possiblePositions, Color currentPlayer)
    {
      ConsoleColor originalBackground = Console.BackgroundColor;
      ConsoleColor highlightBackground = ConsoleColor.DarkGray;

      if (currentPlayer == Color.White)
      {
        for (int i = 0; i < board.Lines; i++)
        {
          Console.Write(8 - i + " ");
          for (int j = 0; j < board.Columns; j++)
          {
            if (possiblePositions[i, j])
            {
              Console.BackgroundColor = highlightBackground;
            }
            else
            {
              Console.BackgroundColor = originalBackground;
            }

            Piece? piece = board.GetPiece(i, j);
            PrintPieceColor(piece, possiblePositions[i, j]);
          }
          Console.WriteLine();
          Console.BackgroundColor = originalBackground;
        }
        Console.WriteLine("  a b c d e f g h");
      }
      else
      {
        for (int i = board.Lines - 1; i >= 0; i--)
        {
          Console.Write(8 - i + " ");
          for (int j = board.Columns - 1; j >= 0; j--)
          {
            if (possiblePositions[i, j])
            {
              Console.BackgroundColor = highlightBackground;
            }
            else
            {
              Console.BackgroundColor = originalBackground;
            }

            Piece? piece = board.GetPiece(i, j);
            PrintPieceColor(piece, possiblePositions[i, j]);
          }
          Console.WriteLine();
          Console.BackgroundColor = originalBackground;
        }
        Console.WriteLine("  h g f e d c b a");
      }
      Console.BackgroundColor = originalBackground;
    }

    private static void PrintPieceColor(Piece? piece, bool highlight)
    {
      if (piece == null)
      {
        Console.Write("- ");
      }
      else
      {
        if (piece.Color == Color.White)
        {
          Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
          Console.ForegroundColor = ConsoleColor.Yellow;
        }
        Console.Write(piece + " ");
        Console.ResetColor();
      }
      Console.BackgroundColor = ConsoleColor.Black;
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
      PrintBoard(match.Board, match.CurrentPlayer);
      Console.WriteLine();
      PrintCapturedPieces(match);
      Console.WriteLine();
      Console.WriteLine($"Turno: {match.Turn}");
      
      if (!match.Finished)
      {
        if (match.Check)
        {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine("XEQUE!");
          Console.ResetColor();
        }
        
        Console.WriteLine($"Aguardando jogada: {match.CurrentPlayer}");
      }
    }

    private static void PrintCapturedPieces(Chess.ChessMatch match)
    {
      Console.WriteLine("Peças capturadas:");
      Console.Write("Brancas: ");
      PrintPiecesSet(match.GetCapturedPieces(Color.White));
      Console.WriteLine();
      Console.Write("Pretas: ");
      PrintPiecesSet(match.GetCapturedPieces(Color.Black));
      Console.WriteLine();
    }

    private static void PrintPiecesSet(HashSet<Piece> pieces)
    {
      Console.Write("[");
      foreach (Piece piece in pieces)
      {
        if (piece.Color == Color.White)
        {
          Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
          Console.ForegroundColor = ConsoleColor.Yellow;
        }
        Console.Write(piece + " ");
        Console.ResetColor();
      }
      Console.Write("]");
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