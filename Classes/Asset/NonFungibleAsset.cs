﻿namespace Internship_4_OOP_Crypto_Wallet.Classes.Asset
{
    public sealed class NonFungibleAsset : Asset
    {
        #region Fields
        private FungibleAsset _fungibleAsset;
        #endregion

        #region Properties
        #endregion

        #region Constructors
        public NonFungibleAsset(string name, decimal value, FungibleAsset fungibleAsset) : base(name, value)
        {
            if (fungibleAsset == null)
                throw new ArgumentNullException("Parameter fungibleAsset cannot be null.");
            _fungibleAsset=fungibleAsset;
        }
        #endregion

        #region Methods
        #endregion
    }
}
