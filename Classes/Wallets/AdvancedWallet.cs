using Internship_4_OOP_Crypto_Wallet.Classes.Assets;
using Internship_4_OOP_Crypto_Wallet.Classes.Transactions;
using Internship_4_OOP_Crypto_Wallet.Interfaces;
using static Internship_4_OOP_Crypto_Wallet.Enums.Wallet;

namespace Internship_4_OOP_Crypto_Wallet.Classes.Wallets
{
    public abstract class AdvancedWallet : BaseWallet, ISupportsNonFungible
    {
        #region Fields
        private List<Guid> _ownedNonFungibleAssets = new();
        #endregion

        #region Properties
        public Guid[] OwnedNonFungibleAssets => _ownedNonFungibleAssets.ToArray();
        public Guid[] SupportedNonFungibleAssets => _allNonFungible.ToArray();
        #endregion

        #region Constructors
        protected AdvancedWallet(WalletType type) : base(type)
        {

        }
        #endregion

        #region Methods
        public bool OwnsAsset(NonFungibleAsset asset)
        {
            if (!SupportedNonFungibleAssets.Contains(asset.Address))
                throw new InvalidOperationException("Non fungible asset does not exist.");
            if (!_ownedNonFungibleAssets.Contains(asset.Address))
                return false;
            return true;
        }

        public bool RemoveAsset(NonFungibleAsset asset)
        {
            if (!OwnsAsset(asset))
                return false;
            _ownedNonFungibleAssets.Remove(asset.Address);
            return true;
        }

        public void AddAsset(NonFungibleAsset asset)
        {
            OwnsAsset(asset); // Just to check wether the asset even exists.
            _ownedNonFungibleAssets.Add(asset.Address);
        }

        public void RevokeNonFungibleTransaction(NonFungibleAssetTransaction transaction)
        {
            // TODO Test thoroughly, possible null reference, possible cast exception
            if(transaction.Sender == Address)
            {
                if (OwnedNonFungibleAssets.Contains(transaction.AssetAddress))
                    return;
                AddAsset((NonFungibleAsset)Asset.GetAsset(transaction.AssetAddress));
            }
            if (transaction.Reciever == Address)
            {
                if (!OwnedNonFungibleAssets.Contains(transaction.AssetAddress))
                    return;
                RemoveAsset((NonFungibleAsset)Asset.GetAsset(transaction.AssetAddress));
            }
        }
        #endregion
    }
}
