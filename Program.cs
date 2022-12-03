using static Internship_4_OOP_Crypto_Wallet.Data.Predefined;
namespace Internship_4_OOP_Crypto_Wallet
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine($"Fungible assets: {fungibleAssets.Length}");
            foreach (var f in fungibleAssets)
                Console.WriteLine(f.Address + "\t" + f.Name.PadRight(20)  + "\t" + f.Label);
            Console.WriteLine();
            Console.WriteLine($"Non fungible assets: {nonFungibleAssets.Length}");
            foreach (var n in nonFungibleAssets)
                Console.WriteLine(n.Address + "\t" + n.Name);
            Console.WriteLine();
            Console.WriteLine($"Wallets: {wallets.Length}");
            foreach (var w in wallets)
                Console.WriteLine(w);
        }
    }
}