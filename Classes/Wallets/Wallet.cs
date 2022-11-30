using Internship_4_OOP_Crypto_Wallet.Classes.Assets;
using Internship_4_OOP_Crypto_Wallet.Interfaces;

namespace Internship_4_OOP_Crypto_Wallet.Classes.Wallets
{
    public abstract class Wallet
    {
        #region Static members
        protected static List<Guid> _supportedFungible = new();
        protected static List<Guid> _supportedNonFungible = new();

        public static void AddSupport(FungibleAsset a)
        {
            _supportedFungible.Add(a.Address);
        }
        public static void AddSupport(NonFungibleAsset a)
        {
            _supportedNonFungible.Add(a.Address);
        }
        #endregion

        #region Fields
        private Guid _address;
        private List<ITransaction> _transactions;
        #endregion

        #region Properties
        public Guid Address => _address; 
        public ITransaction[] Transactions => _transactions.ToArray();
        #endregion

        #region Constructors
        protected Wallet()
        {
            _address = Guid.NewGuid();
            _transactions = new();
        }
        #endregion

        #region Methods
        #endregion
    }
}
