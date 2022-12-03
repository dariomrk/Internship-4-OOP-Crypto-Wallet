using Internship_4_OOP_Crypto_Wallet.Utils;
using static Internship_4_OOP_Crypto_Wallet.Data.Predefined;
namespace Internship_4_OOP_Crypto_Wallet
{
    public class Program
    {
        static void Main()
        {
            // TODO Remove later, testing purposes only!
            Console.WriteLine($"Fungible assets: {fungibleAssets.Length}");
            foreach (var f in fungibleAssets)
                Console.WriteLine(f.Address + "\t" + f.Name.PadRight(20)  + "\t" + f.Label.PadRight(5) + "\t" + f.ValueUSD + " $");
            Console.WriteLine();
            Console.WriteLine($"Non fungible assets: {nonFungibleAssets.Length}");
            foreach (var n in nonFungibleAssets)
                Console.WriteLine(n.Address + "\t" + n.Name.PadRight(30) + "\t" + n.ValueUSD + " $");
            Console.WriteLine();
            Console.WriteLine($"Wallets: {wallets.Length}");
            foreach (var w in wallets)
                Console.WriteLine(w);

            Console.WriteLine(Helpers.CalculatePercentDifference(100,200));
            Console.WriteLine(Helpers.CalculatePercentDifference(100, 80));
            Console.WriteLine(Helpers.CalculatePercentDifference(100, 150));

        }
    }
}