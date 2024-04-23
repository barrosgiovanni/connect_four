namespace ConnectFourGame {
  public class Player {
    public string PlayerName { get; set; }
    public string PlayerSymbol { get; set; }
    public Player(string playerName, string playerSymbol) {
      PlayerName = playerName;
      PlayerSymbol = playerSymbol;
    }
  }
}
