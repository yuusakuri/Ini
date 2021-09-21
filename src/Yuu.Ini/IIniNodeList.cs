using System.Collections.Generic;

namespace Yuu.Ini
{
    /// <summary>
    /// Represents a collection of INI nodes.
    /// </summary>
    public interface IIniNodeList : IEnumerable<IIniNode>
    {
        /// <summary>
        /// Returns an node in this list by its index, or throws an exception.
        /// </summary>
        /// <param name="index">
        /// The 0-based index.
        /// </param>
        /// <returns>
        /// The node at the given index.
        /// </returns>
        IIniNode this[int index] { get; }

        /// <summary>
        /// Gets the number of nodes in this list.
        /// </summary>
        int Length { get; }
    }
}
