// See https://aka.ms/new-console-template for more information
using ChessBoard;

Console.WriteLine("Hello, Chess player!");

Board board = new Board(8, 8);

board.PlacePiece(new Chess.Rook(Color.White, board), new Position(0, 0));
board.PlacePiece(new Chess.Rook(Color.White, board), new Position(3, 0));
board.PlacePiece(new Chess.Rook(Color.Black, board), new Position(1, 0));
board.PlacePiece(new Chess.Rook(Color.Black, board), new Position(0, 3));

board.PlacePiece(new Chess.King(Color.Black, board), new Position(2, 4));
board.PlacePiece(new Chess.King(Color.White, board), new Position(5, 4));
