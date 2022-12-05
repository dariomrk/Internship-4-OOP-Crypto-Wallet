﻿using static Internship_4_OOP_Crypto_Wallet.UserInterface.MenuActions;

namespace Internship_4_OOP_Crypto_Wallet.UserInterface
{
    public static class MenuDefinitons
    {
        public static readonly (string Alias, Action Action)[] mainMenuItems = new (string Alias, Action Action)[]
        {
            ("Exit application", new Action(()=>{ Environment.Exit(0); })),
            ("Create wallet", CreateWalletMenu),
            ("Access wallet", AccessWalletMenu),
        };

        public static readonly (string Alias, Action Action)[] selectWalletToCreate = new (string Alias, Action Action)[]
        {
            ("Return", new Action(()=>{ Helpers.Menu(mainMenuItems); })),
            ("Bitcoin wallet", CreateBitcoinWallet),
            ("Ethereum wallet", CreateEthereumWallet),
            ("Solana wallet", CreateSolanaWallet),
        };

        public static readonly (string Alias, Action Action)[] accessWalletMenuItems = new (string Alias, Action Action)[]
        {
            ("Return", new Action(()=>{ Helpers.Menu(mainMenuItems); })),
        };
    }
}