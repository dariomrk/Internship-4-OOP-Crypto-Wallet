using Internship_4_OOP_Crypto_Wallet.Classes.Wallets;
using static Internship_4_OOP_Crypto_Wallet.Enums.Types;
using static Internship_4_OOP_Crypto_Wallet.Utils.Helpers;

namespace Internship_4_OOP_Crypto_Wallet.Classes.Assets
{
    public sealed class NonFungibleAsset : Asset
    {
        #region Fields
        private readonly FungibleAsset _tiedFungibleAsset;
        #endregion

        #region Properties
        public Guid TiedFungibleAssetAddress => _tiedFungibleAsset.Address;
        public decimal AmountOfTiedFungibleAsset { get; }

        public override decimal ValueUSD => _tiedFungibleAsset.ValueUSD * AmountOfTiedFungibleAsset;
        public override decimal PreviousValueUSD => _tiedFungibleAsset.PreviousValueUSD * AmountOfTiedFungibleAsset;
        #endregion

        #region Constructors
        public NonFungibleAsset(string name,
            FungibleAsset tiedFungibleAsset,
            decimal tiedFungibleAssetAmount) : base(name,
                tiedFungibleAsset.ValueUSD * tiedFungibleAssetAmount, AssetType.NonFungible)
        {
            BaseWallet.AddSupport(this);
            _tiedFungibleAsset=tiedFungibleAsset
                ?? throw new ArgumentNullException("Parameter fungibleAsset cannot be null.");
            AmountOfTiedFungibleAsset = tiedFungibleAssetAmount;
        }
        #endregion

        #region Methods
        public override void RandomlyChangeValue()
        {
            _tiedFungibleAsset.RandomlyChangeValue();
        }
        public override string ToString()
        {
            decimal diff = CalculatePercentDifference(PreviousValueUSD, ValueUSD);
            return base.ToString() +
                $"\n" +
                $"Type: NonFungible\n" +
                $"Percentage change: {diff:F} %\n" +
                $"Value: {ValueUSD} $";
        }
        #endregion
    }
}
