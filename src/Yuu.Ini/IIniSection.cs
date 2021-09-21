namespace Yuu.Ini
{
    /// <summary>
    /// Represents a INI section node.
    /// </summary>
    public interface IIniSection : IIniNode, IIniDataContainer
    {
        /// <summary>
        /// Gets this section name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Returns false if the name is empty, true otherwise.
        /// </summary>
        /// <value></value>
        bool IsNamedSection { get; }

        /// <summary>
        /// Create a parameter node and add it to the end of the child nodes.
        /// </summary>
        /// <param name="key">The parameter key.</param>
        /// <param name="value">The parameter value.</param>
        void AddParameter(string key, string value);

        /// <summary>
        /// Create a comment node and add it to the end of the child nodes.
        /// </summary>
        /// <param name="value">The comment value.</param>
        void AddComment(string value);

        /// <summary>
        /// Create a parameter node and insert it into the child nodes at the given index.
        /// </summary>
        /// <param name="index">
        /// The index of the node to insert.
        /// </param>
        /// <param name="key">
        /// The key of new parameter node.
        /// </param>
        /// <param name="value">
        /// The value of new parameter node.
        /// </param>
        void InsertParameter(int index, string key, string value);

        /// <summary>
        /// Create a comment node and insert it into the child nodes at the given index.
        /// </summary>
        /// <param name="index">
        /// The index of the node to insert.
        /// </param>
        /// <param name="value">
        /// The value of new comment node.
        /// </param>
        void InsertComment(int index, string value);
    }
}
