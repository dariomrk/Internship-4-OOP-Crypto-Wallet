using Internship_4_OOP_Crypto_Wallet.Interfaces;

namespace Internship_4_OOP_Crypto_Wallet.Utils
{
    public static class Helpers
    {
        public static decimal GetAmountFromBalances(Guid assetAddress, ISupportsFungible wallet)
         => wallet.Balances.Where(x => x.AssetAddress == assetAddress).ToArray()[0].Amount;
    }
}
