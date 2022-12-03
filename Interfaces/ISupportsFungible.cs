using Internship_4_OOP_Crypto_Wallet.Classes.Assets;
using Internship_4_OOP_Crypto_Wallet.Classes.Transactions;

namespace Internship_4_OOP_Crypto_Wallet.Interfaces
{
    public interface ISupportsFungible : IWallet
    {
        public (Guid AssetAddress, decimal Amount)[] Balances { get; }
        public Guid[] SupportedFungibleAssets { get; }
        public bool CanCoverAssetAmount(FungibleAsset asset, decimal amount);
        public bool ReduceAssetAmount(FungibleAsset asset, decimal amount);
        public void IncreaseAssetAmount(FungibleAsset asset, decimal amount);
        public void RevokeFungibleTransaction(FungibleAssetTransaction transaction);
    }
}
