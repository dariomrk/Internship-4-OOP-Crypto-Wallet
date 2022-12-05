using Internship_4_OOP_Crypto_Wallet.Classes.Wallets;
using Internship_4_OOP_Crypto_Wallet.Interfaces;
using static Internship_4_OOP_Crypto_Wallet.Enums.Wallet;
using static Internship_4_OOP_Crypto_Wallet.UserInterface.Helpers;
using static Internship_4_OOP_Crypto_Wallet.UserInterface.MenuDefinitons;
using static System.Console;

namespace Internship_4_OOP_Crypto_Wallet.UserInterface
{
    public static class MenuActions
    {
        private static IWallet selectedWallet; // Used in AccessWallet.

        public static void CreateWalletMenu()
        {
            // TODO Implement
            Clear();

            Menu(selectWalletToCreate);
        }

        public static void CreateBitcoinWallet()
        {
            Clear();
            BitcoinWallet b = (BitcoinWallet) CreateWallet(WalletType.BitcoinWallet);
            Write(b);
            WaitForUserInput();
        }

        public static void CreateEthereumWallet()
        {
            // TODO Implement
        }

        public static void CreateSolanaWallet()
        {
            // TODO Implement
        }

        public static void AccessWalletMenu()
        {
            Clear();
            selectedWallet = null;
            // TODO Output all wallets and connected info, then give option to input a wallet addres.


            if(selectedWallet == null)
            {
                WriteError("No wallet selected. Please check if the wallet address was typed in correctly.");
                return;
            }
            // TODO Only if a valid wallet is selected show the menu below.
            Menu(accessWalletMenuItems);
        }
    }
}
