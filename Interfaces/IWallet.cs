namespace Internship_4_OOP_Crypto_Wallet.Interfaces
{
    public interface IWallet
    {
        public Guid Address { get; }
        public string Type { get; }
    }
}
