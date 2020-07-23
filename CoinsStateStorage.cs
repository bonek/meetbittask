namespace RTask
{
  public class CoinsStateStorage
  {

    public CoinState NickerCoinState { get; set; } = new CoinState() { Count = 0, Value = 0.05M, Symbol = "N" };
    public CoinState DimeCoinState { get; set; } = new CoinState() { Count = 0, Value = 0.1M, Symbol = "D" };
    public CoinState QuarterCoinState { get; set; } = new CoinState() { Count = 0, Value = 0.25M, Symbol = "Q" };
    public CoinState DollarCoinState { get; set; } = new CoinState() { Count = 0, Value = 1M, Symbol = "DOLLAR" };

  }
}