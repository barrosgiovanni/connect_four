using System.Collections.Concurrent;

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
    public bool CheckWinner(string columnPlayed, string winnerSymbol) {
      int columnChosen = int.Parse(columnPlayed) - 1;
      bool isGameOver = false; // we'll be returning this boolean at the end...
      for (int row = 0; row < numOfRows; row++) {
        if (gameBoard[row, columnChosen] != null) { // we'll only check if the piece is occupied by a symbol...
          int connections = 1; // we start with 1 and if it gets to 4 then we have a winner...
          // checking vertically...
          for (int xRow = row + 1; xRow < numOfRows; xRow++) {
            if (gameBoard[xRow, columnChosen].GetPlayerSymbol() == winnerSymbol) {
              connections++; // we add 1 connection if the symbols match...
              if (connections == 4) {
                isGameOver = true;
              }
            } else {
              connections = 1; // we reset if the symbols don't match...
            }
          }
          // checking horizontally...
          connections = 0; // in this case will be 0...
          for (int yCol = columnChosen - 3; yCol < numOfColumns + 3;  yCol++) {
            if (yCol < 0) { // we just ignore when column index is less than zero...
              continue;
            }
            if (yCol >= numOfColumns) { // we break if the column index is higher than the number of columns...
              break;
            }
            if (gameBoard[row, yCol] != null && gameBoard[row, yCol].GetPlayerSymbol() == winnerSymbol) {
              connections++; // we add 1 connection if the symbols match...
              if (connections == 4) {
                isGameOver = true;
              }
            } else {
              connections = 0; // we reset if the symbols don't match...
            }
          }

          // checking left diagonal...
          connections = 0; // in this case will be 0...
          for (int xRow = row - 3, yCol = columnChosen - 3; xRow <= numOfRows + 3 && yCol <= numOfColumns + 3; xRow++, yCol++) {
            if (xRow < 0 || yCol < 0) { // we just ignore when row or column index is less than zero...
              continue;
            }
            if (xRow >= numOfRows || yCol >= numOfColumns) { // we break if the row or column index is higher than the number of rows or columns...
              break;
            }
            if (gameBoard[xRow, yCol] != null && gameBoard[xRow, yCol].GetPlayerSymbol() == winnerSymbol) {
              connections++; // we add 1 connection if the symbols match...
              if (connections == 4) {
                isGameOver = true;
              }
            } else {
              connections = 0; // we reset if the symbols don't match...
            }
          }

          // checking right diagonal...
          for (int xRow = row - 3, yCol = columnChosen + 3; xRow <= row + 3 && yCol >= columnChosen - 3; xRow++, yCol--) {
            if (xRow < 0 || yCol >= numOfColumns) { // we just ignore when row or column index is less than zero...
              continue;
            }
            if (xRow >= numOfRows || yCol < 0) { // we break if the row or column index is higher than the number of rows or columns...
              break;
            }
            if (gameBoard[xRow, yCol] != null && gameBoard[xRow, yCol].GetPlayerSymbol() == winnerSymbol) {
              connections++; // we add 1 connection if the symbols match...
              if (connections == 4) {
                isGameOver = true;
              }
            } else {
              connections = 0; // we reset if the symbols don't match...
            }
          }
          break;
        }
      }
      return isGameOver;
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
