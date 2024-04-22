namespace ConnectFourGame {
  public class Gameboard {
    private static int numOfColumns = 7; // number of columns of the original game...
    private static int numOfRows = 6; // number of rows of the original game...
    Square[,] gameBoard = new Square[numOfRows, numOfColumns];
    // creates an array of Squares that will represent the gameboard...

    public void displayGameboard() {
      // printing the gameboard to the console by using nested for loops...
      for (int row = 0; row < numOfRows; row++) {
        Console.Write("|");
        for (int column = 0; column < numOfColumns; column++) {
          if (gameBoard[row, column] == null) {
            Console.Write("_");
          } else {
            Console.Write(gameBoard[row, column].getPlayerNumber());
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
