namespace Yuu.Ini
{
    /// <summary>
    /// Represents a INI parameter node.
    /// </summary>
    public interface IIniParameter : IIniNode
    {
        /// <summary>
        /// Gets the Key of Key-Value Parameter.
        /// </summary>
        string Key { get; set; }

        /// <summary>
        /// Gets the Value of Key-Value Parameter.
        /// </summary>
        string Value { get; set; }
    }
}
