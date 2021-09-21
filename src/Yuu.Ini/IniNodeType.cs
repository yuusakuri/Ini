namespace Yuu.Ini
{
    /// <summary>
    /// Defines the different INI node types.
    /// </summary>
    public enum IniNodeType
    {
        /// <summary>
        /// A INI document node.
        /// </summary>
        IniDocument,

        /// <summary>
        /// A INI section node.
        /// </summary>
        IniSection,

        /// <summary>
        /// A INI comment node.
        /// </summary>
        IniComment,

        /// <summary>
        /// A INI parameter node.
        /// </summary>
        IniParameter
    }
}
