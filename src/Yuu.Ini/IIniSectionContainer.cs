using System.Collections.Generic;
using System.Linq;

namespace Yuu.Ini
{
    /// <summary>
    /// Represents a INI section container node.
    /// </summary>
    public interface IIniSectionContainer : IIniNode
    {
        /// <summary>
        /// Gets the all section nodes from the child nodes.
        /// </summary>
        List<IniSection> GetSections();

        /// <summary>
        /// Gets the section nodes with the given name from the child nodes.
        /// </summary>
        List<IniSection> GetSections(string name);

        /// <summary>
        /// Adds the section node with the given name to the end of the child nodes.
        /// </summary>
        /// <param name="name">
        /// The section name to add.
        /// </param>
        void AddSection(string name);

        /// <summary>
        /// Inserts the section node with the given name into the child nodes at the given index.
        /// </summary>
        /// <param name="index">
        /// The index of the section node to insert.
        /// </param>
        /// <param name="name">
        /// The section name to insert.
        /// </param>
        void InsertSection(int index, string name);

        /// <summary>
        /// Gets the groups of sections with duplicate names.
        /// </summary>
        List<IGrouping<string, IniSection>> GetDuplicateSectionGroups();

        /// <summary>
        /// Consolidate duplicate sections with names.
        /// Group sections with the same name.
        /// The child nodes of other sections are added to the section with the smallest index in the group.
        /// </summary>
        void MergeDuplicateSections();
    }
}
