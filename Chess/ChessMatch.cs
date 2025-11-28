using ChessBoard;

namespace Chess
{
  public class ChessMatch
  {
    public Board Board { get; private set; }
    public int Turn { get; private set; }
    public Color CurrentPlayer { get; private set; }
    public bool Finished { get; set; }

    public ChessMatch()
    {
      Board = new Board(8, 8);
      Turn = 1;
      CurrentPlayer = Color.White;
      Finished = false;
      PlaceInitialPieces();
    }

    private void PlaceInitialPieces()
    {
      Board.PlacePiece(new Rook(Color.White, Board), new Position(7, 0));
      Board.PlacePiece(new Knight(Color.White, Board), new Position(7, 1));
      Board.PlacePiece(new Bishop(Color.White, Board), new Position(7, 2));
      Board.PlacePiece(new Queen(Color.White, Board), new Position(7, 3));
      Board.PlacePiece(new King(Color.White, Board), new Position(7, 4));
      Board.PlacePiece(new Bishop(Color.White, Board), new Position(7, 5));
      Board.PlacePiece(new Knight(Color.White, Board), new Position(7, 6));
      Board.PlacePiece(new Rook(Color.White, Board), new Position(7, 7));
      
      for (int i = 0; i < 8; i++)
      {
        Board.PlacePiece(new Pawn(Color.White, Board), new Position(6, i));
      }

      Board.PlacePiece(new Rook(Color.Black, Board), new Position(0, 0));
      Board.PlacePiece(new Knight(Color.Black, Board), new Position(0, 1));
      Board.PlacePiece(new Bishop(Color.Black, Board), new Position(0, 2));
      Board.PlacePiece(new Queen(Color.Black, Board), new Position(0, 3));
      Board.PlacePiece(new King(Color.Black, Board), new Position(0, 4));
      Board.PlacePiece(new Bishop(Color.Black, Board), new Position(0, 5));
      Board.PlacePiece(new Knight(Color.Black, Board), new Position(0, 6));
      Board.PlacePiece(new Rook(Color.Black, Board), new Position(0, 7));
      
      for (int i = 0; i < 8; i++)
      {
        Board.PlacePiece(new Pawn(Color.Black, Board), new Position(1, i));
      }
    }
  }
}
