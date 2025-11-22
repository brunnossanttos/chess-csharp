using ChessBoard;

namespace Chess
{
  public class Queen : Piece
  {
    public Queen(Color color, Board board) : base(color, board)
    {
      
    }

    public override string ToString()
    {
      return "Q";
    }

    public override bool[,] PossibleMoves()
    {
      bool[,] mat = new bool[ChessBoard!.Lines, ChessBoard.Columns];

      Position pos = new Position(0, 0);

      pos.SetValues(Position!.Line - 1, Position.Column);
      while (ChessBoard.IsValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Line, pos.Column] = true;
        if (ChessBoard.GetPiece(pos) != null && ChessBoard.GetPiece(pos)!.Color != Color)
        {
          break;
        }
        pos.Line--;
      }

      pos.SetValues(Position.Line + 1, Position.Column);
      while (ChessBoard.IsValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Line, pos.Column] = true;
        if (ChessBoard.GetPiece(pos) != null && ChessBoard.GetPiece(pos)!.Color != Color)
        {
          break;
        }
        pos.Line++;
      }

      pos.SetValues(Position.Line, Position.Column + 1);
      while (ChessBoard.IsValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Line, pos.Column] = true;
        if (ChessBoard.GetPiece(pos) != null && ChessBoard.GetPiece(pos)!.Color != Color)
        {
          break;
        }
        pos.Column++;
      }

      pos.SetValues(Position.Line, Position.Column - 1);
      while (ChessBoard.IsValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Line, pos.Column] = true;
        if (ChessBoard.GetPiece(pos) != null && ChessBoard.GetPiece(pos)!.Color != Color)
        {
          break;
        }
        pos.Column--;
      }

      pos.SetValues(Position.Line - 1, Position.Column - 1);
      while (ChessBoard.IsValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Line, pos.Column] = true;
        if (ChessBoard.GetPiece(pos) != null && ChessBoard.GetPiece(pos)!.Color != Color)
        {
          break;
        }
        pos.SetValues(pos.Line - 1, pos.Column - 1);
      }

      pos.SetValues(Position.Line - 1, Position.Column + 1);
      while (ChessBoard.IsValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Line, pos.Column] = true;
        if (ChessBoard.GetPiece(pos) != null && ChessBoard.GetPiece(pos)!.Color != Color)
        {
          break;
        }
        pos.SetValues(pos.Line - 1, pos.Column + 1);
      }

      pos.SetValues(Position.Line + 1, Position.Column + 1);
      while (ChessBoard.IsValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Line, pos.Column] = true;
        if (ChessBoard.GetPiece(pos) != null && ChessBoard.GetPiece(pos)!.Color != Color)
        {
          break;
        }
        pos.SetValues(pos.Line + 1, pos.Column + 1);
      }

      pos.SetValues(Position.Line + 1, Position.Column - 1);
      while (ChessBoard.IsValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Line, pos.Column] = true;
        if (ChessBoard.GetPiece(pos) != null && ChessBoard.GetPiece(pos)!.Color != Color)
        {
          break;
        }
        pos.SetValues(pos.Line + 1, pos.Column - 1);
      }

      return mat;
    }
  }
}