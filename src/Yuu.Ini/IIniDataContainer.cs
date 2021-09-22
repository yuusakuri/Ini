using System.Collections.Generic;
using System.Linq;

namespace Yuu.Ini
{
    /// <summary>
    /// Represents a INI data container node.
    /// </summary>
    public interface IIniDataContainer : IIniNode
    {
        /// <summary>
        /// Gets the all parameter nodes from the child nodes.
        /// </summary>
        List<IniParameter> GetParameters();

        /// <summary>
        /// Gets the parameter nodes with the given name from the child nodes.
        /// </summary>
        List<IniParameter> GetParameters(string key);

        /// <summary>
        /// Gets the all comment nodes from the child nodes.
        /// </summary>
        List<IniComment> GetComments();

        /// <summary>
        /// Gets the groups of parameter with duplicate names.
        /// </summary>
        List<IGrouping<string, IniParameter>> GetDuplicateParameterGroups();
    }
}
