using static System.Console;
using static Internship_4_OOP_Crypto_Wallet.Enums.Types;
using static Internship_4_OOP_Crypto_Wallet.UserInterface.MainMenuActions;
using static Internship_4_OOP_Crypto_Wallet.UserInterface.Helpers;
using Internship_4_OOP_Crypto_Wallet.Classes.Assets;
using Internship_4_OOP_Crypto_Wallet.Classes.Wallets;
using Internship_4_OOP_Crypto_Wallet.Interfaces;
using Internship_4_OOP_Crypto_Wallet.Classes.Transactions;

namespace Internship_4_OOP_Crypto_Wallet.UserInterface
{
    public static class AccessWalletMenuActions
    {
        public static void Portfolio()
        {
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
                {
                    AltHorizontalSeparator();
                    WriteLine($"Portfolio value: {w.PortfolioValueUSD} $");
                }

                WaitForUserInput();
            }
        }

        public static void Transfer()
        {
            Clear();
            Write("Input the address of the recipient: ");
            if (!TryGetAddressFromUser(out Guid walletAddress))
            {
                WriteError("Invalid address format.");
                return;
            }

            IWallet toBeReciever = BaseWallet.GetWallet(walletAddress);

            if (toBeReciever == null)
            {
                WriteError("No wallet selected. Please check if the wallet address was typed in correctly.");
                return;
            }

            Clear();
            Write("Input the address of the asset to send: ");
            if (!TryGetAddressFromUser(out Guid assetAddress))
            {
                WriteError("Invalid address format.");
                return;
            }

            Asset asset = Asset.GetAsset(assetAddress);

            if (asset == null)
            {
                WriteError("No asset selected. Please check if the asset address was typed in correctly.");
                return;
            }

            if (asset.Type == AssetType.Fungible)
            {
                // FUNGIBLE ASSET TRANSACTION
                if (!TryGetAmountFromUser(out decimal amount))
                {
                    WriteError("Invalid format. Cancelling transaction.");
                    return;
                }

                if (!GetConfirmation("Are you sure you want to proceed with the transaction?"))
                {
                    WriteWarning("Cancelled.");
                    return;
                }
                Clear();
                BaseWallet sender = (BaseWallet)selectedWallet;
                BaseWallet reciever = (BaseWallet)toBeReciever;

                if (!FungibleAssetTransaction.TryCreateFungibleTransaction(amount,
                    (FungibleAsset)asset,
                    sender,
                    reciever,
                    out FungibleAssetTransaction transaction))
                {
                    WriteError("Cannot create a fungible transaction.\n" +
                        "Possible causes:\n" +
                        "The amount you tried to send is greater to the amount you own.\n" +
                        "The amount you tried to send is a negative value.");
                    return;
                }
            }
            else if (asset.Type == AssetType.NonFungible)
            {
                // NON FUNGIBLE ASSET TRANSACTION
                if(selectedWallet.Type == WalletType.BitcoinWallet || toBeReciever.Type == WalletType.BitcoinWallet)
                {
                    WriteError("One or both of the wallets cannot handle non fungible assets.");
                    return;
                }

                AdvancedWallet sender = (AdvancedWallet)selectedWallet;
                AdvancedWallet reciever = (AdvancedWallet)toBeReciever;

                if (!NonFungibleAssetTransaction.TryCreateNonFungibleTransaction((NonFungibleAsset)asset,
                    sender,
                    reciever,
                    out NonFungibleAssetTransaction transaction))
                {
                    WriteError("Cannot create a non fungible transaction.");
                    return;
                }
            }
            asset.RandomlyChangeValue();
            WriteSuccess("Transaction completed.");
            WaitForUserInput();
        }

        public static void TransactionHistory()
        {
            Clear();
            List<ITransaction> sortedTransactions = selectedWallet.Transactions.ToList();
            sortedTransactions.Sort(
                (x, y) => x.CreatedAt.CompareTo(y.CreatedAt));

            foreach (var t in sortedTransactions)
            {
                HorizontalSeparator();
                WriteLine($"Transaction Id: {t.Id}\n" +
                    $"Timestamp: {t.CreatedAt}\n" +
                    $"Sender: {t.Sender}\n" +
                    $"Reciever: {t.Reciever}\n" +
                    $"Name: {Asset.GetAsset(t.AssetAddress)!.Name}\n" +
                    $"Revoked: {t.IsRevoked}");
                try
                {
                    decimal diff = ((FungibleAssetTransaction)t).BalanceSenderAfter
                        - ((FungibleAssetTransaction)t).BalanceSenderBefore;
                    WriteLine($"Amount: {diff}");
                }
                catch (Exception)
                {
                    // Catch what? (● _ ●)
                }
            }
            if (!selectedWallet.Transactions.Any())
            {
                WriteWarning("There are no previous transactions.", false);
            }
            else
            {
                AltHorizontalSeparator();
                WriteLine("End of transaction history.");
            }
            WaitForUserInput();
        }

        public static void RevokeTransaction()
        {
            // TODO Implement
            foreach (var transaction in selectedWallet.Transactions)
            {

            }
        }
    }
}
