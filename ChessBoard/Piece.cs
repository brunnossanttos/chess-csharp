namespace ChessBoard
{
  public abstract class Piece
  {
    public Position? Position{ get; set; }
    public Color Color { get; protected set; }
    public int MoveCount { get; protected set; }
    public Board? ChessBoard { get; protected set; }

    public Piece(Color color, Board chessBoard)
    {
      Position = null;
      Color = color;
      ChessBoard = chessBoard;
      MoveCount = 0;
    }

    public void IncreaseMoveCount()
    {
      MoveCount++;
    }

    public void DecreaseMoveCount()
    {
      MoveCount--;
    }

    public abstract bool[,] PossibleMoves();

    public bool CanMoveTo(Position position)
    {
      return PossibleMoves()[position.Line, position.Column];
    }

    protected bool CanMove(Position position)
    {
      Piece? p = ChessBoard!.GetPiece(position);
      return p == null || p.Color != Color;
    }

    public bool HasAnyPossibleMove()
    {
      bool[,] possibleMoves = PossibleMoves();
      for (int i = 0; i < ChessBoard!.Lines; i++)
      {
        for (int j = 0; j < ChessBoard.Columns; j++)
        {
          if (possibleMoves[i, j])
          {
            return true;
          }
        }
      }
      return false;
    }
  }
}