namespace ConnectFourGame {
  public class Square {

    private string PlayerNumber { get; set; } = null;

    public Square() {
    }

    public Square(string playerNumber) {
      PlayerNumber = playerNumber;
    }

    public string getPlayerNumber() {
      return PlayerNumber;
    }

    public void setPlayerNumber(string PlayerNumber) {
      this.PlayerNumber = PlayerNumber;
    }
  }
}
