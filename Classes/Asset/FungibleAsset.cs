namespace Internship_4_OOP_Crypto_Wallet.Classes.Asset
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
                    throw new ArgumentNullException("Label property cannot be an empty string.");
                if (Asset.TryAddNameOrLabel(value))
                {
                    _label = value;
                    return;
                }
                // In case the Name string is already added to the Asset._namesLabels hashSet.
                Asset.RemoveNameOrLabel(Name);
                throw new InvalidOperationException("Label property must be unique.");
            }
        }
        #endregion

        #region Constructors
        public FungibleAsset(string name, decimal value, string label) : base(name, value)
        {
            Label = label;
        }
        #endregion

        #region Methods
        #endregion
    }
}
