using ChessBoard;

namespace Chess
{
  public class Knight : Piece
  {
    public Knight(Color color, Board board) : base(color, board)
    {}

    public override string ToString()
    {
      return "N";
    }

    public override bool[,] PossibleMoves()
    {
      bool[,] mat = new bool[ChessBoard!.Lines, ChessBoard.Columns];

      Position pos = new Position(0, 0);

      pos.SetValues(Position!.Line - 2, Position.Column - 1);
      if (ChessBoard.IsValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Line, pos.Column] = true;
      }

      pos.SetValues(Position.Line - 2, Position.Column + 1);
      if (ChessBoard.IsValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Line, pos.Column] = true;
      }

      pos.SetValues(Position.Line - 1, Position.Column + 2);
      if (ChessBoard.IsValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Line, pos.Column] = true;
      }

      pos.SetValues(Position.Line + 1, Position.Column + 2);
      if (ChessBoard.IsValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Line, pos.Column] = true;
      }

      pos.SetValues(Position.Line + 2, Position.Column + 1);
      if (ChessBoard.IsValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Line, pos.Column] = true;
      }

      pos.SetValues(Position.Line + 2, Position.Column - 1);
      if (ChessBoard.IsValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Line, pos.Column] = true;
      }

      pos.SetValues(Position.Line + 1, Position.Column - 2);
      if (ChessBoard.IsValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Line, pos.Column] = true;
      }

      pos.SetValues(Position.Line - 1, Position.Column - 2);
      if (ChessBoard.IsValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Line, pos.Column] = true;
      }

      return mat;
    }
  }
}