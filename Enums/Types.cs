namespace Internship_4_OOP_Crypto_Wallet.Enums
{
    public static class Types
    {
        public enum WalletType
        {
            BitcoinWallet,
            EthereumWallet,
            SolanaWallet,
        }
        public enum AssetType
        {
            Fungible,
            NonFungible
        }

        public enum TransactionType
        {
            Fungible,
            NonFungible,
        }
    }
}
