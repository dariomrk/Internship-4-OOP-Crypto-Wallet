using Internship_4_OOP_Crypto_Wallet.Classes.Wallets;
using Internship_4_OOP_Crypto_Wallet.Enums;
using static Internship_4_OOP_Crypto_Wallet.Data.Predefined;
using static Internship_4_OOP_Crypto_Wallet.Utils.Helpers;
namespace Internship_4_OOP_Crypto_Wallet
{
    public class Program
    {
        static void Main()
        {
            foreach (BaseWallet w in wallets)
            {
                Console.WriteLine(w);
            }
            foreach (BaseWallet w in wallets)
            {
                w.IncreaseAssetAmount(fungibleAssets[2], 100);
                Console.WriteLine(w) ;
            }
            foreach (BaseWallet w in wallets)
            {
                w.IncreaseAssetAmount(fungibleAssets[2], 100);
                Console.WriteLine(w);
            }
        }
    }
}