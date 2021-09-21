using System;
using System.Text.RegularExpressions;

namespace Yuu.Ini
{
    /// <summary>
    /// Represents a configuration of INI parser.
    /// </summary>
    public class IniParserConfiguration
    {
        #region Fields

        private string _newLine;
        private string _newLineRegex;
        private bool _newLineAtEndOfFile;
        private string _parameterSpacer;
        private string _sectionStartString;
        private string _sectionEndString;
        private string _sectionNameRegex;
        private string _parameterKeyRegex;
        private string _parameterValueRegex;
        private char _parameterDelimiter;
        private string _commentLineRegex;

        #endregion

        #region ctor

        /// <inheritdoc/>
        public IniParserConfiguration()
        {
            this._newLine = "";
            this._newLineRegex = "";
            this._parameterSpacer = "";
            this._sectionStartString = "";
            this._sectionEndString = "";
            this._sectionNameRegex = "";
            this._parameterKeyRegex = "";
            this._parameterValueRegex = "";
            this._commentLineRegex = "";
            this.NewLine = "\n";
            this.NewLineRegex = @"\r\n|\r|\n";
            this.NewLineAtEndOfFile = true;
            this.SectionStartString = @"[";
            this.SectionEndString = @"]";
            this.SectionNameRegex = @"\s*[^\[\]]+\s*";
            this.ParameterKeyRegex = @"[^;=\r\n]*[^;=\r\n\s]+";
            this.ParameterValueRegex = @"[^\r\n]*";
            this.ParameterDelimiter = '=';
            this.ParameterSpacer = @" ";
            this.CommentLineRegex = @"^(\s*|(;|\#)[^\r\n]*)$";
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Line break string.
        /// </summary>
        public string NewLine
        {
            get
            {
                return this._newLine;
            }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                this._newLine = value;
            }
        }

        /// <summary>
        /// Line break regex pattern.
        /// </summary>
        public string NewLineRegex
        {
            get
            {
                return this._newLineRegex;
            }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                this._newLineRegex = value;
            }
        }

        /// <summary>
        /// Whether the end of the document is a newline.
        /// </summary>
        public bool NewLineAtEndOfFile
        {
            get
            {
                return this._newLineAtEndOfFile;
            }
            set
            {
                this._newLineAtEndOfFile = value;
            }
        }

        /// <summary>
        /// Whitespace before and after the delimiter in the parameter line.
        /// </summary>
        public string ParameterSpacer
        {
            get
            {
                return this._parameterSpacer;
            }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                this._parameterSpacer = value;
            }
        }

        /// <summary>
        /// The section start string.
        /// </summary>
        public string SectionStartString
        {
            get
            {
                return this._sectionStartString;
            }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                this._sectionStartString = value;
            }
        }

        /// <summary>
        /// The section end string.
        /// </summary>
        public string SectionEndString
        {
            get
            {
                return this._sectionEndString;
            }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                this._sectionEndString = value;
            }
        }

        /// <summary>
        /// The section name regex pattern.
        /// </summary>
        public string SectionNameRegex
        {
            get
            {
                return this._sectionNameRegex;
            }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                this._sectionNameRegex = value;
            }
        }

        /// <summary>
        /// The section line regex pattern.
        /// </summary>
        public string SectionLineRegex
        {
            get
            {
                return @"^\s*" + Regex.Escape(this.SectionStartString) + $@"(?<SectionName>{this.SectionNameRegex})" + Regex.Escape(this.SectionEndString) + @"\s*$";
            }
        }

        /// <summary>
        /// The parameter key regex pattern.
        /// </summary>
        public string ParameterKeyRegex
        {
            get
            {
                return this._parameterKeyRegex;
            }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                this._parameterKeyRegex = value;
            }
        }

        /// <summary>
        /// The parameter value regex pattern.
        /// </summary>
        public string ParameterValueRegex
        {
            get
            {
                return this._parameterValueRegex;
            }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                this._parameterValueRegex = value;
            }
        }

        /// <summary>
        /// The parameter key / value delimiter.
        /// </summary>
        public char ParameterDelimiter
        {
            get
            {
                return this._parameterDelimiter;
            }
            set
            {
                this._parameterDelimiter = value;
            }
        }

        /// <summary>
        /// The parameter line regex.
        /// </summary>
        public string ParameterLineRegex
        {
            get
            {
                return @"^\s*" + $@"(?<Key>{this.ParameterKeyRegex})" + $@"({Regex.Escape(this.ParameterSpacer)})*" + Regex.Escape(this.ParameterDelimiter.ToString()) + $@"({Regex.Escape(this.ParameterSpacer)})*" + $@"(?<Value>{this.ParameterValueRegex})" + @"\s*$";
            }
        }

        /// <summary>
        /// The comment line regex.
        /// </summary>
        public string CommentLineRegex
        {
            get
            {
                return this._commentLineRegex;
            }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                this._commentLineRegex = value;
            }
        }

        #endregion
    }
}
