namespace ConnectFourGame
{
  class Program {
    static void Main(string[] args) {
      Gameboard newBoard = new Gameboard();
      newBoard.displayGameboard();
      newBoard.playerMove("7", "X");
      newBoard.playerMove("7", "O");
      newBoard.playerMove("5", "X");
      newBoard.playerMove("2", "O");
      newBoard.playerMove("3", "X");
      newBoard.playerMove("5", "0");
      newBoard.playerMove("2", "X");
      newBoard.playerMove("3", "0");
      newBoard.playerMove("7", "X");
      newBoard.playerMove("1", "0");
      newBoard.playerMove("1", "X");
      newBoard.playerMove("2", "0");
      newBoard.playerMove("2", "X");
      newBoard.displayGameboard();
    }
  }
}
