using Internship_4_OOP_Crypto_Wallet.Classes.Assets;

namespace Internship_4_OOP_Crypto_Wallet.Interfaces
{
    public interface ISupportsNonFungible
    {
        public Guid Address { get; }
        public Guid[] OwnedNonFungibleAssets { get; }
        public Guid[] SupportedNonFungibleAssets { get; }
        public bool RemoveAsset(NonFungibleAsset asset);
        public void AddAsset(NonFungibleAsset asset);
    }
}
