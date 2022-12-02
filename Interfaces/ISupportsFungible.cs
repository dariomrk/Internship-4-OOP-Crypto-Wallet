using Internship_4_OOP_Crypto_Wallet.Classes.Assets;

namespace Internship_4_OOP_Crypto_Wallet.Interfaces
{
    public interface ISupportsFungible
    {
        public Guid Address { get; }
        public (Guid AssetAddress, decimal Amount)[] Balances { get; }
        public Guid[] SupportedFungibleAssets { get; }
        public bool ReduceAssetAmount(FungibleAsset asset, decimal amount);
        public void IncreaseAssetAmount(FungibleAsset asset, decimal amount);
    }
}
