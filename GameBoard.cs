namespace ConnectFourGame {
  public class Gameboard {
    private static int numOfColumns = 7; // number of columns of the original game...
    private static int numOfRows = 6; // number of rows of the original game + Directions
    Square[,] gameBoard = new Square[numOfRows, numOfColumns]; // array of Squares that represent the gameboard...
    int[] boardPositions = { 1, 2, 3, 4, 5, 6, 7 }; // defining board positions to help players when choosing next move...
    public bool PlayerMove(string playerChoice, string playerSymbol) {
      int moveColumn = int.Parse(playerChoice) - 1; // we get the user input and find the column index he wants play...
      // if the index that was chosen is valid, then we'll proceed...
      if (moveColumn >= 0 && moveColumn < numOfColumns ) {
        // also checking if the column is not already full...
        if (gameBoard[0, moveColumn] == null) {
          // if the column is not full, then we'll add square that is not filled out, and add the player symbol...
          for (int row = numOfRows-1; row >= 0; row--) {
            if (gameBoard[row, moveColumn] == null) {
              gameBoard[row, moveColumn] = new Square();
              gameBoard[row, moveColumn].SetPlayerSymbol(playerSymbol);
              break;
            }
          }
          return true;
        } else {
          Console.WriteLine("Invalid move. Column is full!");
          return false;
        }
      } else {
        Console.WriteLine("Invalid move. Please, select a column between 1 and 7");
        return false;
      }
    }

    public void DisplayGameboard() {
      Console.WriteLine();
      // printing board positions...
      for (int index = 0; index < boardPositions.Length; index++) {
        Console.Write(" " + boardPositions[index]);
      }
      Console.WriteLine();
      // printing the gameboard to the console by using nested for loops...
      for (int row = 0; row < numOfRows; row++) {
        Console.Write("|");
        for (int column = 0; column < numOfColumns; column++) {
          if (gameBoard[row, column] == null) {
            Console.Write("_");
          } else {
            Console.Write(gameBoard[row, column].GetPlayerSymbol());
          }
          Console.Write("|");
        }
        Console.WriteLine();
      }
    }
    public Gameboard() {
      // default constructor
      // creates a game board and assign null values to its squares...
      for (int row = 0; row < numOfRows; row++) {
        for (int column = 0; column < numOfColumns; column++) {
          gameBoard[row, column] = null;
        }
      }
    }
  }
}
