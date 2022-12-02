using Internship_4_OOP_Crypto_Wallet.Interfaces;

namespace Internship_4_OOP_Crypto_Wallet.Classes.Transactions
{
    public abstract class Transaction : ITransaction
    {
        #region Fields
        private Guid _id = new();
        private Guid _assetAddress;
        private DateTime _createdAt = DateTime.UtcNow;
        private Guid _sender, _reciever;
        private bool _isRevoked = false;
        #endregion

        #region Properties
        public Guid Id => _id;
        public Guid AssetAddress => _assetAddress;
        public DateTime CreatedAt => _createdAt;
        public Guid Sender => _sender;
        public Guid Reciever => _reciever;
        public bool IsRevoked { get => _isRevoked; set => value = _isRevoked; }
        #endregion

        #region Constructors
        protected Transaction(Guid assetAddress, Guid sender, Guid reciever)
        {
            _assetAddress = assetAddress;
            _sender = sender;
            _reciever = reciever;
        }
        #endregion
    }
}
