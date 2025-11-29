using ChessBoard;

namespace Chess
{
  public class ChessMatch
  {
    public Board Board { get; private set; }
    public int Turn { get; private set; }
    public Color CurrentPlayer { get; private set; }
    public bool Finished { get; set; }
    public bool Check { get; private set; }
    public Piece? EnPassantVulnerable { get; private set; }
    private HashSet<Piece> Pieces { get; set; }
    private HashSet<Piece> CapturedPieces { get; set; }

    public ChessMatch()
    {
      Board = new Board(8, 8);
      Turn = 1;
      CurrentPlayer = Color.White;
      Finished = false;
      Check = false;
      EnPassantVulnerable = null;
      Pieces = new HashSet<Piece>();
      CapturedPieces = new HashSet<Piece>();
      PlaceInitialPieces();
    }

    public Piece ExecuteMove(Position origin, Position destination)
    {
      Piece? piece = Board.RemovePiece(origin);
      piece!.IncreaseMoveCount();
      Piece? capturedPiece = Board.RemovePiece(destination);
      
      Board.PlacePiece(piece, destination);
      
      if (piece is King && destination.Column == origin.Column + 2)
      {
        Position rookOrigin = new Position(origin.Line, origin.Column + 3);
        Position rookDestination = new Position(origin.Line, origin.Column + 1);
        Piece rook = Board.RemovePiece(rookOrigin)!;
        rook.IncreaseMoveCount();
        Board.PlacePiece(rook, rookDestination);
      }
      
      if (piece is King && destination.Column == origin.Column - 2)
      {
        Position rookOrigin = new Position(origin.Line, origin.Column - 4);
        Position rookDestination = new Position(origin.Line, origin.Column - 1);
        Piece rook = Board.RemovePiece(rookOrigin)!;
        rook.IncreaseMoveCount();
        Board.PlacePiece(rook, rookDestination);
      }
      
      if (piece is Pawn)
      {
        if (origin.Column != destination.Column && capturedPiece == null)
        {
          Position pawnPosition;
          if (piece.Color == Color.White)
          {
            pawnPosition = new Position(destination.Line + 1, destination.Column);
          }
          else
          {
            pawnPosition = new Position(destination.Line - 1, destination.Column);
          }
          capturedPiece = Board.RemovePiece(pawnPosition);
        }
      }
      
      return capturedPiece!;
    }

    public void MakeMove(Position origin, Position destination)
    {
      ValidateOriginPosition(origin);
      ValidateDestinationPosition(origin, destination);
      Piece capturedPiece = ExecuteMove(origin, destination);
      
      if (IsInCheck(CurrentPlayer))
      {
        UndoMove(origin, destination, capturedPiece);
        throw new ChessBoardException("Você não pode se colocar em xeque!");
      }
      
      Piece movedPiece = Board.GetPiece(destination)!;
      
      if (movedPiece is Pawn)
      {
        if ((movedPiece.Color == Color.White && destination.Line == 0) ||
            (movedPiece.Color == Color.Black && destination.Line == 7))
        {
          movedPiece = Board.RemovePiece(destination)!;
          Pieces.Remove(movedPiece);
          Piece queen = new Queen(movedPiece.Color, Board);
          Board.PlacePiece(queen, destination);
          Pieces.Add(queen);
        }
      }
      
      if (capturedPiece != null)
      {
        CapturedPieces.Add(capturedPiece);
      }
      
      if (IsInCheck(Opponent(CurrentPlayer)))
      {
        Check = true;
      }
      else
      {
        Check = false;
      }
      
      if (movedPiece is Pawn && (destination.Line == origin.Line - 2 || destination.Line == origin.Line + 2))
      {
        EnPassantVulnerable = movedPiece;
      }
      else
      {
        EnPassantVulnerable = null;
      }
      
      if (TestCheckmate(Opponent(CurrentPlayer)))
      {
        Finished = true;
      }
      else
      {
        Turn++;
        ChangePlayer();
      }
    }

    public void ValidateOriginPosition(Position position)
    {
      if (Board.GetPiece(position) == null)
      {
        throw new ChessBoardException("Não existe peça na posição de origem escolhida!");
      }
      if (CurrentPlayer != Board.GetPiece(position)!.Color)
      {
        throw new ChessBoardException("A peça de origem escolhida não é sua!");
      }
      if (!Board.GetPiece(position)!.HasAnyPossibleMove())
      {
        throw new ChessBoardException("Não há movimentos possíveis para a peça de origem escolhida!");
      }
    }

    public void ValidateDestinationPosition(Position origin, Position destination)
    {
      if (!Board.GetPiece(origin)!.CanMoveTo(destination))
      {
        throw new ChessBoardException("Posição de destino inválida!");
      }
    }

    public HashSet<Piece> GetCapturedPieces(Color color)
    {
      HashSet<Piece> captured = new HashSet<Piece>();
      foreach (Piece piece in CapturedPieces)
      {
        if (piece.Color == color)
        {
          captured.Add(piece);
        }
      }
      return captured;
    }

    public HashSet<Piece> GetPiecesInGame(Color color)
    {
      HashSet<Piece> inGame = new HashSet<Piece>();
      foreach (Piece piece in Pieces)
      {
        if (piece.Color == color && !CapturedPieces.Contains(piece))
        {
          inGame.Add(piece);
        }
      }
      return inGame;
    }

    private Color Opponent(Color color)
    {
      if (color == Color.White)
      {
        return Color.Black;
      }
      else
      {
        return Color.White;
      }
    }

    private Piece? GetKing(Color color)
    {
      foreach (Piece piece in GetPiecesInGame(color))
      {
        if (piece is King)
        {
          return piece;
        }
      }
      return null;
    }

    public bool IsInCheck(Color color)
    {
      Piece? king = GetKing(color);
      if (king == null)
      {
        throw new ChessBoardException($"Não existe rei da cor {color} no tabuleiro!");
      }

      foreach (Piece piece in GetPiecesInGame(Opponent(color)))
      {
        bool[,] possibleMoves = piece.PossibleMoves();
        if (king.Position != null && possibleMoves[king.Position.Line, king.Position.Column])
        {
          return true;
        }
      }
      return false;
    }

    public bool TestCheckmate(Color color)
    {
      if (!IsInCheck(color))
      {
        return false;
      }

      foreach (Piece piece in GetPiecesInGame(color))
      {
        bool[,] possibleMoves = piece.PossibleMoves();
        for (int i = 0; i < Board.Lines; i++)
        {
          for (int j = 0; j < Board.Columns; j++)
          {
            if (possibleMoves[i, j])
            {
              if (piece.Position == null) continue;
              
              Position origin = piece.Position;
              Position destination = new Position(i, j);
              Piece capturedPiece = ExecuteMove(origin, destination);
              bool testCheck = IsInCheck(color);
              UndoMove(origin, destination, capturedPiece);
              
              if (!testCheck)
              {
                return false;
              }
            }
          }
        }
      }
      return true;
    }

    private void UndoMove(Position origin, Position destination, Piece capturedPiece)
    {
      Piece piece = Board.RemovePiece(destination)!;
      piece.DecreaseMoveCount();
      
      if (capturedPiece != null)
      {
        Board.PlacePiece(capturedPiece, destination);
        CapturedPieces.Remove(capturedPiece);
      }
      
      Board.PlacePiece(piece, origin);
      
      if (piece is King && destination.Column == origin.Column + 2)
      {
        Position rookOrigin = new Position(origin.Line, origin.Column + 3);
        Position rookDestination = new Position(origin.Line, origin.Column + 1);
        Piece rook = Board.RemovePiece(rookDestination)!;
        rook.DecreaseMoveCount();
        Board.PlacePiece(rook, rookOrigin);
      }
      
      if (piece is King && destination.Column == origin.Column - 2)
      {
        Position rookOrigin = new Position(origin.Line, origin.Column - 4);
        Position rookDestination = new Position(origin.Line, origin.Column - 1);
        Piece rook = Board.RemovePiece(rookDestination)!;
        rook.DecreaseMoveCount();
        Board.PlacePiece(rook, rookOrigin);
      }
      
      if (piece is Pawn)
      {
        if (origin.Column != destination.Column && capturedPiece == EnPassantVulnerable)
        {
          Piece pawn = Board.RemovePiece(destination)!;
          Position pawnPosition;
          if (piece.Color == Color.White)
          {
            pawnPosition = new Position(3, destination.Column);
          }
          else
          {
            pawnPosition = new Position(4, destination.Column);
          }
          Board.PlacePiece(pawn, destination);
          if (capturedPiece != null)
          {
            Board.PlacePiece(capturedPiece, pawnPosition);
          }
        }
      }
    }

    private void PlaceNewPiece(char column, int line, Piece piece)
    {
      Board.PlacePiece(piece, new Position(8 - line, column - 'a'));
      Pieces.Add(piece);
    }

    private void ChangePlayer()
    {
      if (CurrentPlayer == Color.White)
      {
        CurrentPlayer = Color.Black;
      }
      else
      {
        CurrentPlayer = Color.White;
      }
    }

    private void PlaceInitialPieces()
    {
      PlaceNewPiece('a', 1, new Rook(Color.White, Board));
      PlaceNewPiece('b', 1, new Knight(Color.White, Board));
      PlaceNewPiece('c', 1, new Bishop(Color.White, Board));
      PlaceNewPiece('d', 1, new Queen(Color.White, Board));
      PlaceNewPiece('e', 1, new King(Color.White, Board, this));
      PlaceNewPiece('f', 1, new Bishop(Color.White, Board));
      PlaceNewPiece('g', 1, new Knight(Color.White, Board));
      PlaceNewPiece('h', 1, new Rook(Color.White, Board));
      PlaceNewPiece('a', 2, new Pawn(Color.White, Board, this));
      PlaceNewPiece('b', 2, new Pawn(Color.White, Board, this));
      PlaceNewPiece('c', 2, new Pawn(Color.White, Board, this));
      PlaceNewPiece('d', 2, new Pawn(Color.White, Board, this));
      PlaceNewPiece('e', 2, new Pawn(Color.White, Board, this));
      PlaceNewPiece('f', 2, new Pawn(Color.White, Board, this));
      PlaceNewPiece('g', 2, new Pawn(Color.White, Board, this));
      PlaceNewPiece('h', 2, new Pawn(Color.White, Board, this));

      PlaceNewPiece('a', 8, new Rook(Color.Black, Board));
      PlaceNewPiece('b', 8, new Knight(Color.Black, Board));
      PlaceNewPiece('c', 8, new Bishop(Color.Black, Board));
      PlaceNewPiece('d', 8, new Queen(Color.Black, Board));
      PlaceNewPiece('e', 8, new King(Color.Black, Board, this));
      PlaceNewPiece('f', 8, new Bishop(Color.Black, Board));
      PlaceNewPiece('g', 8, new Knight(Color.Black, Board));
      PlaceNewPiece('h', 8, new Rook(Color.Black, Board));
      PlaceNewPiece('a', 7, new Pawn(Color.Black, Board, this));
      PlaceNewPiece('b', 7, new Pawn(Color.Black, Board, this));
      PlaceNewPiece('c', 7, new Pawn(Color.Black, Board, this));
      PlaceNewPiece('d', 7, new Pawn(Color.Black, Board, this));
      PlaceNewPiece('e', 7, new Pawn(Color.Black, Board, this));
      PlaceNewPiece('f', 7, new Pawn(Color.Black, Board, this));
      PlaceNewPiece('g', 7, new Pawn(Color.Black, Board, this));
      PlaceNewPiece('h', 7, new Pawn(Color.Black, Board, this));
    }
  }
}
