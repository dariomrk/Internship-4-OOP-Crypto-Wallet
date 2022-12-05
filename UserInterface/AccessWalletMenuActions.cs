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

            if (asset.Type == AssetType.NonFungible
                || selectedWallet.Type != WalletType.BitcoinWallet
                || toBeReciever.Type != WalletType.BitcoinWallet)
            {
                WriteError("One of the wallets cannot handle non fungible assets.");
                return;
            }
            else if(asset.Type == AssetType.NonFungible)
            {
                AdvancedWallet sender = (AdvancedWallet)selectedWallet;
                AdvancedWallet reciever = (AdvancedWallet)toBeReciever;

                if(!NonFungibleAssetTransaction.TryCreateNonFungibleTransaction((NonFungibleAsset)asset,
                    sender,
                    reciever,
                    out NonFungibleAssetTransaction transaction))
                {
                    WriteError("Cannot create a non fungible transaction.");
                    return;
                }
            }
            else
            {
                
                

                if (!TryGetAmountFromUser(out decimal amount))
                {
                    WriteError("Invalid format.");
                    return ;
                }

                BaseWallet sender = (BaseWallet)selectedWallet;
                BaseWallet reciever = (BaseWallet)toBeReciever;

                if (!FungibleAssetTransaction.TryCreateFungibleTransaction(amount,
                    (FungibleAsset)asset,
                    sender,
                    reciever,
                    out FungibleAssetTransaction transaction))
                {
                    WriteError("Cannot create a fungible transaction.");
                    return;
                }
            }
            asset.RandomlyChangeValue();
            WriteSuccess("Transaction done.");
        }

        public static void TransactionHistory()
        {
            foreach(var transaction in selectedWallet)
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
