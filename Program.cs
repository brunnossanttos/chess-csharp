using ChessBoard;
using Chess;

try
{
  Console.WriteLine("Welcome to Chess Game!");
  Console.WriteLine();

  ChessMatch match = new ChessMatch();

  Console.WriteLine("Tabuleiro inicial:");
  Screen.PrintBoard(match.Board);
  Console.WriteLine();

  Console.WriteLine("Teste: Movendo peão branco de (6,4) para (4,4)");
  Position origin = new Position(6, 4);
  Position destination = new Position(4, 4);

  match.ValidateOriginPosition(origin);
  match.ExecuteMove(origin, destination);

  Console.WriteLine();
  Console.WriteLine("Tabuleiro após movimento:");
  Screen.PrintBoard(match.Board);
}
catch (ChessBoardException ex)
{
  Console.WriteLine($"Erro: {ex.Message}");
}