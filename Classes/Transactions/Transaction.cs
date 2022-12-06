using Internship_4_OOP_Crypto_Wallet.Classes.Assets;
using Internship_4_OOP_Crypto_Wallet.Interfaces;
using static Internship_4_OOP_Crypto_Wallet.Enums.Types;

namespace Internship_4_OOP_Crypto_Wallet.Classes.Transactions
{
    public abstract class Transaction : ITransaction
    {
        #region Fields
        public TransactionType Type => _type;
        public TransactionType _type;
        private Guid _id;
        private Guid _assetAddress;
        private DateTime _createdAt = DateTime.UtcNow;
        protected IWallet _sender, _reciever;
        private bool _isRevoked = false;
        #endregion

        #region Properties
        public Guid Id => _id;
        public Guid AssetAddress => _assetAddress;
        public DateTime CreatedAt => _createdAt;
        public Guid Sender => _sender.Address;
        public Guid Reciever => _reciever.Address;
        public bool IsRevoked { get => _isRevoked; }
        #endregion

        #region Constructors
        protected Transaction(Guid assetAddress, IWallet sender, IWallet reciever, TransactionType type)
        {
            _id = Guid.NewGuid();
            _type = type;
            _assetAddress = assetAddress;
            _sender = sender;
            _reciever = reciever;

            sender.AddTransaction(this);
            reciever.AddTransaction(this);
        }
        #endregion

        #region Methods
        public virtual void RevokeTransaction()
        {
            _isRevoked = true;
        }
        #endregion
    }
}
