namespace ChessBoard
{
  public class Board
  {
    public int Lines { get; set; }
    public int Columns { get; set; }
    private Piece[,] pieces;

    public Board(int lines, int columns)
    {
      Lines = lines;
      Columns = columns;
      pieces = new Piece[lines, columns];
    }

    public Piece? GetPiece(int line, int column)
    {
      return pieces[line, column];
    }

    public Piece? GetPiece(Position position)
    {
      return pieces[position.Line, position.Column];
    }

    public bool IsValidPosition(Position position)
    {
      if (position.Line < 0 || position.Line >= Lines || position.Column < 0 || position.Column >= Columns)
      {
        return false;
      }
      return true;
    }

    public void PlacePiece(Piece piece, Position position)
    {
      if (pieces[position.Line, position.Column] != null)
      {
        throw new Exception("Já existe uma peça nessa posição!");
      }
      pieces[position.Line, position.Column] = piece;
      piece.Position = position;
    }

    public Piece? RemovePiece(Position position)
    {
      if (GetPiece(position) == null)
      {
        return null;
      }
      Piece temp = GetPiece(position)!;
      temp.Position = null;
      pieces[position.Line, position.Column] = null!;
      return temp;
    }
  }
}
