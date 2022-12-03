using Internship_4_OOP_Crypto_Wallet.Classes.Wallets;

namespace Internship_4_OOP_Crypto_Wallet.Classes.Assets
{
    public sealed class NonFungibleAsset : Asset
    {
        #region Fields
        private FungibleAsset _tiedFungibleAsset;
        private decimal _tiedFungibleAssetValue;
        #endregion

        #region Properties
        public Guid TiedFungibleAssetAddress { get => _tiedFungibleAsset.Address; }
        public decimal TiedFungibleAssetValue { get => _tiedFungibleAssetValue; }
        #endregion

        #region Constructors
        public NonFungibleAsset(string name,
            FungibleAsset tiedFungibleAsset,
            decimal tiedFungibleAssetAmount) : base(name, 0m)
        {
            BaseWallet.AddSupport(this);
            _tiedFungibleAsset=tiedFungibleAsset
                ?? throw new ArgumentNullException("Parameter fungibleAsset cannot be null.");
            _tiedFungibleAssetValue = tiedFungibleAssetAmount;
        }
        #endregion

        #region Methods
        #endregion
    }
}
