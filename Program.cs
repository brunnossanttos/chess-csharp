using ChessBoard;
using Chess;

Console.WriteLine("Welcome to Chess Game!");
Console.WriteLine();

ChessMatch match = new ChessMatch();

Console.WriteLine($"Turn: {match.Turn}");
Console.WriteLine($"Current Player: {match.CurrentPlayer}");
Console.WriteLine($"Finished: {match.Finished}");
Console.WriteLine();

Screen.PrintBoard(match.Board);