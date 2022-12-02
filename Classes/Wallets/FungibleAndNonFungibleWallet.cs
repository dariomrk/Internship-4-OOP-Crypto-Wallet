using Internship_4_OOP_Crypto_Wallet.Classes.Assets;
using Internship_4_OOP_Crypto_Wallet.Interfaces;

namespace Internship_4_OOP_Crypto_Wallet.Classes.Wallets
{
    public abstract class FungibleAndNonFungibleWallet : FungibleWallet, ISupportsNonFungible
    {
        #region Fields
        private List<Guid> _ownedNonFungibleAssets = new();
        private List<Guid> _supportedNonFungibleAssets = new();
        #endregion

        #region Properties
        public Guid[] OwnedNonFungibleAssets => throw new NotImplementedException();
        public Guid[] SupportedNonFungibleAssets => throw new NotImplementedException();
        #endregion

        #region Constructors
        protected FungibleAndNonFungibleWallet() : base()
        {
            SyncSupportedNonFungibleAssets();
        }
        #endregion

        #region Methods
        private void SyncSupportedNonFungibleAssets()
        {
            foreach (var item in _allNonFungible)
            {
                if (_supportedNonFungibleAssets.Contains(item))
                    _supportedNonFungibleAssets.Add(item);
            }
        }

        public bool RemoveAsset(NonFungibleAsset asset)
        {
            SyncSupportedNonFungibleAssets();
            if (!SupportedNonFungibleAssets.Contains(asset.Address))
                throw new InvalidOperationException("Non fungible asset does not exist.");
            if(!_ownedNonFungibleAssets.Contains(asset.Address))
                return false;
            _ownedNonFungibleAssets.Remove(asset.Address);
            return true;
        }

        public void AddAsset(NonFungibleAsset asset)
        {
            SyncSupportedNonFungibleAssets();
            if (!SupportedNonFungibleAssets.Contains(asset.Address))
                throw new InvalidOperationException("Non fungible asset does not exist.");
            _ownedNonFungibleAssets.Add(asset.Address);
        }
        #endregion
    }
}
