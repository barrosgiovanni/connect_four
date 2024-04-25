namespace ConnectFourGame {
  public class Square {
    public string PlayerSymbol { get; set; } = null; // symbol property is assigned as the players choose their moves...
    private Player Owner { get; set;} = null;
    public Square() {
    }
    public Square(Player owner) {
      PlayerSymbol = owner.PlayerSymbol;
    }
  }
}
