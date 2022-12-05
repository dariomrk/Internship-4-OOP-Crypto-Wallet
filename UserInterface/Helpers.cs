﻿using Internship_4_OOP_Crypto_Wallet.Classes.Wallets;
using Internship_4_OOP_Crypto_Wallet.Interfaces;
using static Internship_4_OOP_Crypto_Wallet.Enums.Wallet;
using static System.Console;

namespace Internship_4_OOP_Crypto_Wallet.UserInterface
{
    public static class Helpers
    {
        public static void WaitForUserInput()
        {
            WriteLine("Press any key to continue...");
            ReadKey();
        }

        public static void WriteError(string warning)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine("Error! " + warning);
            ResetColor();
            WaitForUserInput();
        }

        public static void Menu((string Alias, Action Action)[] menuItems)
        {
            while (true)
            {
                Clear();
                for (int i = 0; i<menuItems.Length; i++)
                {
                    var menuItem = menuItems[i];

                    WriteLine($"{i} {menuItem.Alias}");
                }
                Write("Select option: ");

                if (!int.TryParse(ReadLine(), out int selection))
                {
                    WriteError("Please input a integer.");
                    continue;
                }
                if (selection < 0 || selection >= menuItems.Length)
                {
                    WriteError($"Selected option must be in [0 - {menuItems.Length - 1}] interval.");
                    continue;
                }

                menuItems[selection].Action();
            }
        }

        public static IWallet CreateWallet(WalletType w)
        {
            switch (w)
            {
                case WalletType.BitcoinWallet:
                    {
                        return new BitcoinWallet();
                    }
                case WalletType.EthereumWallet:
                    {
                        return new EthereumWallet();
                    }
                case WalletType.SolanaWallet:
                    {
                        return new SolanaWallet();
                    }
                default:
                    return null;
            }
        }
    }
}
