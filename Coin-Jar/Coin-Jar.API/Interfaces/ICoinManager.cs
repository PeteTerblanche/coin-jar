namespace Coin_Jar.API.Interfaces
{
    public interface ICoinManager
    {
        ICoin ProcessCoin(decimal amount);
        decimal GetTotalAmount();
        void Reset();
    }
}