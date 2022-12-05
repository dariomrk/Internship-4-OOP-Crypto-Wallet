﻿using static System.Console;
using Internship_4_OOP_Crypto_Wallet.Interfaces;

namespace Internship_4_OOP_Crypto_Wallet.UserInterface
{
    public static class Helpers
    {
        public static void WaitForUserInput()
        {
            WriteLine("Press any key to continue...");
            ReadKey();
        }
        
        public static void WriteSuccess(string message)
        {
            BackgroundColor = ConsoleColor.Green;
            ForegroundColor = ConsoleColor.Black;
            WriteLine("Success: " + message);
            ResetColor();
        }
        public static void WriteError(string message, bool wait = true)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine("Error! " + message);
            ResetColor();
            if(wait)
                WaitForUserInput();
        }

        public static void WriteWarning(string message, bool wait = true)
        {
            ForegroundColor = ConsoleColor.Black;
            BackgroundColor = ConsoleColor.Yellow;
            WriteLine("Warning: " + message);
            ResetColor();
            if(wait)
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

        public static void WriteBasicInfo(IWallet w)
        {
            WriteLine($"{w.Type} \nAddress: {w.Address}");
        }
        
        public static bool TryGetAddressFromUser(out Guid address)
        {
            if (!Guid.TryParse(ReadLine(), out address))
                return false;
            return true;
        }

        public static void HorizontalSeparator()
        {
            WriteLine(new string('-',30));
        }
    }
}
