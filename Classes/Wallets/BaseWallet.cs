using Internship_4_OOP_Crypto_Wallet.Classes.Assets;
using Internship_4_OOP_Crypto_Wallet.Classes.Transactions;
using Internship_4_OOP_Crypto_Wallet.Interfaces;
using static Internship_4_OOP_Crypto_Wallet.Utils.Helpers;
using static Internship_4_OOP_Crypto_Wallet.Enums.Types;

namespace Internship_4_OOP_Crypto_Wallet.Classes.Wallets
{
    public abstract class BaseWallet : ISupportsFungible
    {
        #region Static members
        public static Dictionary<Guid, IWallet> _allWallets = new();
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
        public static IWallet? GetWallet(Guid walletAddress)
        {
            if (_allWallets.ContainsKey(walletAddress))
                return _allWallets[walletAddress];
            return null;
        }
        public static Guid[] WalletAddresses()
        {
            return _allWallets.Keys.ToArray();
        }
        #endregion

        #region Fields
        private Guid _address = Guid.NewGuid();
        private List<ITransaction> _transactions = new();
        private Dictionary<Guid, decimal> _balances = new();
        private WalletType _type;
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
        public WalletType Type => _type;
        public virtual decimal PortfolioValueUSD
        {
            get
            {
                decimal sum = 0;
                foreach (var item in _balances)
                {
                    sum += item.Value * Asset.GetAsset(item.Key)!.ValueUSD;
                }
                return sum;
            }
        }
        public virtual decimal PreviousPortfolioValueUSD
        {
            get
            {
                decimal sum = 0;
                foreach (var item in _balances)
                {
                    sum += item.Value * Asset.GetAsset(item.Key)!.PreviousValueUSD;
                }
                return sum;
            }
        }
        #endregion

        #region Constructors
        protected BaseWallet(WalletType type)
        {
            _type = type;
            foreach(var f in _allFungible)
            {
                _balances.Add(f, 0);
            }
            _allWallets.Add(Address, this);
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
            if (transaction.Reciever == Address)
            {
                _balances[transaction.AssetAddress] += transaction.BalanceRecieverBefore-transaction.BalanceRecieverAfter;
            }
            else
                return;
        }

        public override string ToString()
        {

            decimal diff = CalculatePercentDifference(PreviousPortfolioValueUSD,PortfolioValueUSD);
            return $"Wallet type: {Type}\n" +
                $"Wallet address: {Address}\n" +
                $"Total assets value: {PortfolioValueUSD.ToString("F")} $\n" +
                $"Percentage change: {diff.ToString("F")} %";
        }
        #endregion
    }
}
