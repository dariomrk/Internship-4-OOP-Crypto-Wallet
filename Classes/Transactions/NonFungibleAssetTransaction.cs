using Internship_4_OOP_Crypto_Wallet.Classes.Assets;
using Internship_4_OOP_Crypto_Wallet.Classes.Wallets;
using Internship_4_OOP_Crypto_Wallet.Interfaces;
using static Internship_4_OOP_Crypto_Wallet.Enums.Types;

namespace Internship_4_OOP_Crypto_Wallet.Classes.Transactions
{
    public sealed class NonFungibleAssetTransaction : Transaction
    {
        #region Static members
        public static bool TryCreateNonFungibleTransaction(NonFungibleAsset asset,
            ISupportsNonFungible sender,
            ISupportsNonFungible reciever,
            out NonFungibleAssetTransaction? newTransaction)
        {
            try
            {
                newTransaction = new NonFungibleAssetTransaction(asset, sender, reciever);
                return true;
            }
            catch (Exception)
            {
                newTransaction = null;
                return false;
            }
        }
        #endregion

        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Constructors
        private NonFungibleAssetTransaction(NonFungibleAsset asset,
            ISupportsNonFungible sender,
            ISupportsNonFungible reciever) : base(asset.Address, sender, reciever, TransactionType.NonFungible)
        {
            if (!sender.OwnsAsset(asset))
                throw new InvalidOperationException("Sender does not own the asset.");

            reciever.AddAsset(asset);
            sender.RemoveAsset(asset);
        }
        #endregion

        #region Methods
        public override bool RevokeTransaction(IWallet caller)
        {
            if(base.RevokeTransaction(caller))
            {
                AdvancedWallet sender = (AdvancedWallet)_sender;
                AdvancedWallet reciever = (AdvancedWallet)_reciever;

                sender.RevokeNonFungibleTransaction(this);
                reciever.RevokeNonFungibleTransaction(this);
                return true;
            }
            return false;
        }
        #endregion
    }
}
