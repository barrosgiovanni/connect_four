namespace ConnectFourGame {
  public class Square {
    private string PlayerSymbol { get; set; } = null;
    // each square has a player symbol propertie, that is going to be assigned as the players choose their moves...

    public Square() {
    }
    public Square(string playerSymbol) {
      PlayerSymbol = playerSymbol;
    }

    public string GetPlayerSymbol() {
      return PlayerSymbol;
    }

    public void SetPlayerSymbol(string playerSymbol) {
      PlayerSymbol = playerSymbol;
    }
  }
}
