using Internship_4_OOP_Crypto_Wallet.Classes.Wallets;
using static Internship_4_OOP_Crypto_Wallet.Enums.Types;
using static Internship_4_OOP_Crypto_Wallet.Utils.Helpers;

namespace Internship_4_OOP_Crypto_Wallet.Classes.Assets
{
    public sealed class FungibleAsset : Asset
    {
        #region Fields
        private string _label;
        #endregion

        #region Properties
        public string Label
        {
            get => _label;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Label property cannot be an empty string.");
                }

                if (Asset.TryAddNameOrLabel(value))
                {
                    _label = value;
                    return;
                }
                // In case the Name string is already added to the Asset._namesLabels hashSet.
                RemoveNameOrLabel(Name);
                throw new InvalidOperationException("Label property must be unique.");
            }
        }
        #endregion

        #region Constructors
        public FungibleAsset(string name, decimal value, string label) : base(name, value, AssetType.Fungible)
        {
            BaseWallet.AddSupport(this);
            Label = label;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            decimal diff = CalculatePercentDifference(PreviousValueUSD, ValueUSD);
            return base.ToString() +
                $"\n" +
                $"Label: {Label}\n" +
                $"Type: Fungible\n" +
                $"Percentage change: {diff:F} %\n" +
                $"Value: 1 {Label} <-> {ValueUSD} $";
        }
        #endregion
    }
}
