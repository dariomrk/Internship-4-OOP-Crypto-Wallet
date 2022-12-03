using Internship_4_OOP_Crypto_Wallet.Classes.Assets;
using Internship_4_OOP_Crypto_Wallet.Classes.Transactions;
using Internship_4_OOP_Crypto_Wallet.Interfaces;

namespace Internship_4_OOP_Crypto_Wallet.Classes.Wallets
{
    public abstract class FungibleWallet : ISupportsFungible
    {
        #region Static members
        protected static List<Guid> _allFungible = new();
        protected static List<Guid> _allNonFungible = new();

        public static void AddSupport(FungibleAsset a)
        {
            _allFungible.Add(a.Address);
        }
        public static void AddSupport(NonFungibleAsset a)
        {
            _allNonFungible.Add(a.Address);
        }
        #endregion

        #region Fields
        private Guid _address = Guid.NewGuid();
        private List<ITransaction> _transactions = new();
        private Dictionary<Guid, decimal> _balances = new();
        #endregion

        #region Properties
        public Guid Address => _address; 
        public ITransaction[] Transactions => _transactions.ToArray();
        public (Guid AssetAddress, decimal Amount)[] Balances
        {
            get
            {
                List<(Guid, decimal)> output = new();

                foreach (var key in _balances.Keys)
                {
                    output.Add((key, _balances[key]));
                }
                return output.ToArray();
            }
        }
        public Guid[] SupportedFungibleAssets => _allFungible.ToArray();
        #endregion

        #region Constructors
        protected FungibleWallet()
        {
        }
        #endregion

        #region Methods
        public bool CanCoverAssetAmount(FungibleAsset asset, decimal amount)
        {
            if (!SupportedFungibleAssets.Contains(asset.Address))
                throw new InvalidOperationException("Fungible asset does not exist.");

            if (_balances[asset.Address] < amount)
                return false;
            return true;
        }

        public bool ReduceAssetAmount(FungibleAsset asset, decimal amount)
        {
            if (!CanCoverAssetAmount(asset, amount))
                return false;
            _balances[asset.Address] -= amount;
            return true;
        }

        public void IncreaseAssetAmount(FungibleAsset asset, decimal amount)
        {
            if (!SupportedFungibleAssets.Contains(asset.Address))
                throw new InvalidOperationException("Fungible asset does not exist.");
            _balances[asset.Address] += amount;
        }

        public void RevokeFungibleTransaction(FungibleAssetTransaction transaction)
        {
            if(transaction.Sender == Address)
            {
                _balances[transaction.AssetAddress] += transaction.BalanceSenderBefore-transaction.BalanceSenderAfter;
            }
            if(transaction.Reciever == Address)
            {
                _balances[transaction.AssetAddress] += transaction.BalanceRecieverBefore-transaction.BalanceRecieverAfter;
            }
        }
        #endregion
    }
}
