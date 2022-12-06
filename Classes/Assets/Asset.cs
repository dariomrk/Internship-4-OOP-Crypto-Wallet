using static Internship_4_OOP_Crypto_Wallet.Enums.Types;

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
            return _allAssets.ContainsKey(assetAddress) ? _allAssets[assetAddress] : null;
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
        private string _name;
        protected decimal _previousValueUSD;
        protected decimal _currentValueUSD;
        #endregion

        #region Properties
        public AssetType Type { get; }
        public Guid Address { get; }
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name property cannot be an empty string.");
                }

                if (Asset.TryAddNameOrLabel(value))
                {
                    _name = value;
                    return;
                }
                throw new InvalidOperationException("Name property must be unique.");
            }
        }
        public virtual decimal ValueUSD => _currentValueUSD;

        public virtual decimal PreviousValueUSD => _previousValueUSD;
        #endregion

        #region Constructors
        protected Asset(string name, decimal value, AssetType type)
        {
            Type = type;
            _previousValueUSD = 0m;
            _currentValueUSD = value;
            Name = name;
            Address = Guid.NewGuid();
            _allAssets.Add(Address, this);
        }
        #endregion

        #region Methods
        public virtual void ViewedValue()
        {
            _previousValueUSD = _currentValueUSD;
        }

        public virtual void RandomlyChangeValue()
        {
            _currentValueUSD = GetRandomValue(_currentValueUSD);
        }

        protected decimal GetRandomValue(decimal value)
        {
            Random r = new();
            double d = r.NextDouble();
            double final = (d * (0.025 + 0.025)) - 0.025;
            return value +  (value * (decimal)final);
        }

        public override string ToString()
        {
            return $"Address: {Address}\n" +
                $"Name: {Name}";
        }
        #endregion
    }
}
