using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Yuu.Ini.Tests
{
    [TestClass]
    public class IniSectionTests
    {
        [TestMethod]
        public void SectionName()
        {
            IniSection section = new IniSection("");
            Assert.AreEqual(section.Name, "");
            Assert.IsFalse(section.IsNamedSection);

            section.Name = "section";
            Assert.AreEqual(section.Name, "section");
            Assert.IsTrue(section.IsNamedSection);
        }

        [TestMethod]
        public void ChildNodes()
        {
            IniSection section = new IniSection("");
            IniParameter parameter;
            IniComment comment;

            section.AddParameter("key1", "value1");
            parameter = section.GetParameters().Last();
            Assert.AreEqual(parameter.Value, "value1");

            parameter.Remove();
            Assert.IsFalse(section.ChildNodes.Contains(parameter));

            section.AddComment(";comment1");
            comment = section.GetComments().Last();
            Assert.AreEqual(comment.Value, ";comment1");

            section.Remove(comment);
            Assert.IsFalse(section.ChildNodes.Contains(comment));

            section.Add(new IniParameter("key2", "value2"));
            parameter = section.GetParameters("key2").Last();
            Assert.AreEqual(parameter.Value, "value2");

            section.RemoveAt(0);
            Assert.IsFalse(section.ChildNodes.Contains(parameter));

            section.AddRange(new List<IniNode> { new IniParameter("key3", "value3"), new IniComment(";comment2") });
            parameter = section.GetParameters().Last();
            Assert.AreEqual(parameter.Value, "value3");
            comment = section.GetComments().Last();
            Assert.AreEqual(comment.Value, ";comment2");

            section.Insert(0, new IniParameter("key4", "value4"));
            parameter = (IniParameter)section.ChildNodes[0];
            Assert.AreEqual(parameter.Value, "value4");

            section.InsertParameter(1, "key5", "value5");
            parameter = (IniParameter)section.ChildNodes[1];
            Assert.AreEqual(parameter.Value, "value5");

            section.InsertComment(2, ";comment3");
            comment = (IniComment)section.ChildNodes[2];
            Assert.AreEqual(comment.Value, ";comment3");

            section.Clear();
            Assert.IsFalse(section.HasChildNodes);
        }

        [TestMethod]
        public void ToIniString()
        {
            var section = new IniSection("");
            string sectionString;

            Assert.IsNull(section.ToString());

            var parameter = new IniParameter("key", "value");
            var childNodesString = parameter.ToString();
            section.Add(parameter);

            sectionString = childNodesString;
            Assert.AreEqual(section.ToString(), sectionString);

            section.Name = "section";
            sectionString = $@"[{section.Name}]" + "\n" + childNodesString;
            Assert.AreEqual(section.ToString(), sectionString);
        }
    }
}
