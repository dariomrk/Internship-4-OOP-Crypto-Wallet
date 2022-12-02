using Internship_4_OOP_Crypto_Wallet.Classes.Assets;
using Internship_4_OOP_Crypto_Wallet.Interfaces;

namespace Internship_4_OOP_Crypto_Wallet.Classes.Transactions
{
    public sealed class NonFungibleAssetTransaction : Transaction
    {
        public NonFungibleAssetTransaction(FungibleAsset asset,
            ISupportsNonFungible sender,
            ISupportsNonFungible reciever) : base(asset.Address,sender.Address,reciever.Address)
        {

        }
    }
}
