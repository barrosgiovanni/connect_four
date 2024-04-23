namespace ConnectFourGame {
  class Program {
    static void Main(string[] args) {
      // quick introduction...
      Console.WriteLine("\nWelcome to Connect4!");
      Console.WriteLine("\nPress any key to start a new game.");
      Console.ReadKey();

      // asking users for their names and symbols...
      Console.WriteLine("\nWhat is Player#1 name?");
      string firstPlayerName = Console.ReadLine();
      Console.WriteLine("\nPlease, choose a symbol to fill out the spaces in the board for Player#1: ");
      string firstPlayerSymbol = Console.ReadLine();
      Console.WriteLine("\nWhat is Player#2 name?");
      string secondPlayerName = Console.ReadLine();
      Console.WriteLine("\nPlease, choose a symbol to fill out the spaces in the board for Player#2: ");
      string secondPlayerSymbol = Console.ReadLine();

      // creating a new game and providing the user's names and symbols...
      Game newGame = new Game(firstPlayerSymbol, firstPlayerName, secondPlayerSymbol, secondPlayerName);
      newGame.StartTheGame();
      // newBoard.displayGameboard();
      // newBoard.playerMove("7", "X");
      // newBoard.playerMove("7", "O");
      // newBoard.playerMove("5", "X");
      // newBoard.playerMove("2", "O");
      // newBoard.playerMove("3", "X");
      // newBoard.playerMove("5", "0");
      // newBoard.playerMove("2", "X");
      // newBoard.playerMove("3", "0");
      // newBoard.playerMove("7", "X");
      // newBoard.playerMove("1", "0");
      // newBoard.playerMove("1", "X");
      // newBoard.playerMove("2", "0");
      // newBoard.playerMove("2", "X");
      // newBoard.displayGameboard();
    }
  }
}
