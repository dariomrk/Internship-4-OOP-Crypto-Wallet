using static System.Console;
using static Internship_4_OOP_Crypto_Wallet.Utils.Helpers;
using static Internship_4_OOP_Crypto_Wallet.Enums.Types;
using static Internship_4_OOP_Crypto_Wallet.UserInterface.Helpers;

namespace Internship_4_OOP_Crypto_Wallet.UserInterface
{
    public static class CreateWalletMenuActions
    {
        public static void CreateBitcoinWallet()
        {
            Clear();
            WriteSuccess("Created wallet");
            WriteBasicInfo(CreateWallet(WalletType.BitcoinWallet));
            WaitForUserInput();
        }

        public static void CreateEthereumWallet()
        {
            Clear();
            WriteSuccess("Created wallet");
            WriteBasicInfo(CreateWallet(WalletType.EthereumWallet));
            WaitForUserInput();
        }

        public static void CreateSolanaWallet()
        {
            Clear();
            WriteSuccess("Created wallet");
            WriteBasicInfo(CreateWallet(WalletType.SolanaWallet));
            WaitForUserInput();
        }
    }
}
