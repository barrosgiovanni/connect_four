namespace ConnectFourGame {
  public class Square {

    private string PlayerSymbol { get; set; } = null;

    public Square() {
    }

    public Square(string playerSymbol) {
      PlayerSymbol = playerSymbol;
    }

    public string getPlayerSymbol() {
      return PlayerSymbol;
    }

    public void setPlayerSymbol(string playerSymbol) {
      PlayerSymbol = playerSymbol;
    }
  }
}
