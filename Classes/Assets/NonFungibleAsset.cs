using Internship_4_OOP_Crypto_Wallet.Classes.Wallets;

namespace Internship_4_OOP_Crypto_Wallet.Classes.Assets
{
    public sealed class NonFungibleAsset : Asset
    {
        #region Fields
        private FungibleAsset _fungibleAsset; // ? Not used
        #endregion

        #region Properties
        #endregion

        #region Constructors
        public NonFungibleAsset(string name, decimal value, FungibleAsset fungibleAsset) : base(name, value)
        {
            FungibleWallet.AddSupport(this);
            _fungibleAsset=fungibleAsset ?? throw new ArgumentNullException("Parameter fungibleAsset cannot be null.");
        }
        #endregion

        #region Methods
        #endregion
    }
}
