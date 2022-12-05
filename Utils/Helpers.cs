using Internship_4_OOP_Crypto_Wallet.Classes.Assets;
using Internship_4_OOP_Crypto_Wallet.Classes.Wallets;
using Internship_4_OOP_Crypto_Wallet.Interfaces;
using static Internship_4_OOP_Crypto_Wallet.Enums.Types;

namespace Internship_4_OOP_Crypto_Wallet.Utils
{
    public static class Helpers
    {
        public static decimal FindAmount(Guid assetAddress, ISupportsFungible wallet)
         => wallet.Balances.First(x => x.AssetAddress == assetAddress).Amount;

        public static FungibleAsset? FindByLabel(FungibleAsset[] assets, string label)
            => assets.First(x => x.Label == label);

        /// <summary>
        /// Returns a percentage difference between the initial and final value.
        /// </summary>
        /// <param name="initial"></param>
        /// <param name="final"></param>
        /// <returns>Decimal number representing a percentage.</returns>
        public static decimal CalculatePercentDifference(decimal initial, decimal final)
        {
            if(initial != 0)
            {
                return (final - initial) / initial * 100;
            }
            return 0;
        }

        /// <summary>
        /// Wallet factory.
        /// </summary>
        /// <param name="w"></param>
        /// <returns>IWallet of specified type.</returns>
        public static IWallet CreateWallet(WalletType w)
        {
            switch (w)
            {
                case WalletType.BitcoinWallet:
                    {
                        return new BitcoinWallet();
                    }
                case WalletType.EthereumWallet:
                    {
                        return new EthereumWallet();
                    }
                case WalletType.SolanaWallet:
                    {
                        return new SolanaWallet();
                    }
                default:
                    return null;
            }
        }

    }
}
