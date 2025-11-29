namespace ChessBoard
{
  public class Screen
  {
    private static void PrintHeader()
    {
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine("╭──────────────────────────────────────╮");
      Console.WriteLine("│      ♟  JOGO DE XADREZ C#  ♟      │");
      Console.WriteLine("╰──────────────────────────────────────╯");
      Console.ResetColor();
      Console.WriteLine();
    }
    public static void PrintBoard(Board board, Color currentPlayer)
    {
      if (currentPlayer == Color.White)
      {
        for (int i = 0; i < board.Lines; i++)
        {
          Console.ForegroundColor = ConsoleColor.Cyan;
          Console.Write(8 - i + " ");
          Console.ResetColor();
          for (int j = 0; j < board.Columns; j++)
          {
            Piece? piece = board.GetPiece(i, j);
            PrintPieceColor(piece, false, i, j);
          }
          Console.WriteLine();
        }
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("  a b c d e f g h");
        Console.ResetColor();
      }
      else
      {
        for (int i = board.Lines - 1; i >= 0; i--)
        {
          Console.ForegroundColor = ConsoleColor.Cyan;
          Console.Write(8 - i + " ");
          Console.ResetColor();
          for (int j = board.Columns - 1; j >= 0; j--)
          {
            Piece? piece = board.GetPiece(i, j);
            PrintPieceColor(piece, false, i, j);
          }
          Console.WriteLine();
        }
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("  h g f e d c b a");
        Console.ResetColor();
      }
    }

    public static void PrintBoard(Board board, bool[,] possiblePositions, Color currentPlayer)
    {
      if (currentPlayer == Color.White)
      {
        for (int i = 0; i < board.Lines; i++)
        {
          Console.ForegroundColor = ConsoleColor.Cyan;
          Console.Write(8 - i + " ");
          Console.ResetColor();
          for (int j = 0; j < board.Columns; j++)
          {
            Piece? piece = board.GetPiece(i, j);
            PrintPieceColor(piece, possiblePositions[i, j], i, j);
          }
          Console.WriteLine();
        }
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("  a b c d e f g h");
        Console.ResetColor();
      }
      else
      {
        for (int i = board.Lines - 1; i >= 0; i--)
        {
          Console.ForegroundColor = ConsoleColor.Cyan;
          Console.Write(8 - i + " ");
          Console.ResetColor();
          for (int j = board.Columns - 1; j >= 0; j--)
          {
            Piece? piece = board.GetPiece(i, j);
            PrintPieceColor(piece, possiblePositions[i, j], i, j);
          }
          Console.WriteLine();
        }
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("  h g f e d c b a");
        Console.ResetColor();
      }
    }

    private static void PrintPieceColor(Piece? piece, bool highlight, int line, int column)
    {
      // Definir cor de fundo baseada na posição (tabuleiro xadrez)
      bool isLightSquare = (line + column) % 2 == 0;
      
      if (highlight)
      {
        Console.BackgroundColor = ConsoleColor.DarkGreen;
      }
      else if (isLightSquare)
      {
        Console.BackgroundColor = ConsoleColor.DarkGray;
      }
      else
      {
        Console.BackgroundColor = ConsoleColor.Black;
      }

      if (piece == null)
      {
        Console.Write("  ");
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
      }
      
      Console.ResetColor();
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
      PrintHeader();
      PrintBoard(match.Board, match.CurrentPlayer);
      Console.WriteLine();
      Console.ForegroundColor = ConsoleColor.DarkCyan;
      Console.WriteLine("──────────────────────────────────────");
      Console.ResetColor();
      PrintCapturedPieces(match);
      Console.ForegroundColor = ConsoleColor.DarkCyan;
      Console.WriteLine("──────────────────────────────────────");
      Console.ResetColor();
      Console.ForegroundColor = ConsoleColor.Magenta;
      Console.Write("► Turno: ");
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine(match.Turn);
      Console.ResetColor();
      
      if (!match.Finished)
      {
        if (match.Check)
        {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine("⚠  XEQUE!  ⚠");
          Console.ResetColor();
        }
        
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("► Aguardando jogada: ");
        if (match.CurrentPlayer == Color.White)
        {
          Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
          Console.ForegroundColor = ConsoleColor.Yellow;
        }
        Console.WriteLine(match.CurrentPlayer);
        Console.ResetColor();
      }
    }

    private static void PrintCapturedPieces(Chess.ChessMatch match)
    {
      var whiteCaptured = match.GetCapturedPieces(Color.White);
      var blackCaptured = match.GetCapturedPieces(Color.Black);
      
      Console.ForegroundColor = ConsoleColor.Gray;
      Console.WriteLine("⚔  Peças Capturadas:");
      Console.ResetColor();
      
      Console.ForegroundColor = ConsoleColor.White;
      Console.Write("  Brancas ({0}): ", whiteCaptured.Count);
      Console.ResetColor();
      PrintPiecesSet(whiteCaptured);
      Console.WriteLine();
      
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.Write("  Pretas ({0}):  ", blackCaptured.Count);
      Console.ResetColor();
      PrintPiecesSet(blackCaptured);
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