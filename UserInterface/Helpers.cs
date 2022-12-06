using Internship_4_OOP_Crypto_Wallet.Interfaces;
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
            if (wait)
            {
                WaitForUserInput();
            }
        }

        public static void WriteWarning(string message, bool wait = true)
        {
            ForegroundColor = ConsoleColor.Black;
            BackgroundColor = ConsoleColor.Yellow;
            WriteLine("Warning: " + message);
            ResetColor();
            if (wait)
            {
                WaitForUserInput();
            }
        }

        public static void Menu((string Alias, Action Action)[] menuItems)
        {
            while (true)
            {
                Console.Clear();
                for (int i = 0; i<menuItems.Length; i++)
                {
                    (string Alias, Action Action) menuItem = menuItems[i];

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
            return Guid.TryParse(ReadLine(), out address);
        }

        public static void HorizontalSeparator()
        {
            WriteLine(new string('-', 60));
        }

        public static void AltHorizontalSeparator()
        {
            WriteLine(string.Concat(Enumerable.Repeat("- ", 30)));
        }

        public static bool TryGetAmountFromUser(out decimal amount)
        {
            Clear();
            Write("Enter amount: ");
            return decimal.TryParse(ReadLine(), out amount);
        }

        public static bool GetConfirmation(string message)
        {
            while (true)
            {
                Clear();
                WriteLine(message);
                Write("Input Y/N: ");
                string userInput = ReadLine();
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    WriteError("You must select one option.");
                    continue;
                }
                if (string.Equals(userInput.Trim(), "Y", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }

                if (string.Equals(userInput.Trim(), "N", StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }

                WriteError("Invalid input.");
            }
        }
    }
}
