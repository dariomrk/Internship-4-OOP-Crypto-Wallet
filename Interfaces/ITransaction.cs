﻿namespace Internship_4_OOP_Crypto_Wallet.Interfaces
{
    public interface ITransaction
    {
        public Guid Id { get; }
        public Guid AssetAddress { get; }
        public DateTime CreatedAt { get; }
        public Guid Sender { get; }
        public Guid Reciever { get; }
        public bool IsRevoked { get; }
    }

}