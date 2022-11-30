namespace Internship_4_OOP_Crypto_Wallet.Interfaces
{
    public interface ISupportsNonFungible
    {
        public List<Guid> OwnedNonFungibleAssets { get; }
    }
}
