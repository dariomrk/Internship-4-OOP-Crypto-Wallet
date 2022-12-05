using Internship_4_OOP_Crypto_Wallet.Classes.Wallets;
using static Internship_4_OOP_Crypto_Wallet.Data.Predefined;
using static Internship_4_OOP_Crypto_Wallet.UserInterface.Helpers;
using static Internship_4_OOP_Crypto_Wallet.UserInterface.MenuDefinitons;

namespace Internship_4_OOP_Crypto_Wallet
{
    public class Program
    {
        static void Main()
        {
            foreach (var _ in fungibleAssets) ;
            foreach (var _ in nonFungibleAssets) ;
            foreach (var _ in wallets) ;

            ((BitcoinWallet)wallets[0]).IncreaseAssetAmount(fungibleAssets[2], 1);
            ((BitcoinWallet)wallets[0]).IncreaseAssetAmount(fungibleAssets[2], 1);

            ((EthereumWallet)wallets[3]).IncreaseAssetAmount(fungibleAssets[2], 1);
            ((EthereumWallet)wallets[3]).IncreaseAssetAmount(fungibleAssets[2], 1);
            ((EthereumWallet)wallets[3]).AddAsset(nonFungibleAssets[0]);
            ((EthereumWallet)wallets[3]).AddAsset(nonFungibleAssets[1]);

            Menu(mainMenuItems);
        }
    }
}