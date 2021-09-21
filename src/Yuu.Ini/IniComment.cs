using System;
using System.Collections.Generic;

namespace Yuu.Ini
{
    /// <summary>
    /// Represents a INI comment node.
    /// </summary>
    public class IniComment : IniNode, IIniComment
    {
        private string _value;

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
                IniParser.VerifyByRegex(value, this.Configuration.CommentLineRegex);
                value.Trim();

                this._value = value;
            }
        }

        /// <inheritdoc/>
        public IniComment(string value, IniParserConfiguration configuration) : base(IniNodeType.IniComment, new List<IniNodeType>(), configuration)
        {
            this._value = "";
            this.Value = value;
        }

        /// <inheritdoc/>
        public IniComment(string value) : this(value, new IniParserConfiguration()) { }

        /// <inheritdoc/>
        public override string ToString()
        {
            return this.Value;
        }
    }
}
