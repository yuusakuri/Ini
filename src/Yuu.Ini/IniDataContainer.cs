using System.Linq;
using System.Collections.Generic;

namespace Yuu.Ini
{
    /// <summary>
    /// Represents a INI data container node.
    /// </summary>
    public abstract class IniDataContainer : IniNode, IIniDataContainer
    {
        #region ctor

        /// <inheritdoc/>
        protected IniDataContainer(IniNodeType nodeType, IList<IniNodeType> allowedNodeTypes, IniParserConfiguration configuration) : base(nodeType, allowedNodeTypes, configuration) { }

        #endregion

        #region Public Methods

        /// <inheritdoc/>
        public abstract List<IniParameter> GetParameters();

        /// <inheritdoc/>
        public abstract List<IniParameter> GetParameters(string key);

        /// <inheritdoc/>
        public abstract List<IniComment> GetComments();

        /// <inheritdoc/>
        public virtual List<IGrouping<string, IniParameter>> GetDuplicateParameterGroups()
        {
            var nodeGroups = this.GetParameters()
                .GroupBy(aParameter => aParameter.Key)
                .Where(aGroup => aGroup.Count() > 1)
                .ToList();

            return nodeGroups;
        }

        #endregion
    }
}
