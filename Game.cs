namespace ConnectFourGame {
  public class Game {
    private Gameboard Gameboard { get; set; } // a game is made with a gameboard...
    private Player FirstPlayer { get; set; } // a first player...
    private Player SecondPlayer { get; set; } // a second player...
    public Game (Player firstPlayer, Player secondPlayer) {
      // every time we create a game, we'll be creating a gameboard and defining the players...
      Gameboard = new Gameboard();
      FirstPlayer = firstPlayer;
      SecondPlayer = secondPlayer;
    }
    public void InstructPlayer(Player player) {
      Console.WriteLine($"\nIt is your turn {player.PlayerName}.");
      Console.WriteLine("Please, select the column you would like to drop your pieces in: ");
    }
    public void StartTheGame() {
      bool isPlayerOneTurn = true; // we'll use this boolean to change player's turn once their move is complete...
      bool isGameRunning = true; // game will be running in a loop until one of the players join 4 squares...
      string columnChosen; // column chosen by the user to put his pieces in...
      while (isGameRunning) {
        // while game is running we'll be checking who's turn and receive the input...
        if (isPlayerOneTurn) {
          Gameboard.DisplayGameboard();
          InstructPlayer(FirstPlayer);
          columnChosen = Console.ReadLine();
          if (Gameboard.PlayerMove(columnChosen, FirstPlayer.PlayerSymbol)) {
            if (Gameboard.CheckWinner(columnChosen, FirstPlayer.PlayerSymbol)) {
              // if checkWinner method returns true:
              isGameRunning = !isGameRunning; // we stop the game...
              Gameboard.DisplayGameboard(); // display the board for the last time...
              Console.WriteLine($"Congrats {FirstPlayer.PlayerName}! You won!"); // // announce the winner...
            } else {
              // if the checkWinner method returns false, we change the turn and the other player plays...
              isPlayerOneTurn = !isPlayerOneTurn;
            }
          }
        } else {
          Gameboard.DisplayGameboard();
          InstructPlayer(SecondPlayer);
          columnChosen = Console.ReadLine();
          if (Gameboard.PlayerMove(columnChosen, SecondPlayer.PlayerSymbol)) {
            if (Gameboard.CheckWinner(columnChosen, SecondPlayer.PlayerSymbol)) {
              // if checkWinner method returns true:
              isGameRunning = !isGameRunning; // we stop the game...
              Gameboard.DisplayGameboard(); // display the board for the last time...
              Console.WriteLine($"Congrats {SecondPlayer.PlayerName}! You won!"); // announce the winner...
            } else {
              // if the checkWinner method returns false, we change the turn and the other player plays...
              isPlayerOneTurn = !isPlayerOneTurn;
            }
          }
        }
      }
    }
  }
}
