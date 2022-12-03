using Internship_4_OOP_Crypto_Wallet.Classes.Assets;
using Internship_4_OOP_Crypto_Wallet.Classes.Wallets;
using Internship_4_OOP_Crypto_Wallet.Interfaces;
using static Internship_4_OOP_Crypto_Wallet.Utils.Helpers;

namespace Internship_4_OOP_Crypto_Wallet.Data
{
    public static class Data
    {
        public static IWallet[] predefinedWallets = new IWallet[]
        {
            new BitcoinWallet(),
            new BitcoinWallet(),
            new BitcoinWallet(),
            new EthereumWallet(),
            new EthereumWallet(),
            new EthereumWallet(),
            new SolanaWallet(),
            new SolanaWallet(),
            new SolanaWallet(),
        };

        public static FungibleAsset[] predefinedFungibleAssets = new FungibleAsset[]
        {
            new FungibleAsset("Bitcoin",16376m,"BTC"),
            new FungibleAsset("Ethereum",1207m,"ETH"),
            new FungibleAsset("Tether",1m,"USDT"),
            new FungibleAsset("Binance coin",299m,"BNB"),
            new FungibleAsset("USD coin",1m,"USDC"),
            new FungibleAsset("Ripple", 0.389m,"XRP"),
            new FungibleAsset("Dogecoin",0.1001m,"DOGE"),
            new FungibleAsset("Cardano",0.3077m,"ADA"),
            new FungibleAsset("Polygon",0.8315m,"MATIC"),
            new FungibleAsset("Polkadot",5.26m,"DOT"),
        };

        public static NonFungibleAsset[] predefinedNonFungibleAssets = new NonFungibleAsset[]
        {
            new NonFungibleAsset("Cel Mates by Mcbess",
                FindByLabel(predefinedFungibleAssets,
                    "ETH")!,
                0.45m),
            new NonFungibleAsset("Cel Mates Crime Reports",
                FindByLabel(predefinedFungibleAssets,
                    "ETH")!,
                0.65m
                ),
            new NonFungibleAsset("Mystery of Chessboxing by anon",
                FindByLabel(predefinedFungibleAssets,
                    "ETH")!,
                0.1m
                ),
            new NonFungibleAsset("Non-Fungible Moons",
                FindByLabel(predefinedFungibleAssets,
                    "ETH")!,
                0.15m
                ),
            new NonFungibleAsset("Cel Mates Crime Reports",
                FindByLabel(predefinedFungibleAssets,
                    "ETH")!,
                0.65m
                ),
            new NonFungibleAsset("Crypto Unicorns Market",
                FindByLabel(predefinedFungibleAssets,
                    "MATIC")!,
                0.01m
                ),
            new NonFungibleAsset("Crypto Unicorns Land Market",
                FindByLabel(predefinedFungibleAssets,
                    "MATIC")!,
                0.03m
                ),
            new NonFungibleAsset("Baby BAB Family",
                FindByLabel(predefinedFungibleAssets,
                    "BNB")!,
                0.06m
                ),
            new NonFungibleAsset("FireFoxNFTs",
                FindByLabel(predefinedFungibleAssets,
                    "BNB")!,
                0.65m
                ),
            new NonFungibleAsset("YuliMysteryBox",
                FindByLabel(predefinedFungibleAssets,
                    "BNB")!,
                7m
                ),
            new NonFungibleAsset("Mutant Ape Yacht Club",
                FindByLabel(predefinedFungibleAssets,
                    "ETH")!,
                13.75m),
            new NonFungibleAsset("Bored Ape Yacht Club",
                FindByLabel(predefinedFungibleAssets,
                    "ETH")!,
                68.9m),
            new NonFungibleAsset("Azuki",
                FindByLabel(predefinedFungibleAssets,
                    "ETH")!,
                11.49m),
            new NonFungibleAsset("Abstraction by anon",
                FindByLabel(predefinedFungibleAssets,
                    "ETH")!,
                1.45m),
            new NonFungibleAsset("The Memes by 6529",
                FindByLabel(predefinedFungibleAssets,
                    "ETH")!,
                0.25m),
            new NonFungibleAsset("Valhalla",
                FindByLabel(predefinedFungibleAssets,
                    "ETH")!,
                0.74m),
            new NonFungibleAsset("Doodles",
                FindByLabel(predefinedFungibleAssets,
                    "ETH")!,
                7m),
            new NonFungibleAsset("Bored Ape Kennel Club",
                FindByLabel(predefinedFungibleAssets,
                    "ETH")!,
                6.2m),
            new NonFungibleAsset("Pudgy Penguins",
                FindByLabel(predefinedFungibleAssets,
                    "ETH")!,
                3.5m),
            new NonFungibleAsset("Decentraland",
                FindByLabel(predefinedFungibleAssets,
                    "ETH")!,
                1.3m),
        };

    }
}
