using System.Linq;
using System.Collections.Generic;

namespace Yuu.Ini
{
    /// <summary>
    /// Represents a INI data container node.
    /// </summary>
    public abstract class IniSectionContainer : IniDataContainer, IIniSectionContainer
    {
        #region ctor

        /// <inheritdoc/>
        protected IniSectionContainer(IniNodeType nodeType, IList<IniNodeType> allowedNodeTypes, IniParserConfiguration configuration) : base(nodeType, allowedNodeTypes, configuration) { }

        #endregion

        #region Public Methods

        /// <inheritdoc/>
        public abstract List<IniSection> GetSections();

        /// <inheritdoc/>
        public abstract List<IniSection> GetSections(string name);

        /// <inheritdoc/>
        public abstract void AddSection(string name);

        /// <inheritdoc/>
        public abstract void InsertSection(int index, string name);

        /// <inheritdoc/>
        public abstract List<IGrouping<string, IniSection>> GetDuplicateSectionGroups();

        /// <inheritdoc/>
        public abstract void MergeDuplicateSections();

        #endregion
    }
}
