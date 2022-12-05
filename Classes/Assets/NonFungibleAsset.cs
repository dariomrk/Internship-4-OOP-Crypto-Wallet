using Internship_4_OOP_Crypto_Wallet.Classes.Wallets;
using static Internship_4_OOP_Crypto_Wallet.Utils.Helpers;

namespace Internship_4_OOP_Crypto_Wallet.Classes.Assets
{
    public sealed class NonFungibleAsset : Asset
    {
        #region Fields
        private FungibleAsset _tiedFungibleAsset;
        private decimal _amountOfTiedFungibleAsset;
        #endregion

        #region Properties
        public Guid TiedFungibleAssetAddress { get => _tiedFungibleAsset.Address; }
        public decimal AmountOfTiedFungibleAsset { get => _amountOfTiedFungibleAsset; }

        public override decimal ValueUSD
        {
            get
            {
                return _tiedFungibleAsset.ValueUSD * _amountOfTiedFungibleAsset;
            }
        }
        public override decimal PreviousValueUSD
        {
            get
            {
                return _tiedFungibleAsset.PreviousValueUSD * _amountOfTiedFungibleAsset;
            }
        }
        #endregion

        #region Constructors
        public NonFungibleAsset(string name,
            FungibleAsset tiedFungibleAsset,
            decimal tiedFungibleAssetAmount) : base(name,
                tiedFungibleAsset.ValueUSD * tiedFungibleAssetAmount)
        {
            BaseWallet.AddSupport(this);
            _tiedFungibleAsset=tiedFungibleAsset
                ?? throw new ArgumentNullException("Parameter fungibleAsset cannot be null.");
            _amountOfTiedFungibleAsset = tiedFungibleAssetAmount;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            decimal diff = CalculatePercentDifference(PreviousValueUSD, ValueUSD);
            return base.ToString() +
                $"\n" +
                $"Type: NonFungible\n" +
                $"Percentage change: {diff.ToString("F")} %\n" +
                $"Value: {ValueUSD} $";
        }
        #endregion
    }
}
