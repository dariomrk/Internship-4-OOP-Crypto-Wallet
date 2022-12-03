using Internship_4_OOP_Crypto_Wallet.Classes.Assets;
using Internship_4_OOP_Crypto_Wallet.Classes.Wallets;
using Internship_4_OOP_Crypto_Wallet.Interfaces;
using static Internship_4_OOP_Crypto_Wallet.Utils.Helpers;

namespace Internship_4_OOP_Crypto_Wallet.Data
{
    public static class Predefined
    {
        public static FungibleAsset[] fungibleAssets = new FungibleAsset[]
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

        public static NonFungibleAsset[] nonFungibleAssets = new NonFungibleAsset[]
        {
            new NonFungibleAsset("Cel Mates by Mcbess",
                FindByLabel(fungibleAssets,
                    "ETH")!,
                0.45m),
            new NonFungibleAsset("Cel Mates Crime Reports",
                FindByLabel(fungibleAssets,
                    "ETH")!,
                0.65m
                ),
            new NonFungibleAsset("Mystery of Chessboxing by anon",
                FindByLabel(fungibleAssets,
                    "ETH")!,
                0.1m
                ),
            new NonFungibleAsset("Non-Fungible Moons",
                FindByLabel(fungibleAssets,
                    "ETH")!,
                0.15m
                ),
            new NonFungibleAsset("Cel Mates Hello World",
                FindByLabel(fungibleAssets,
                    "ETH")!,
                0.30m
                ),
            new NonFungibleAsset("Crypto Unicorns Market",
                FindByLabel(fungibleAssets,
                    "MATIC")!,
                0.01m
                ),
            new NonFungibleAsset("Crypto Unicorns Land Market",
                FindByLabel(fungibleAssets,
                    "MATIC")!,
                0.03m
                ),
            new NonFungibleAsset("Baby BAB Family",
                FindByLabel(fungibleAssets,
                    "BNB")!,
                0.06m
                ),
            new NonFungibleAsset("FireFoxNFTs",
                FindByLabel(fungibleAssets,
                    "BNB")!,
                0.65m
                ),
            new NonFungibleAsset("YuliMysteryBox",
                FindByLabel(fungibleAssets,
                    "BNB")!,
                7m
                ),
            new NonFungibleAsset("Mutant Ape Yacht Club",
                FindByLabel(fungibleAssets,
                    "ETH")!,
                13.75m),
            new NonFungibleAsset("Bored Ape Yacht Club",
                FindByLabel(fungibleAssets,
                    "ETH")!,
                68.9m),
            new NonFungibleAsset("Azuki",
                FindByLabel(fungibleAssets,
                    "ETH")!,
                11.49m),
            new NonFungibleAsset("Abstraction by anon",
                FindByLabel(fungibleAssets,
                    "ETH")!,
                1.45m),
            new NonFungibleAsset("The Memes by 6529",
                FindByLabel(fungibleAssets,
                    "ETH")!,
                0.25m),
            new NonFungibleAsset("Valhalla",
                FindByLabel(fungibleAssets,
                    "ETH")!,
                0.74m),
            new NonFungibleAsset("Doodles",
                FindByLabel(fungibleAssets,
                    "ETH")!,
                7m),
            new NonFungibleAsset("Bored Ape Kennel Club",
                FindByLabel(fungibleAssets,
                    "ETH")!,
                6.2m),
            new NonFungibleAsset("Pudgy Penguins",
                FindByLabel(fungibleAssets,
                    "ETH")!,
                3.5m),
            new NonFungibleAsset("Decentraland",
                FindByLabel(fungibleAssets,
                    "ETH")!,
                1.3m),
        };

        public static IWallet[] wallets = new IWallet[]
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
    }
}
