using Internship_4_OOP_Crypto_Wallet.Classes.Assets;
using Internship_4_OOP_Crypto_Wallet.Classes.Transactions;
using Internship_4_OOP_Crypto_Wallet.Interfaces;
using static Internship_4_OOP_Crypto_Wallet.Enums.Types;
using static Internship_4_OOP_Crypto_Wallet.Utils.Helpers;

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
            return _allWallets.ContainsKey(walletAddress) ? _allWallets[walletAddress] : null;
        }
        public static Guid[] WalletAddresses()
        {
            return _allWallets.Keys.ToArray();
        }
        #endregion

        #region Fields
        private readonly List<ITransaction> _transactions = new();
        private readonly Dictionary<Guid, decimal> _balances = new();
        #endregion

        #region Properties
        public Guid Address { get; } = Guid.NewGuid();
        public ITransaction[] Transactions => _transactions.ToArray();
        public (Guid AssetAddress, decimal Amount)[] Balances
        {
            get
            {
                List<(Guid, decimal)> output = new();

                foreach (Guid key in _balances.Keys)
                {
                    output.Add((key, _balances[key]));
                }
                return output.ToArray();
            }
        }
        public Guid[] SupportedFungibleAssets => _allFungible.ToArray();
        public WalletType Type { get; }
        public virtual decimal PortfolioValueUSD
        {
            get
            {
                decimal sum = 0;
                foreach (KeyValuePair<Guid, decimal> item in _balances)
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
                foreach (KeyValuePair<Guid, decimal> item in _balances)
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
            Type = type;
            foreach (Guid f in _allFungible)
            {
                _balances.Add(f, 0);
            }
            _allWallets.Add(Address, this);
        }
        #endregion

        #region Methods
        public bool CanCoverAssetAmount(FungibleAsset asset, decimal amount)
        {
            return !SupportedFungibleAssets.Contains(asset.Address)
                ? throw new InvalidOperationException("Fungible asset does not exist.")
                : _balances[asset.Address] >= amount;
        }

        public bool ReduceAssetAmount(FungibleAsset asset, decimal amount)
        {
            if (!CanCoverAssetAmount(asset, amount))
            {
                return false;
            }

            _balances[asset.Address] -= amount;
            return true;
        }

        public void IncreaseAssetAmount(FungibleAsset asset, decimal amount)
        {
            if (!SupportedFungibleAssets.Contains(asset.Address))
            {
                throw new InvalidOperationException("Fungible asset does not exist.");
            }

            _balances[asset.Address] += amount;
        }

        public void RevokeFungibleTransaction(FungibleAssetTransaction transaction)
        {
            if (transaction.Sender == Address)
            {
                _balances[transaction.AssetAddress] += transaction.BalanceSenderBefore-transaction.BalanceSenderAfter;
            }
            if (transaction.Reciever == Address)
            {
                _balances[transaction.AssetAddress] += transaction.BalanceRecieverBefore-transaction.BalanceRecieverAfter;
            }
            else
            {
                return;
            }
        }

        public override string ToString()
        {

            decimal diff = CalculatePercentDifference(PreviousPortfolioValueUSD, PortfolioValueUSD);
            return $"Wallet type: {Type}\n" +
                $"Wallet address: {Address}\n" +
                $"Total assets value: {PortfolioValueUSD:F} $\n" +
                $"Percentage change: {diff:F} %";
        }

        public void AddTransaction(ITransaction transaction)
        {
            _transactions.Add(transaction);
        }
        #endregion
    }
}
