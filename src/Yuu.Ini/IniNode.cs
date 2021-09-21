using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Yuu.Ini
{
    /// <summary>
    /// Represents a INI node.
    /// </summary>
    public abstract class IniNode : IIniNode
    {
        #region Fields

        private readonly IniNodeType _nodeType;
        private readonly ReadOnlyCollection<IniNodeType> _allowedChildNodeTypes;
        private IniParserConfiguration _configuration;
        private IniNode? _parentNode;
        private IniNodeList _childNodes;

        #endregion

        #region ctor

        /// <inheritdoc/>
        protected IniNode(IniNodeType nodeType, IList<IniNodeType> allowedNodeTypes, IniParserConfiguration configuration)
        {
            this._nodeType = nodeType;
            this._allowedChildNodeTypes = new ReadOnlyCollection<IniNodeType>(allowedNodeTypes);
            this._configuration = configuration;
            this._childNodes = new IniNodeList();
        }

        #endregion

        #region Public Properties

        /// <inheritdoc/>
        public IniNodeType NodeType => this._nodeType;

        /// <inheritdoc/>
        public ReadOnlyCollection<IniNodeType> AllowedChildNodeTypes => this._allowedChildNodeTypes;

        /// <inheritdoc/>
        public IniNode? ParentNode
        {
            get => this._parentNode;
            internal set => this._parentNode = value;
        }

        /// <inheritdoc/>
        public IniParserConfiguration Configuration
        {
            get { return this._configuration; }
            internal set
            {
                this._configuration = value;
            }
        }

        /// <inheritdoc/>
        public bool HasChildNodes => this.ChildNodes.Length != 0;

        /// <inheritdoc/>
        public IniNodeList ChildNodes => this._childNodes;

        IIniNode? IIniNode.ParentNode => this._parentNode;

        IIniNodeList IIniNode.ChildNodes => this._childNodes;

        #endregion

        #region Public Methods

        /// <inheritdoc/>
        public virtual void Add(IIniNode node)
        {
            var indexToInsert = this.ChildNodes.Length;

            this.Insert(indexToInsert, node);
        }

        /// <inheritdoc/>
        public virtual void AddRange(IEnumerable<IIniNode> nodes)
        {
            nodes
                .ToList()
                .ForEach(aNode => this.Add(aNode));
        }

        /// <inheritdoc/>
        public virtual void Insert(int index, IIniNode node)
        {
            var cNode = (IniNode)node;

            IniNode.ValidateNodeType(cNode, this.AllowedChildNodeTypes);
            cNode.ParentNode = this;
            cNode.Configuration = this.Configuration;

            this.ChildNodes.Insert(index, cNode);
        }

        /// <inheritdoc/>
        public virtual void Remove()
        {
            if (this.ParentNode == null) throw new ArgumentNullException(nameof(this.ParentNode));
            this.ParentNode.Remove(this);
        }

        /// <inheritdoc/>
        public virtual void Remove(IIniNode node) => this.ChildNodes.Remove((IniNode)node);

        /// <inheritdoc/>
        public virtual void RemoveAt(int index) => this.ChildNodes.RemoveAt(index);

        /// <inheritdoc/>
        public virtual void Clear() => this.ChildNodes.Clear();

        /// <summary>
        /// Converts this node to an INI-formatted string.
        /// </summary>
        /// <returns>
        /// An INI-formatted string.
        /// </returns>
        public override abstract string? ToString();

        #endregion

        #region Non-Public Methods

        internal static bool IsValidNodeType(IniNode node, IEnumerable<IniNodeType> nodeTypes)
        {
            return nodeTypes.Contains(node.NodeType);
        }

        internal static bool ValidateNodeType(IniNode node, IEnumerable<IniNodeType> nodeTypes)
        {
            if (!IniNode.IsValidNodeType(node, nodeTypes)) throw new FormatException("The given node type is not allowed.");
            return true;
        }

        #endregion
    }
}
