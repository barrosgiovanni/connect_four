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

    public static Player GetFirstPlayerInfo() {
      // asking users for their names and symbols and creating players...
      Console.WriteLine("\nWhat is Player#1 name?");
      string firstPlayerName = Console.ReadLine();
      Console.WriteLine("\nPlease, choose a symbol to fill out the spaces in the board for Player#1: ");
      string firstPlayerSymbol = Console.ReadLine();
      Player firstPlayer = new Player(firstPlayerName, firstPlayerSymbol);
      return firstPlayer;
    }
    public static Player GetSecondPlayerInfo() {
      // asking users for their names and symbols and creating players...
      Console.WriteLine("\nWhat is Player#2 name?");
      string secondPlayerName = Console.ReadLine();
      Console.WriteLine("\nPlease, choose a symbol to fill out the spaces in the board for Player#2: ");
      string secondPlayerSymbol = Console.ReadLine();
      Player secondPlayer = new Player(secondPlayerName, secondPlayerSymbol);
      return secondPlayer;
    }
    public void InstructPlayer(Player player) {
      Console.WriteLine($"\nIt is your turn {player.PlayerName}.");
      Console.WriteLine("Please, select the column you would like to drop your pieces in: ");
    }
    public static void WantNewGame() {
      string wantNewGame;
      Console.WriteLine("Would you like to start a new game? (Y/N)");
      wantNewGame = Console.ReadLine();
      if (wantNewGame == "Y" || wantNewGame == "y") {
        Game newGame = new Game(GetFirstPlayerInfo(), GetSecondPlayerInfo());
        newGame.StartTheGame();
      } else if (wantNewGame == "Y" || wantNewGame == "y") {
        Console.WriteLine("Thanks for playing Connect4. See you soon");
      } else {
        Console.WriteLine("Unknown command.");
      }
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
              Console.WriteLine($"\nCongrats {FirstPlayer.PlayerName}! You won!"); // announce the winner...
              WantNewGame();
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
              Console.WriteLine($"\nCongrats {SecondPlayer.PlayerName}! You won!"); // announce the winner...
              WantNewGame();
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
