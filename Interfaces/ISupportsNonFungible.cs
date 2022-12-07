using Internship_4_OOP_Crypto_Wallet.Classes.Assets;
using Internship_4_OOP_Crypto_Wallet.Classes.Transactions;

namespace Internship_4_OOP_Crypto_Wallet.Interfaces
{
    /// <summary>
    /// Defines a wallet that supports interacting with non fungible assets.
    /// </summary>
    public interface ISupportsNonFungible : IWallet
    {
        public Guid[] OwnedNonFungibleAssets { get; }
        public Guid[] SupportedNonFungibleAssets { get; }
        public bool OwnsAsset(NonFungibleAsset asset);
        public bool RemoveAsset(NonFungibleAsset asset);
        public void AddAsset(NonFungibleAsset asset);
        public void RevokeNonFungibleTransaction(NonFungibleAssetTransaction transaction);
    }
}
