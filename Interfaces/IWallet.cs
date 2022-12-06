using static Internship_4_OOP_Crypto_Wallet.Enums.Types;

namespace Internship_4_OOP_Crypto_Wallet.Interfaces
{
    public interface IWallet
    {
        public Guid Address { get; }
        public WalletType Type { get; }
        public decimal PortfolioValueUSD { get; }
        public decimal PreviousPortfolioValueUSD { get; }
        public ITransaction[] Transactions { get; }

        public void AddTransaction(ITransaction transaction);
    }
}
