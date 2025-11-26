using ChessBoard;

namespace Chess
{
  public class Pawn : Piece
  {
    public Pawn(Color color, Board board) : base(color, board)
    {
    }

    public override string ToString()
    {
      return "P";
    }

    private bool ExistsEnemy(Position pos)
    {
      Piece? p = ChessBoard!.GetPiece(pos);
      return p != null && p.Color != Color;
    }

    private bool IsFree(Position pos)
    {
      return ChessBoard!.GetPiece(pos) == null;
    }

    public override bool[,] PossibleMoves()
    {
      bool[,] mat = new bool[ChessBoard!.Lines, ChessBoard.Columns];

    Position pos = new Position(0, 0);

    if (Color == Color.White)
    {

      pos.SetValues(Position!.Line - 1, Position.Column);
      if (ChessBoard.IsValidPosition(pos) && IsFree(pos))
      {
        mat[pos.Line, pos.Column] = true;
      }

      pos.SetValues(Position.Line - 2, Position.Column);
      Position pos2 = new Position(Position.Line - 1, Position.Column);
      if (ChessBoard.IsValidPosition(pos2) && IsFree(pos2) &&
          ChessBoard.IsValidPosition(pos) && IsFree(pos) && MoveCount == 0)
      {
        mat[pos.Line, pos.Column] = true;
      }

      pos.SetValues(Position.Line - 1, Position.Column - 1);
      if (ChessBoard.IsValidPosition(pos) && ExistsEnemy(pos))
      {
        mat[pos.Line, pos.Column] = true;
      }

      pos.SetValues(Position.Line - 1, Position.Column + 1);
      if (ChessBoard.IsValidPosition(pos) && ExistsEnemy(pos))
      {
        mat[pos.Line, pos.Column] = true;
      }
    }
    else
    {

      pos.SetValues(Position!.Line + 1, Position.Column);
      if (ChessBoard.IsValidPosition(pos) && IsFree(pos))
      {
        mat[pos.Line, pos.Column] = true;
      }

      pos.SetValues(Position.Line + 2, Position.Column);
      Position pos2 = new Position(Position.Line + 1, Position.Column);
      if (ChessBoard.IsValidPosition(pos2) && IsFree(pos2) &&
          ChessBoard.IsValidPosition(pos) && IsFree(pos) && MoveCount == 0)
      {
        mat[pos.Line, pos.Column] = true;
      }

      pos.SetValues(Position.Line + 1, Position.Column - 1);
      if (ChessBoard.IsValidPosition(pos) && ExistsEnemy(pos))
      {
        mat[pos.Line, pos.Column] = true;
      }

      pos.SetValues(Position.Line + 1, Position.Column + 1);
      if (ChessBoard.IsValidPosition(pos) && ExistsEnemy(pos))
      {
        mat[pos.Line, pos.Column] = true;
      }
    }

    return mat;
  }
  }
}
