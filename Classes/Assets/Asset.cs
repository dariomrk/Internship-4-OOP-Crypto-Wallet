using Internship_4_OOP_Crypto_Wallet.Classes.Wallets;
using Internship_4_OOP_Crypto_Wallet.Interfaces;

namespace Internship_4_OOP_Crypto_Wallet.Classes.Assets
{
    public abstract class Asset
    {
        #region Static members
        /// <summary>
        /// Contains all assets.
        /// </summary>
        protected static readonly Dictionary<Guid, Asset> _allAssets = new();

        /// <summary>
        /// Returns an asset object given the address.
        /// </summary>
        /// <param name="assetAddress"></param>
        /// <returns>Reference to the asset object.</returns>
        public static Asset? GetAsset(Guid assetAddress)
        {
            if(_allAssets.ContainsKey(assetAddress))
                return _allAssets[assetAddress];
            return null;
        }

        /// <summary>
        ///  A set of names and labels currently in use.
        /// </summary>
        private static readonly HashSet<string> _namesLabels = new();

        /// <summary>
        /// Check wether the given value is unique, i.e. not in use.
        /// </summary>
        /// <param name="value">Value to check.</param>
        /// <returns>True if the value is unique, false otherwise.</returns>
        protected static bool IsUnique(string value)
        {
            return !_namesLabels.Contains(value);
        }

        /// <summary>
        /// Tries to remove the given value. Used during deletion or modification of a name or label.
        /// </summary>
        /// <param name="value">Value to remove.</param>
        /// <returns>Returns true if the deletion was successful.
        /// If the value was not found i.e element was not deleted it returns false.</returns>
        protected static bool RemoveNameOrLabel(string value)
        {
            return _namesLabels.Remove(value);
        }

        /// <summary>
        /// Tries to add the given value. Used during creation of a new name or label.
        /// </summary>
        /// <param name="value">Value to add.</param>
        /// <returns>Returns true if the value was added, i.e. the value is unique. Otherwise returns false.</returns>
        protected static bool TryAddNameOrLabel(string value)
        {
            return _namesLabels.Add(value);
        }
        #endregion

        #region Fields
        private readonly Guid _address;
        private string _name;
        private decimal _value;
        #endregion

        #region Properties
        public Guid Address => _address;
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Name property cannot be an empty string.");
                if (Asset.TryAddNameOrLabel(value))
                {
                    _name = value;
                    return;
                }
                throw new InvalidOperationException("Name property must be unique.");
            }
        }
        public decimal ValueUSD { get => _value; protected set { _value = value; } }
        #endregion

        #region Constructors
        protected Asset(string name, decimal value)
        {
            _address = Guid.NewGuid();
            Name = name;
            ValueUSD = value;
            _allAssets.Add(this.Address,this);
        }
        #endregion

        #region Methods
        #endregion
    }
}
