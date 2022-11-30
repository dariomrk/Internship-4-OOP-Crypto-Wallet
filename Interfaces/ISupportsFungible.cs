namespace Internship_4_OOP_Crypto_Wallet.Interfaces
{
    public interface ISupportsFungible
    {
        public Dictionary<Guid, decimal> Balances { get; }
    }
}
