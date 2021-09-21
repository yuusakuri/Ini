using System.Collections;
using System.Collections.Generic;

namespace Yuu.Ini
{
    /// <summary>
    /// Represents a collection of INI nodes.
    /// </summary>
    public class IniNodeList : IIniNodeList
    {
        #region Fields

        private readonly List<IniNode> _nodes;

        #endregion

        #region ctor

        /// <inheritdoc/>
        internal IniNodeList()
        {
            _nodes = new List<IniNode>();
        }

        #endregion

        #region Index

        /// <summary>
        /// Gets or sets the element at the given index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get or set.</param>
        /// <returns>The element at the given index.</returns>
        public IniNode this[int index]
        {
            get => _nodes[index];
            set => _nodes[index] = value;
        }

        IIniNode IIniNodeList.this[int index] => (IIniNode)this[index];

        #endregion

        #region Public Properties

        /// <inheritdoc/>
        public int Length => _nodes.Count;

        #endregion

        #region Non-Public Methods

        internal void Add(IniNode node) => _nodes.Add(node);

        internal void AddRange(IniNodeList nodeList) => _nodes.AddRange(nodeList._nodes);

        internal void Insert(int index, IniNode node) => _nodes.Insert(index, node);

        internal void Remove(IniNode node) => _nodes.Remove(node);

        internal void RemoveAt(int index) => _nodes.RemoveAt(index);

        internal void Clear() => _nodes.Clear();

        internal bool Contains(IniNode node) => _nodes.Contains(node);

        #endregion

        #region IEnumerable Implementation

        /// <inheritdoc/>
        public List<IniNode>.Enumerator GetEnumerator() => _nodes.GetEnumerator();

        IEnumerator<IIniNode> IEnumerable<IIniNode>.GetEnumerator() => _nodes.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _nodes.GetEnumerator();

        #endregion
    }
}
