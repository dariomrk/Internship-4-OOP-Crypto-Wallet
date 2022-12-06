﻿using Internship_4_OOP_Crypto_Wallet.Classes.Assets;
using Internship_4_OOP_Crypto_Wallet.Utils;
using Internship_4_OOP_Crypto_Wallet.Interfaces;
using Internship_4_OOP_Crypto_Wallet.Classes.Wallets;
using static Internship_4_OOP_Crypto_Wallet.Enums.Types;

namespace Internship_4_OOP_Crypto_Wallet.Classes.Transactions
{
    public sealed class FungibleAssetTransaction : Transaction
    {
        #region Static members
        public static bool TryCreateFungibleTransaction(decimal amount,
            FungibleAsset asset,
            ISupportsFungible sender,
            ISupportsFungible reciever,
            out FungibleAssetTransaction? newTransaction)
        {
            try
            {
                newTransaction = new FungibleAssetTransaction(amount, asset, sender, reciever);
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
        private decimal _balanceSenderBefore, _balanceSenderAfter;
        private decimal _balanceRecieverBefore, _balanceRecieverAfter;
        #endregion

        #region Properties
        public decimal BalanceSenderBefore => _balanceSenderBefore;
        public decimal BalanceSenderAfter => _balanceSenderAfter;
        public decimal BalanceRecieverBefore => _balanceRecieverBefore;
        public decimal BalanceRecieverAfter => _balanceRecieverAfter;
        #endregion

        #region Constructors
        private FungibleAssetTransaction(decimal amount, FungibleAsset asset,
            ISupportsFungible sender,
            ISupportsFungible reciever) : base(asset.Address, sender, reciever, TransactionType.Fungible)
        {
            if (amount < 0)
                throw new InvalidOperationException("Sender is not able to send a negative amount.");

            _balanceSenderBefore = Helpers.FindAmount(asset.Address, sender);
            _balanceRecieverBefore = Helpers.FindAmount(asset.Address, reciever);

            if (!sender.CanCoverAssetAmount(asset, amount))
                throw new InvalidOperationException("Sender is not able to cover the cost of this transaction.");

            reciever.IncreaseAssetAmount(asset, amount);
            sender.ReduceAssetAmount(asset, amount);

            _balanceSenderAfter = Helpers.FindAmount(asset.Address, sender);
            _balanceRecieverAfter = Helpers.FindAmount(asset.Address, reciever);
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
