using static Internship_4_OOP_Crypto_Wallet.Classes.Wallets.BaseWallet;
using static Internship_4_OOP_Crypto_Wallet.Enums.Types;
using static Internship_4_OOP_Crypto_Wallet.UserInterface.Helpers;
using static System.Console;

namespace Internship_4_OOP_Crypto_Wallet.UserInterface
{
    public static class CreateWalletMenuActions
    {
        public static void CreateBitcoinWallet()
        {
            Clear();
            WriteSuccess("Created wallet");
            WriteBasicInfo(CreateWallet(WalletType.BitcoinWallet)!);
            WaitForUserInput();
        }

        public static void CreateEthereumWallet()
        {
            Clear();
            WriteSuccess("Created wallet");
            WriteBasicInfo(CreateWallet(WalletType.EthereumWallet)!);
            WaitForUserInput();
        }

        public static void CreateSolanaWallet()
        {
            Clear();
            WriteSuccess("Created wallet");
            WriteBasicInfo(CreateWallet(WalletType.SolanaWallet)!);
            WaitForUserInput();
        }
    }
}
