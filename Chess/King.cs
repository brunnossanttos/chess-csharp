using ChessBoard;

namespace Chess
{
  public class King : Piece
  {
    private ChessMatch? Match { get; set; }

    public King(Color color, Board board) : base(color, board)
    {
      
    }

    public King(Color color, Board board, ChessMatch match) : base(color, board)
    {
      Match = match;
    }

    public override string ToString()
    {
      return "K";
    }

    private bool CanCastle(Position pos)
    {
      Piece? p = ChessBoard!.GetPiece(pos);
      return p != null && p is Rook && p.Color == Color && p.MoveCount == 0;
    }

    public override bool[,] PossibleMoves()
    {
      bool[,] mat = new bool[ChessBoard!.Lines, ChessBoard.Columns];

      Position pos = new Position(0, 0);

      pos.SetValues(Position!.Line - 1, Position.Column);
      if (ChessBoard.IsValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Line, pos.Column] = true;
      }

      pos.SetValues(Position.Line + 1, Position.Column);
      if (ChessBoard.IsValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Line, pos.Column] = true;
      }

      pos.SetValues(Position.Line, Position.Column - 1);
      if (ChessBoard.IsValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Line, pos.Column] = true;
      }

      pos.SetValues(Position.Line, Position.Column + 1);
      if (ChessBoard.IsValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Line, pos.Column] = true;
      }

      pos.SetValues(Position.Line - 1, Position.Column - 1);
      if (ChessBoard.IsValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Line, pos.Column] = true;
      }

      pos.SetValues(Position.Line - 1, Position.Column + 1);
      if (ChessBoard.IsValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Line, pos.Column] = true;
      }

      pos.SetValues(Position.Line + 1, Position.Column - 1);
      if (ChessBoard.IsValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Line, pos.Column] = true;
      }

      pos.SetValues(Position.Line + 1, Position.Column + 1);
      if (ChessBoard.IsValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Line, pos.Column] = true;
      }

      if (MoveCount == 0 && Match != null && !Match.Check)
      {
        Position posRook1 = new Position(Position.Line, Position.Column + 3);
        if (CanCastle(posRook1))
        {
          Position p1 = new Position(Position.Line, Position.Column + 1);
          Position p2 = new Position(Position.Line, Position.Column + 2);
          if (ChessBoard.GetPiece(p1) == null && ChessBoard.GetPiece(p2) == null)
          {
            mat[Position.Line, Position.Column + 2] = true;
          }
        }

        Position posRook2 = new Position(Position.Line, Position.Column - 4);
        if (CanCastle(posRook2))
        {
          Position p1 = new Position(Position.Line, Position.Column - 1);
          Position p2 = new Position(Position.Line, Position.Column - 2);
          Position p3 = new Position(Position.Line, Position.Column - 3);
          if (ChessBoard.GetPiece(p1) == null && ChessBoard.GetPiece(p2) == null && ChessBoard.GetPiece(p3) == null)
          {
            mat[Position.Line, Position.Column - 2] = true;
          }
        }
      }

      return mat;
    }
  }
}