using static Internship_4_OOP_Crypto_Wallet.UserInterface.AccessWalletMenuActions;
using static Internship_4_OOP_Crypto_Wallet.UserInterface.CreateWalletMenuActions;
using static Internship_4_OOP_Crypto_Wallet.UserInterface.MainMenuActions;

namespace Internship_4_OOP_Crypto_Wallet.UserInterface
{
    /// <summary>
    /// Menus / submenu -> action bindings.
    /// </summary>
    public static class MenuDefinitons
    {
        public static readonly (string Alias, Action Action)[] mainMenuItems = new (string Alias, Action Action)[]
        {
            ("Exit application", new Action(()=>{ Environment.Exit(0); })),
            ("Create wallet", CreateWalletMenu),
            ("Access wallet", AccessWalletMenu),
        };

        public static readonly (string Alias, Action Action)[] createWalletMenuItems = new (string Alias, Action Action)[]
        {
            ("Return", new Action(()=>{ Helpers.Menu(mainMenuItems); })),
            ("Bitcoin wallet", CreateBitcoinWallet),
            ("Ethereum wallet", CreateEthereumWallet),
            ("Solana wallet", CreateSolanaWallet),
        };

        public static readonly (string Alias, Action Action)[] accessWalletMenuItems = new (string Alias, Action Action)[]
        {
            ("Return", new Action(()=>{ Helpers.Menu(mainMenuItems); })),
            ("Portfolio", Portfolio),
            ("Transfer", Transfer),
            ("Transaction History",TransactionHistory),
            ("Revoke Transaction", RevokeTransaction),
        };
    }
}
