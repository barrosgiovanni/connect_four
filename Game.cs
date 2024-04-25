namespace ConnectFourGame {
  public class Game {
    private Gameboard Gameboard { get; set; } // a game is made with a gameboard...
    private Player FirstPlayer { get; set; } // a first player...
    public Player SecondPlayer { get; set; } // a second player...
    public Game (Player firstPlayer) {
      // every time we create a game, we'll be creating a gameboard and defining the players...
      // player 2 will be null and then assigned a Player instance later on...
      Gameboard = new Gameboard();
      FirstPlayer = firstPlayer;
      SecondPlayer = null;
    }
    public static Player GetPlayerInfo(bool isPlayerOneDefined) {
      // we'll be asking users for their names and symbols and doing validation...
      // if their names and symbols are empty, they'll be asked to type again...
      string playerName;
      string playerSymbol;
      bool isNameValid = false;
      bool isSymbolValid = false;
      do {
        Console.WriteLine($"\nWhat is Player#{(isPlayerOneDefined ? 2 : 1)} name?");
        playerName = Console.ReadLine();
        if (!string.IsNullOrEmpty(playerName)) {
          isNameValid = !isNameValid;
        }
      } while (!isNameValid);
      do {
        Console.WriteLine($"\nPlease, choose a symbol to fill out the spaces in the board for Player#{(isPlayerOneDefined ? 2 : 1)}: ");
        playerSymbol = Console.ReadLine();
        if (!string.IsNullOrEmpty(playerSymbol)) {
          isSymbolValid = !isSymbolValid;
        }
      } while (!isSymbolValid);
      // creating and returning player...
      Player player = new Player(playerName, playerSymbol);
      return player;
    }
    public static void CreateNewGame() {
      // we're creating a new game and checking if the first player was created...
      // if he's already created, then we'll be collecting the second player info and start the game...
      bool isPlayerOneDefined = false;
      Game newGame = new Game(Game.GetPlayerInfo(isPlayerOneDefined));
      isPlayerOneDefined = !isPlayerOneDefined;
      newGame.SecondPlayer = Game.GetPlayerInfo(isPlayerOneDefined);
      newGame.StartTheGame();
    }
    public static void InstructPlayer(Player player) {
      // telling the players who's supposed to play...
      Console.WriteLine($"\nIt is your turn {player.PlayerName}.");
      Console.WriteLine("Please, select the column you would like to drop your pieces in: ");
    }
    public static void WantNewGame() {
      // asking player if he wants to play again...
      // if his answer is different then Y or N, he'll be informed to type a valid key and asked again...
      bool askAgain = true;
      while (askAgain) {
        Console.WriteLine("\nWould you like to start a new game? (Y/N)");
        string wantNewGame = Console.ReadLine().ToUpper();
        if (wantNewGame == "Y") {
          CreateNewGame();
          askAgain = !askAgain;
        } else if (wantNewGame == "N") {
          Console.WriteLine("\nThanks for playing Connect4. See you soon!");
          askAgain = !askAgain;
        } else {
          Console.WriteLine("\nUnknown command. Please, type a valid option (Y/N).");
        }
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
              WantNewGame(); // ask if user wants to play again...
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
              WantNewGame(); // ask if user wants to play again...
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
