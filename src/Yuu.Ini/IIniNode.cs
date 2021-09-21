using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Yuu.Ini
{
    /// <summary>
    /// Represents a INI node.
    /// </summary>
    public interface IIniNode
    {
        /// <summary>
        /// Gets the type of this node.
        /// </summary>
        IniNodeType NodeType { get; }

        /// <summary>
        /// Gets the types of nodes that can be included in ChildNodes.
        /// </summary>
        ReadOnlyCollection<IniNodeType> AllowedChildNodeTypes { get; }

        /// <summary>
        /// Gets the parent node of this node.
        /// </summary>
        IIniNode? ParentNode { get; }

        /// <summary>
        /// Gets the parser configuration.
        /// It can be changed even after the instance is created.
        /// </summary>
        IniParserConfiguration Configuration { get; }

        /// <summary>
        /// Gets the node list containing all the children of this node.
        /// </summary>
        IIniNodeList ChildNodes { get; }

        /// <summary>
        /// Returns true if this node has one or more child nodes, false otherwise.
        /// </summary>
        bool HasChildNodes { get; }

        /// <summary>
        /// Adds the given node to the end of the child nodes.
        /// </summary>
        /// <param name="node">
        /// The node to add.
        /// </param>
        void Add(IIniNode node);

        /// <summary>
        /// Adds the given nodes to the end of the child nodes.
        /// </summary>
        /// <param name="nodes">
        /// The nodes to add.
        /// </param>
        void AddRange(IEnumerable<IIniNode> nodes);

        /// <summary>
        /// Inserts an node into the child nodes at the given index.
        /// </summary>
        /// <param name="index">
        /// The index of the node to insert.
        /// </param>
        /// <param name="node">
        /// The node to insert.
        /// </param>
        void Insert(int index, IIniNode node);

        /// <summary>
        /// Removes this node.
        /// </summary>
        void Remove();

        /// <summary>
        /// Removes the given node of the child nodes.
        /// </summary>
        /// <param name="node">
        /// The node to remove.
        /// </param>
        void Remove(IIniNode node);

        /// <summary>
        /// Removes the node at the given index of the child nodes.
        /// </summary>
        /// <param name="index">
        /// The index of the node to remove.
        /// </param>
        void RemoveAt(int index);

        /// <summary>
        /// Clear the child nodes.
        /// </summary>
        void Clear();
    }
}
