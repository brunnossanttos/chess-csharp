using ChessBoard;

namespace Chess
{
  public class ChessMatch
  {
    public Board Board { get; private set; }
    public int Turn { get; private set; }
    public Color CurrentPlayer { get; private set; }
    public bool Finished { get; set; }
    private HashSet<Piece> Pieces { get; set; }
    private HashSet<Piece> CapturedPieces { get; set; }

    public ChessMatch()
    {
      Board = new Board(8, 8);
      Turn = 1;
      CurrentPlayer = Color.White;
      Finished = false;
      Pieces = new HashSet<Piece>();
      CapturedPieces = new HashSet<Piece>();
      PlaceInitialPieces();
    }

    public void ExecuteMove(Position origin, Position destination)
    {
      Piece? piece = Board.RemovePiece(origin);
      piece!.IncreaseMoveCount();
      Piece? capturedPiece = Board.RemovePiece(destination);
      
      if (capturedPiece != null)
      {
        CapturedPieces.Add(capturedPiece);
      }
      
      Board.PlacePiece(piece, destination);
    }

    public void MakeMove(Position origin, Position destination)
    {
      ValidateOriginPosition(origin);
      ValidateDestinationPosition(origin, destination);
      ExecuteMove(origin, destination);
      Turn++;
      ChangePlayer();
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
      PlaceNewPiece('e', 1, new King(Color.White, Board));
      PlaceNewPiece('f', 1, new Bishop(Color.White, Board));
      PlaceNewPiece('g', 1, new Knight(Color.White, Board));
      PlaceNewPiece('h', 1, new Rook(Color.White, Board));
      PlaceNewPiece('a', 2, new Pawn(Color.White, Board));
      PlaceNewPiece('b', 2, new Pawn(Color.White, Board));
      PlaceNewPiece('c', 2, new Pawn(Color.White, Board));
      PlaceNewPiece('d', 2, new Pawn(Color.White, Board));
      PlaceNewPiece('e', 2, new Pawn(Color.White, Board));
      PlaceNewPiece('f', 2, new Pawn(Color.White, Board));
      PlaceNewPiece('g', 2, new Pawn(Color.White, Board));
      PlaceNewPiece('h', 2, new Pawn(Color.White, Board));

      PlaceNewPiece('a', 8, new Rook(Color.Black, Board));
      PlaceNewPiece('b', 8, new Knight(Color.Black, Board));
      PlaceNewPiece('c', 8, new Bishop(Color.Black, Board));
      PlaceNewPiece('d', 8, new Queen(Color.Black, Board));
      PlaceNewPiece('e', 8, new King(Color.Black, Board));
      PlaceNewPiece('f', 8, new Bishop(Color.Black, Board));
      PlaceNewPiece('g', 8, new Knight(Color.Black, Board));
      PlaceNewPiece('h', 8, new Rook(Color.Black, Board));
      PlaceNewPiece('a', 7, new Pawn(Color.Black, Board));
      PlaceNewPiece('b', 7, new Pawn(Color.Black, Board));
      PlaceNewPiece('c', 7, new Pawn(Color.Black, Board));
      PlaceNewPiece('d', 7, new Pawn(Color.Black, Board));
      PlaceNewPiece('e', 7, new Pawn(Color.Black, Board));
      PlaceNewPiece('f', 7, new Pawn(Color.Black, Board));
      PlaceNewPiece('g', 7, new Pawn(Color.Black, Board));
      PlaceNewPiece('h', 7, new Pawn(Color.Black, Board));
    }
  }
}
