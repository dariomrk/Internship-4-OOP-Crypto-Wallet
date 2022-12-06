using Internship_4_OOP_Crypto_Wallet.Interfaces;
using static Internship_4_OOP_Crypto_Wallet.Enums.Types;

namespace Internship_4_OOP_Crypto_Wallet.Classes.Transactions
{
    public abstract class Transaction : ITransaction
    {
        #region Fields
        protected IWallet _sender, _reciever;
        #endregion

        #region Properties
        public TransactionType Type { get; }
        public Guid Id { get; }
        public Guid AssetAddress { get; }
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        public Guid Sender => _sender.Address;
        public Guid Reciever => _reciever.Address;
        public bool IsRevoked { get; private set; } = false;
        #endregion

        #region Constructors
        protected Transaction(Guid assetAddress, IWallet sender, IWallet reciever, TransactionType type)
        {
            Id = Guid.NewGuid();
            Type = type;
            AssetAddress = assetAddress;
            _sender = sender;
            _reciever = reciever;

            if (sender.Address == reciever.Address)
            {
                throw new InvalidOperationException("Cannot transfer an asset to self.");
            }

            sender.AddTransaction(this);
            reciever.AddTransaction(this);
        }
        #endregion

        #region Methods
        public virtual bool RevokeTransaction(IWallet caller)
        {
            if (IsRevoked)
            {
                return false;
            }

            if (caller.Address != Sender)
            {
                return false;
            }

            if ((DateTime.UtcNow - CreatedAt).TotalSeconds <= 60)
            {
                IsRevoked = true;
                return true;
            }
            return false;
        }
        #endregion
    }
}
