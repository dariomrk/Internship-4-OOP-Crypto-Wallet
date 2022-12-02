using Internship_4_OOP_Crypto_Wallet.Classes.Assets;
using Internship_4_OOP_Crypto_Wallet.Classes.Wallets;
using Internship_4_OOP_Crypto_Wallet.Interfaces;

namespace Internship_4_OOP_Crypto_Wallet.Classes.Transactions
{
    public sealed class FungibleAssetTransaction : Transaction
    {
        public FungibleAssetTransaction(decimal amount, FungibleAsset asset,
            ISupportsFungible sender,
            ISupportsFungible reciever) : base(asset.Address, sender.Address, reciever.Address)
        {
            if (sender.ReduceAssetAmount(asset.Address, amount))
                reciever.IncreaseAssetAmount(asset.Address, amount);
            else
                throw new InvalidOperationException("Sender is not able to cover the cost of this transaction.");
        }
    }
}
