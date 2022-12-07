using Internship_4_OOP_Crypto_Wallet.Classes.Assets;
using Internship_4_OOP_Crypto_Wallet.Classes.Wallets;
using static Internship_4_OOP_Crypto_Wallet.Data.Predefined;
using static Internship_4_OOP_Crypto_Wallet.UserInterface.Helpers;
using static Internship_4_OOP_Crypto_Wallet.UserInterface.MenuDefinitons;

namespace Internship_4_OOP_Crypto_Wallet
{
    public static class Program
    {
        public static void Main()
        {
            Random r = new Random();
            // Assign every wallet a random amount of a random fungible asset.
            foreach (BaseWallet wallet in wallets)
            {
                wallet.IncreaseAssetAmount(fungibleAssets[r.Next(0, fungibleAssets.Length)], r.Next(0, 1000));
            }

            // Randomly assign each non fungible asset to a wallet.
            foreach (NonFungibleAsset asset in nonFungibleAssets)
            {
                (wallets[r.Next(3, wallets.Length)] as AdvancedWallet)!.AddAsset(asset);
            }

            Menu(mainMenuItems);
        }
    }
}
