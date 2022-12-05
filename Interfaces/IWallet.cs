using static Internship_4_OOP_Crypto_Wallet.Enums.Wallet;

namespace Internship_4_OOP_Crypto_Wallet.Interfaces
{
    public interface IWallet
    {
        public Guid Address { get; }
        public WalletType Type { get; }
        public decimal PortfolioValueUSD { get; }
        public decimal PreviousPortfolioValueUSD { get; }
    }
}
