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
            // Preset portfolios for testing
            ((BitcoinWallet)wallets[0]).IncreaseAssetAmount(fungibleAssets[0], 1); // add 1 BTC (fungible asset)
            ((EthereumWallet)wallets[3]).IncreaseAssetAmount(fungibleAssets[2], 1000); // add 1000 USDT (fungible asset)
            ((EthereumWallet)wallets[3]).AddAsset(nonFungibleAssets[1]); // add Cel Mates Crime Reports (non fungible asset)
            ((EthereumWallet)wallets[4]).IncreaseAssetAmount(fungibleAssets[0], 2); // add 2 BTC (fungible asset)
            ((EthereumWallet)wallets[4]).AddAsset(nonFungibleAssets[0]); // add Cel Mates by Mcbess (non fungible asset)
            ((SolanaWallet)wallets[7]).AddAsset(nonFungibleAssets[2]); // add Mystery of Chessboxing by anon (non fungible asset)
            ((SolanaWallet)wallets[7]).AddAsset(nonFungibleAssets[3]); // add Non-Fungible Moons (non fungible asset)

            Menu(mainMenuItems);
        }
    }
}
