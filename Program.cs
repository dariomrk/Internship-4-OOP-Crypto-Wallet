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



            Menu(mainMenuItems);
        }
    }
}