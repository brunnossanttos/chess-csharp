// See https://aka.ms/new-console-template for more information
using ChessBoard;

Console.WriteLine("Hello, Chess player!");

Board board = new Board(8, 8);

board.PlacePiece(new Chess.Rook(Color.Black, board), new Position(0, 0));
board.PlacePiece(new Chess.Rook(Color.Black, board), new Position(0, 7));
board.PlacePiece(new Chess.Rook(Color.White, board), new Position(7, 0));
board.PlacePiece(new Chess.Rook(Color.White, board), new Position(7, 7));

board.PlacePiece(new Chess.Bishop(Color.Black, board), new Position(0, 2));
board.PlacePiece(new Chess.Bishop(Color.Black, board), new Position(0, 5));
board.PlacePiece(new Chess.Bishop(Color.White, board), new Position(7, 2));
board.PlacePiece(new Chess.Bishop(Color.White, board), new Position(7, 5));

board.PlacePiece(new Chess.Queen(Color.Black, board), new Position(0, 3));
board.PlacePiece(new Chess.Queen(Color.White, board), new Position(7, 3));

board.PlacePiece(new Chess.King(Color.Black, board), new Position(0, 4));
board.PlacePiece(new Chess.King(Color.White, board), new Position(7, 4));

board.PlacePiece(new Chess.Knight(Color.Black, board), new Position(0, 1));
board.PlacePiece(new Chess.Knight(Color.Black, board), new Position(0, 6));
board.PlacePiece(new Chess.Knight(Color.White, board), new Position(7, 1));
board.PlacePiece(new Chess.Knight(Color.White, board), new Position(7, 6));

for (int i = 0; i < 8; i++)
{
  board.PlacePiece(new Chess.Pawn(Color.Black, board), new Position(1, i));
}


for (int i = 0; i < 8; i++)
{
  board.PlacePiece(new Chess.Pawn(Color.White, board), new Position(6, i));
}

Screen.PrintBoard(board);