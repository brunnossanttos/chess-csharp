using ChessBoard;
using Chess;

try
{
  ChessMatch match = new ChessMatch();

  while (!match.Finished)
  {
    try
    {
      Console.Clear();
      Screen.PrintMatch(match);

      Console.WriteLine();
      Console.Write("Origem: ");
      Position origin = Screen.ReadPosition();

      Console.Write("Destino: ");
      Position destination = Screen.ReadPosition();

      match.MakeMove(origin, destination);
    }
    catch (ChessBoardException ex)
    {
      Console.WriteLine($"Erro: {ex.Message}");
      Console.WriteLine("Pressione ENTER para continuar...");
      Console.ReadLine();
    }
  }
}
catch (Exception ex)
{
  Console.WriteLine($"Erro inesperado: {ex.Message}");
}