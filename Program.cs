namespace ConnectFourGame {
  class Program {
    static void Main(string[] args) {
      // quick introduction...
      Console.WriteLine("\nWelcome to Connect4!");
      Console.WriteLine("\nPress any key to start a new game.");
      Console.ReadKey();
      // creating a new game...
      Game.CreateNewGame();
    }
  }
}
