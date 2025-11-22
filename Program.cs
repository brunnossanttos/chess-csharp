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


Screen.PrintBoard(board);