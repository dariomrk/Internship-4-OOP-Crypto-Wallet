using static Internship_4_OOP_Crypto_Wallet.Enums.Types;

namespace Internship_4_OOP_Crypto_Wallet.Interfaces
{
    /// <summary>
    /// Defines a generic transaction.
    /// </summary>
    public interface ITransaction
    {
        public TransactionType Type { get; }
        public Guid Id { get; }
        public Guid AssetAddress { get; }
        public DateTime CreatedAt { get; }
        public Guid Sender { get; }
        public Guid Reciever { get; }
        public bool IsRevoked { get; }
        public bool RevokeTransaction(IWallet caller);
    }

}
