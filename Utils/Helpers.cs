using Internship_4_OOP_Crypto_Wallet.Classes.Assets;
using Internship_4_OOP_Crypto_Wallet.Interfaces;

namespace Internship_4_OOP_Crypto_Wallet.Utils
{
    public static class Helpers
    {
        public static decimal FindAmount(Guid assetAddress, ISupportsFungible wallet)
         => wallet.Balances.First(x => x.AssetAddress == assetAddress).Amount;

        public static FungibleAsset? FindByLabel(FungibleAsset[] assets, string label)
            => assets.First(x => x.Label == label);
    }
}
