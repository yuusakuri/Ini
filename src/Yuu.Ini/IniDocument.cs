using System;
using System.Linq;
using System.Collections.Generic;

namespace Yuu.Ini
{
    /// <summary>
    /// Represents a INI document node.
    /// </summary>
    public class IniDocument : IniNode, IIniDocument
    {
        #region ctor

        /// <inheritdoc/>
        public IniDocument(IniParserConfiguration configuration) : base(IniNodeType.IniDocument, new List<IniNodeType> { IniNodeType.IniSection }, configuration)
        {
            this.AddSection("");
        }

        /// <inheritdoc/>
        public IniDocument() : this(new IniParserConfiguration()) { }

        #endregion

        /// <inheritdoc/>
        public List<IniSection> GetSections()
        {
            var nodes = this.ChildNodes
                .Select(aSection => (IniSection)aSection)
                .ToList();

            return nodes;
        }

        /// <inheritdoc/>
        public List<IniSection> GetSections(string name)
        {
            var nodes = this.GetSections()
                .Where(aSection => aSection.Name == name)
                .ToList();

            return nodes;
        }

        /// <inheritdoc/>
        public List<IniParameter> GetParameters()
        {
            var nodes = new List<IniParameter>();
            this.GetSections()
                .ForEach(aSection => nodes.AddRange(aSection.GetParameters()));

            return nodes;
        }

        /// <inheritdoc/>
        public List<IniParameter> GetParameters(string key)
        {
            var nodes = new List<IniParameter>();
            this.GetSections()
                .ForEach(aSection => nodes.AddRange(aSection.GetParameters(key)));

            return nodes;
        }

        /// <inheritdoc/>
        public List<IniComment> GetComments()
        {
            var nodes = new List<IniComment>();
            this.GetSections()
                .ForEach(aSection => nodes.AddRange(aSection.GetComments()));

            return nodes;
        }

        /// <inheritdoc/>
        public void AddSection(string name)
        {
            var node = new IniSection(name, this.Configuration);

            this.Add(node);
        }

        /// <inheritdoc/>
        public void InsertSection(int index, string name)
        {
            var node = new IniSection(name, this.Configuration);

            this.Insert(index, node);
        }

        /// <inheritdoc/>
        public List<IGrouping<string, IniSection>> GetDuplicateSectionGroups()
        {
            var nodeGroups = this.GetSections()
                .GroupBy(aSection => aSection.Name)
                .Where(aGroup => aGroup.Count() > 1)
                .ToList();

            return nodeGroups;
        }

        /// <inheritdoc/>
        public void MergeDuplicateSections()
        {
            var duplicateSectionGroups = this.GetDuplicateSectionGroups();
            foreach (var aGroup in duplicateSectionGroups)
            {
                int indexOfMergeDestination = 0;
                var sectionOfMergeDestination = aGroup.ElementAt(indexOfMergeDestination);

                for (int i = 0; i < aGroup.Count(); i++)
                {
                    if (i == indexOfMergeDestination)
                    {
                        continue;
                    }

                    var aSection = aGroup.ElementAt(i);

                    if (aSection.ParentNode == null) throw new ArgumentNullException(nameof(aSection.ParentNode));

                    sectionOfMergeDestination.AddRange(aSection.ChildNodes);
                    aSection.ParentNode.Remove(aSection);
                }
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var contents = new List<string>();

            contents.AddRange(
                this.GetSections()
                    .OrderBy(aSection => aSection.IsNamedSection ? 1 : 0)
                    .Select(aSection => aSection.ToString())
                    .Where(aSectionString => aSectionString != null)
                    .Cast<string>()
            );

            if (this.Configuration.NewLineAtEndOfFile)
            {
                contents.Add("");
            }

            return String.Join(this.Configuration.NewLine, contents);
        }
    }
}
