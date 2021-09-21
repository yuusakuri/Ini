using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Yuu.Ini.Tests
{
    [TestClass]
    public class IniDocumentTests
    {
        [TestMethod]
        public void ToIniString()
        {
            var ini = IniParserTests.ParsedSampleIni;

            var iniString = ini.ToString();
            Assert.AreEqual(iniString, IniParserTests.SampleFormatedIniFileContents);
        }

        [TestMethod]
        public void DuplicateSectionGroups()
        {
            var ini = IniParserTests.ParsedSampleIni;

            Assert.AreEqual(ini.GetDuplicateSectionGroups().Count(), 1);

            ini.MergeDuplicateSections();
            Assert.AreEqual(ini.GetDuplicateSectionGroups().Count(), 0);
            Assert.AreEqual(ini.GetSections("duplicate")[0].GetParameters().Count(), 4);
        }

        [TestMethod]
        public void ChildNodes()
        {
            var ini = IniParserTests.ParsedSampleIni;

            Assert.AreEqual(ini.GetSections("section").Count(), 0);
            ini.AddSection("section");
            Assert.AreEqual(ini.GetSections("section").Count(), 1);

            Assert.AreEqual(ini.GetParameters()[0].Value, "value1");
            Assert.AreEqual(ini.GetComments()[0].Value, "; Unnamed Section");
        }

        public void ParentNodes()
        {
            var ini = IniParserTests.ParsedSampleIni;

            Assert.IsNull(ini.ParentNode);

            var childNodes = new List<IniNode>();
            childNodes
                .Concat(ini.GetSections())
                .Concat(ini.GetParameters())
                .Concat(ini.GetComments())
                .ToList()
                .ForEach(aNode => Assert.AreEqual(aNode.ParentNode, ini));
        }
    }
}
