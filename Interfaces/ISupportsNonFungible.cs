using Internship_4_OOP_Crypto_Wallet.Classes.Assets;
using Internship_4_OOP_Crypto_Wallet.Classes.Transactions;

namespace Internship_4_OOP_Crypto_Wallet.Interfaces
{
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
