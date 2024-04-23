namespace ConnectFourGame {
  public class Game {
    private Gameboard Gameboard { get; set; } // a game is made with a gameboard...
    private Player FirstPlayer { get; set; } // a first player...
    private Player SecondPlayer { get; set; } // a second player...
    public Game (string firstPlayerSymbol, string firstPlayerName, string secondPlayerSymbol, string secondPlayerName) {
      // every time we create a game, we'll be creating a gameboard and defining the player's symbols and names...
      Gameboard = new Gameboard();
      FirstPlayer = new Player(firstPlayerName, firstPlayerSymbol);
      SecondPlayer = new Player(secondPlayerName, secondPlayerSymbol);
    }
    public void StartTheGame() {
      bool isPlayerOneTurn = true; // we'll use this boolean to change player's turn once their move is complete...
      bool isGameRunning = true; // game will be running in a loop until one of the players join 4 squares...

      string columnChosen; // column chosen by the user to put his pieces in...

      while (isGameRunning) {
        if (isPlayerOneTurn) {
          Gameboard.DisplayGameboard();
          Console.WriteLine($"\nIt is your turn {FirstPlayer.PlayerName}.");
          Console.WriteLine("Please, select the column you would like to drop your pieces in: ");
          columnChosen = Console.ReadLine();
          if (Gameboard.PlayerMove(columnChosen, FirstPlayer.PlayerSymbol)) {
            isPlayerOneTurn = !isPlayerOneTurn;
          }
        } else {
          Gameboard.DisplayGameboard();
          Console.WriteLine($"\nIt is your turn {SecondPlayer.PlayerName}.");
          Console.WriteLine("Please, select the column you would like to drop your pieces in: ");
          columnChosen = Console.ReadLine();
          if (Gameboard.PlayerMove(columnChosen, SecondPlayer.PlayerSymbol)) {
            isPlayerOneTurn = !isPlayerOneTurn;
          }
        }
      }
    }
  }
}
