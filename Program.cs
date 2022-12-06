using static Internship_4_OOP_Crypto_Wallet.UserInterface.Helpers;
using static Internship_4_OOP_Crypto_Wallet.UserInterface.MenuDefinitons;
using static Internship_4_OOP_Crypto_Wallet.Data.Predefined;
using Internship_4_OOP_Crypto_Wallet.Classes.Wallets;

namespace Internship_4_OOP_Crypto_Wallet
{
    public static class Program
    {
        static void Main()
        {
            _ = fungibleAssets;
            _ = nonFungibleAssets;
            _ = wallets;

            ((BitcoinWallet)wallets[0]).IncreaseAssetAmount(fungibleAssets[0], 1);

            ((BitcoinWallet)wallets[1]).IncreaseAssetAmount(fungibleAssets[0], 2);

            ((EthereumWallet)wallets[3]).IncreaseAssetAmount(fungibleAssets[2], 1000);
            ((EthereumWallet)wallets[3]).AddAsset(nonFungibleAssets[0]);
            ((EthereumWallet)wallets[3]).AddAsset(nonFungibleAssets[1]);
            ((EthereumWallet)wallets[3]).AddAsset(nonFungibleAssets[2]);

            ((EthereumWallet)wallets[4]).IncreaseAssetAmount(fungibleAssets[0], 1);



            Menu(mainMenuItems);
        }
    }
}
