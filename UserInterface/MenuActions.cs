using Internship_4_OOP_Crypto_Wallet.Interfaces;
using static Internship_4_OOP_Crypto_Wallet.Utils.Helpers;
using static Internship_4_OOP_Crypto_Wallet.Enums.Wallet;
using static Internship_4_OOP_Crypto_Wallet.UserInterface.Helpers;
using static Internship_4_OOP_Crypto_Wallet.UserInterface.MenuDefinitons;
using static System.Console;
using Internship_4_OOP_Crypto_Wallet.Classes.Wallets;

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
            WriteBasicInfo(CreateWallet(WalletType.BitcoinWallet));
            WaitForUserInput();
        }

        public static void CreateEthereumWallet()
        {
            Clear();
            WriteBasicInfo(CreateWallet(WalletType.EthereumWallet));
            WaitForUserInput();
        }

        public static void CreateSolanaWallet()
        {
            Clear();
            WriteBasicInfo(CreateWallet(WalletType.SolanaWallet));
            WaitForUserInput();
        }

        public static void AccessWalletMenu()
        {
            Clear();
            foreach (var w in BaseWallet.WalletAddresses())
            {
                HorizontalSeparator();
                WriteLine(BaseWallet.GetWallet(w));
            }
            WaitForUserInput();

            Clear();
            Write("Input wallet address: ");
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
