using static System.Console;
using static Internship_4_OOP_Crypto_Wallet.Enums.Wallet;
using static Internship_4_OOP_Crypto_Wallet.UserInterface.MainMenuActions;
using static Internship_4_OOP_Crypto_Wallet.UserInterface.Helpers;
using Internship_4_OOP_Crypto_Wallet.Classes.Assets;
using Internship_4_OOP_Crypto_Wallet.Classes.Wallets;

namespace Internship_4_OOP_Crypto_Wallet.UserInterface
{
    public static class AccessWalletMenuActions
    {
        public static void Portfolio()
        {
            // TODO Clean code?
            Clear();
            if (selectedWallet.Type == WalletType.BitcoinWallet)
            {
                BaseWallet w = (BaseWallet)BaseWallet.GetWallet(selectedWallet.Address)!;

                foreach (var balance in w.Balances)
                {
                    if (balance.Amount != 0)
                    {
                        HorizontalSeparator();
                        FungibleAsset a = (FungibleAsset)Asset.GetAsset(balance.AssetAddress)!;
                        WriteLine(a);
                        a.ViewedValue();
                        WriteLine($"Amount: {balance.Amount}");
                        WriteLine($"Total: {balance.Amount * Asset.GetAsset(balance.AssetAddress)!.ValueUSD} $");
                    }
                }
                if (!w.Balances.Where(x => x.Amount > 0).Any())
                    WriteWarning("There are no owned fungible assets.", false);
                else
                {
                    AltHorizontalSeparator();
                    WriteLine($"Portfolio value: {w.PortfolioValueUSD} $");
                }

                WaitForUserInput();
            }
            else
            {
                AdvancedWallet w = (AdvancedWallet)BaseWallet.GetWallet(selectedWallet.Address)!;

                WriteLine("Fungible assets:");
                foreach (var balance in w.Balances)
                {
                    if (balance.Amount != 0)
                    {
                        HorizontalSeparator();
                        FungibleAsset a = (FungibleAsset)Asset.GetAsset(balance.AssetAddress)!;
                        WriteLine(a);
                        a.ViewedValue();
                        WriteLine($"Amount: {balance.Amount}");
                        WriteLine($"Total: {balance.Amount * Asset.GetAsset(balance.AssetAddress)!.ValueUSD} $");
                    }
                }
                if (!w.Balances.Where(x => x.Amount > 0).Any())
                    WriteWarning("There are no owned fungible assets.", false);
                WriteLine();
                WriteLine("Non fungible assets:");
                foreach (var address in w.OwnedNonFungibleAssets)
                {
                    HorizontalSeparator();
                    WriteLine((NonFungibleAsset)Asset.GetAsset(address)!);
                }
                if (!w.OwnedNonFungibleAssets.Any())
                    WriteWarning("There are no owned non fungible assets.", false);
                else
                    AltHorizontalSeparator();
                WriteLine($"Portfolio value: {w.PortfolioValueUSD} $");
                WaitForUserInput();
            }
        }
        public static void Transfer()
        {
            // TODO Implement
        }

        public static void TransactionHistory()
        {
            // TODO Implement
        }

        public static void RevokeTransaction()
        {
            // TODO Implement
        }
    }
}
