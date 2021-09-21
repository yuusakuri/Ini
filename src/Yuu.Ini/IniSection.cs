using System;
using System.Linq;
using System.Collections.Generic;

namespace Yuu.Ini
{
    /// <summary>
    /// Represents a INI section node.
    /// </summary>
    public class IniSection : IniNode, IIniSection
    {
        #region Fields

        private string _name;

        #endregion

        #region ctor

        /// <inheritdoc/>
        public IniSection(string name, IniParserConfiguration configuration) : base(IniNodeType.IniSection, new List<IniNodeType> { IniNodeType.IniParameter, IniNodeType.IniComment }, configuration)
        {
            this._name = "";
            this.Name = name;
        }

        /// <inheritdoc/>
        public IniSection(string name) : this(name, new IniParserConfiguration()) { }

        #endregion

        #region Public Properties

        /// <inheritdoc/>
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                if (value != "" && !IniParser.VerifyByRegex(value, $@"^{this.Configuration.SectionNameRegex}$")) return;
                value.Trim();

                this._name = value;
            }
        }

        /// <inheritdoc/>
        public bool IsNamedSection => this.Name != "";

        #endregion

        #region Public Methods

        /// <inheritdoc/>
        public List<IniParameter> GetParameters()
        {
            var nodes = this.ChildNodes
                .Where(aNode => aNode.NodeType == IniNodeType.IniParameter)
                .Select(aNode => (IniParameter)aNode)
                .ToList();

            return nodes;
        }

        /// <inheritdoc/>
        public List<IniParameter> GetParameters(string key)
        {
            var nodes = this.GetParameters()
                .Where(aNode => aNode.Key == key)
                .ToList();

            return nodes;
        }

        /// <inheritdoc/>
        public List<IniComment> GetComments()
        {
            var nodes = this.ChildNodes
                .Where(aNode => aNode.NodeType == IniNodeType.IniComment)
                .Select(aNode => (IniComment)aNode)
                .ToList();

            return nodes;
        }

        /// <inheritdoc/>
        public void AddParameter(string key, string value)
        {
            var node = new IniParameter(key, value, this.Configuration);
            this.Add(node);
        }

        /// <inheritdoc/>
        public void AddComment(string value)
        {
            var node = new IniComment(value, this.Configuration);
            this.Add(node);
        }

        /// <inheritdoc/>
        public void InsertParameter(int index, string key, string value)
        {
            var node = new IniParameter(key, value, this.Configuration);
            this.Insert(index, node);
        }

        /// <inheritdoc/>
        public void InsertComment(int index, string value)
        {
            var node = new IniComment(value, this.Configuration);
            this.Insert(index, node);
        }

        /// <inheritdoc/>
        public override string? ToString()
        {
            var contents = new List<string>();

            var sectionDefinitionString = this.SectionDefinitionToString();
            if (sectionDefinitionString != null)
            {
                contents.Add(sectionDefinitionString);
            }

            var childNodesString = this.ChildNodesToString();
            if (childNodesString != null)
            {
                contents.Add(childNodesString);
            }

            if (contents.Count == 0)
            {
                return null;
            }

            return String.Join(this.Configuration.NewLine, contents);
        }

        #endregion

        #region Non-Public Methods

        /// <summary>
        /// Gets section definition string.
        /// Returns null if this section name is empty.
        /// </summary>
        internal string? SectionDefinitionToString()
        {
            if (!this.IsNamedSection) return null;

            return (
                this.Configuration.SectionStartString +
                this.Name +
                this.Configuration.SectionEndString
            );
        }

        /// <summary>
        /// Gets the string of converted child nodes.
        /// </summary>
        internal string? ChildNodesToString()
        {
            if (!this.HasChildNodes) return null;

            var contents = this.ChildNodes
                .Select(aNode => aNode.ToString());

            return String.Join(this.Configuration.NewLine, contents);
        }

        #endregion
    }
}
