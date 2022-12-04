﻿using Internship_4_OOP_Crypto_Wallet.Classes.Assets;
using Internship_4_OOP_Crypto_Wallet.Interfaces;

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
            => (final - initial) * initial /100;
    }
}
