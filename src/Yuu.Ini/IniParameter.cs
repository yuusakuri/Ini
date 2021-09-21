using System;
using System.Collections.Generic;

namespace Yuu.Ini
{
    /// <summary>
    /// Represents a INI parameter node.
    /// </summary>
    public class IniParameter : IniNode, IIniParameter
    {
        #region Fields

        private string _key;
        private string _value;

        #endregion

        #region ctor

        /// <inheritdoc/>
        public IniParameter(string key, string value, IniParserConfiguration configuration) : base(IniNodeType.IniParameter, new List<IniNodeType>(), configuration)
        {
            this._key = "";
            this._value = "";
            this.Key = key;
            this.Value = value;
        }

        /// <inheritdoc/>
        public IniParameter(string key, string value) : this(key, value, new IniParserConfiguration()) { }

        #endregion

        #region Public Properties

        /// <inheritdoc/>
        public string Key
        {
            get
            {
                return this._key;
            }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                IniParser.VerifyByRegex(value, this.Configuration.ParameterKeyRegex);
                value.Trim();

                this._key = value;
            }
        }

        /// <inheritdoc/>
        public string Value
        {
            get
            {
                return this._value;
            }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                IniParser.VerifyByRegex(value, this.Configuration.ParameterValueRegex);
                value.Trim();

                this._value = value;
            }
        }

        #endregion

        #region Public Methods

        /// <inheritdoc/>
        public override string ToString()
        {
            return (
                this.Key +
                this.Configuration.ParameterSpacer +
                this.Configuration.ParameterDelimiter +
                this.Configuration.ParameterSpacer +
                this.Value
            ).Trim();
        }

        #endregion
    }
}
