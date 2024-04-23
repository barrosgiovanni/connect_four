namespace ConnectFourGame {
  public class Game {
    private Gameboard Gameboard { get; set; } // a game is made with a gameboard...
    private string FirstPlayerSymbol { get; set; } // symbol to be chosen by player1...
    private string FirstPlayerName { get; set; }
    private string SecondPlayerSymbol { get; set; } // symbol to be chosen by player2...
    private string SecondPlayerName { get; set; }

    public Game (string firstPlayerSymbol, string firstPlayerName, string secondPlayerSymbol, string secondPlayerName) {
      // every time we create a game, we'll be creating a gameboard and defining the player's symbols and names...
      Gameboard = new Gameboard();
      FirstPlayerSymbol = firstPlayerSymbol;
      FirstPlayerName = firstPlayerName;
      SecondPlayerSymbol = secondPlayerSymbol;
      SecondPlayerName = secondPlayerName;
    }
    public void StartTheGame() {
      bool isPlayerOneTurn = true; // we'll use this boolean to change player's turn once their move is complete...
      bool isGameRunning = true; // game will be running in a loop until one of the players join 4 squares...

      string columnChosen; // column chosen by the user to put his pieces in...

      while (isGameRunning) {
        if (isPlayerOneTurn) {
          Gameboard.displayGameboard();
          Console.WriteLine($"It is your turn {FirstPlayerName}.");
          Console.WriteLine("Please, select the column you would like to drop your pieces in: ");
          columnChosen = Console.ReadLine();
          Gameboard.playerMove(columnChosen, FirstPlayerSymbol);
          isPlayerOneTurn = !isPlayerOneTurn;
        } else {
          Gameboard.displayGameboard();
          Console.WriteLine($"It is your turn {SecondPlayerName}.");
          Console.WriteLine("Please, select the column you would like to drop your pieces in: ");
          columnChosen = Console.ReadLine();
          Gameboard.playerMove(columnChosen, SecondPlayerSymbol);
          isPlayerOneTurn = !isPlayerOneTurn;
        }
      }
    }
  }
}
