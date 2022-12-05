using static System.Console;
using static Internship_4_OOP_Crypto_Wallet.UserInterface.Helpers;
using static Internship_4_OOP_Crypto_Wallet.UserInterface.MenuDefinitons;
using Internship_4_OOP_Crypto_Wallet.Interfaces;
using Internship_4_OOP_Crypto_Wallet.Classes.Wallets;

namespace Internship_4_OOP_Crypto_Wallet.UserInterface
{
    public static class MainMenuActions
    {
        public static IWallet selectedWallet = null; // TODO Sort this thing out

        public static void CreateWalletMenu()
        {
            Clear();
            Menu(createWalletMenuItems);
        }

        public static void AccessWalletMenu()
        {
            Clear();
            foreach (var w in BaseWallet.WalletAddresses())
            {
                HorizontalSeparator();
                WriteLine(BaseWallet.GetWallet(w));
            }
            if (!BaseWallet.WalletAddresses().Any())
            {
                WriteWarning("There are no available wallets.");
                return;
            }
            HorizontalSeparator();

            Write("Input the address of the wallet you want to access: ");
            if (!TryGetAddressFromUser(out Guid walletAddress))
            {
                WriteError("Invalid address format.");
                return;
            }

            selectedWallet = BaseWallet.GetWallet(walletAddress);

            if(selectedWallet == null)
            {
                WriteError("No wallet selected. Please check if the wallet address was typed in correctly.");
                return;
            }

            Clear();
            Menu(accessWalletMenuItems);
        }
    }
}
