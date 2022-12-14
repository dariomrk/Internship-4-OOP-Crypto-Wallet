using Internship_4_OOP_Crypto_Wallet.Classes.Assets;
using Internship_4_OOP_Crypto_Wallet.Classes.Wallets;
using Internship_4_OOP_Crypto_Wallet.Interfaces;
using Internship_4_OOP_Crypto_Wallet.Utils;
using static Internship_4_OOP_Crypto_Wallet.Enums.Types;

namespace Internship_4_OOP_Crypto_Wallet.Classes.Transactions
{
    public sealed class FungibleAssetTransaction : Transaction
    {
        #region Static members
        /// <summary>
        /// Tries to create a fungible asset transaction.
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="asset"></param>
        /// <param name="sender"></param>
        /// <param name="reciever"></param>
        /// <param name="newTransaction"></param>
        /// <returns>Boolean indicating wether the transaction completed successfully.</returns>
        public static bool TryCreateFungibleTransaction(decimal amount,
            FungibleAsset asset,
            ISupportsFungible sender,
            ISupportsFungible reciever,
            out FungibleAssetTransaction? newTransaction)
        {
            newTransaction = null;

            if (amount > sender.Balances.First(x => x.AssetAddress == asset.Address).Amount)
            {
                return false;
            }

            try
            {
                newTransaction = new FungibleAssetTransaction(amount, asset, sender, reciever);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region Fields
        #endregion

        #region Properties
        public decimal BalanceSenderBefore { get; }
        public decimal BalanceSenderAfter { get; }
        public decimal BalanceRecieverBefore { get; }
        public decimal BalanceRecieverAfter { get; }
        #endregion

        #region Constructors
        private FungibleAssetTransaction(decimal amount, FungibleAsset asset,
            ISupportsFungible sender,
            ISupportsFungible reciever) : base(asset.Address, sender, reciever, TransactionType.Fungible)
        {
            if (amount < 0)
            {
                throw new InvalidOperationException("Sender is not able to send a negative amount.");
            }

            BalanceSenderBefore = Helpers.FindAmount(asset.Address, sender);
            BalanceRecieverBefore = Helpers.FindAmount(asset.Address, reciever);

            if (!sender.CanCoverAssetAmount(asset, amount))
            {
                throw new InvalidOperationException("Sender is not able to cover the cost of this transaction.");
            }

            reciever.IncreaseAssetAmount(asset, amount);
            sender.ReduceAssetAmount(asset, amount);

            BalanceSenderAfter = Helpers.FindAmount(asset.Address, sender);
            BalanceRecieverAfter = Helpers.FindAmount(asset.Address, reciever);
        }
        #endregion

        #region Methods
        public override bool RevokeTransaction(IWallet caller)
        {
            if (base.RevokeTransaction(caller))
            {
                BaseWallet sender = (BaseWallet)_sender;
                BaseWallet reciever = (BaseWallet)_reciever;

                sender.RevokeFungibleTransaction(this);
                reciever.RevokeFungibleTransaction(this);
                return true;
            }
            return false;
        }
        #endregion
    }
}
