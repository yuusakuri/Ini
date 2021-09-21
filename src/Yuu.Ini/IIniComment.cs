namespace Yuu.Ini
{
    /// <summary>
    /// Represents a INI comment node.
    /// </summary>
    public interface IIniComment : IIniNode
    {
        /// <summary>
        /// Gets the Comment string.
        /// </summary>
        string Value { get; set; }
    }
}
