namespace ConnectFourGame {
  public class Square {
    public string PlayerSymbol { get; set; } = null; // symbol property is assigned as the players choose their moves...
    private Player Owner { get; set;} = null; // a Owner property that inherits from Player class..
    public Square() {
    }
    public Square(Player owner) {
      PlayerSymbol = owner.PlayerSymbol;
      Owner = owner;
    }
  }
}
