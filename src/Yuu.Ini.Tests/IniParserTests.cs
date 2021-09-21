using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Yuu.Ini.Tests
{
    [TestClass]
    public class IniParserTests
    {
        public static string SampleIniFilePath { get => "sample.ini"; }
        public static string SampleIniFileContents { get => File.ReadAllText(IniParserTests.SampleIniFilePath); }
        public static IniDocument ParsedSampleIni { get => IniParser.Parse(IniParserTests.SampleIniFileContents); }
        public static string SampleFormatedIniFilePath { get => "sample_formated.ini"; }
        public static string SampleFormatedIniFileContents { get => File.ReadAllText(IniParserTests.SampleFormatedIniFilePath); }

        [TestMethod]
        [DataRow("[usual]", "usual")]
        [DataRow("[with space]", "with space")]
        [DataRow("[\"surrounded_by_double_quotes\"]", "\"surrounded_by_double_quotes\"")]
        [DataRow("[with_special_character!@#$%^&*()_-+=|\\~`{}:;\"'<,>.?/]", "with_special_character!@#$%^&*()_-+=|\\~`{}:;\"'<,>.?/")]
        public void ParseSectionLine(string line, string section)
        {
            line = line + "\n";
            var ini = IniParser.Parse(line);

            Assert.AreEqual(ini.GetSections(section)[0].Name, section);
        }

        [TestMethod]
        [DataRow("usual_key1 = value1", "usual_key1", "value1")]
        [DataRow("usual_key2 = value2", "usual_key2", "value2")]
        [DataRow("usual_key3   =   value3", "usual_key3", "value3")]
        [DataRow("key with space = value with space", "key with space", "value with space")]
        [DataRow("\"key_surrounded_by_double_quotes\" = \"value_surrounded_by_double_quotes\"", "\"key_surrounded_by_double_quotes\"", "\"value_surrounded_by_double_quotes\"")]
        [DataRow("!@#$%^&*()_-+|\\~`{[]}:\"'<,>.?/ = !@#$%^&*()_-+=|\\~`{[]}:;\"'<,>.?/", "!@#$%^&*()_-+|\\~`{[]}:\"'<,>.?/", "!@#$%^&*()_-+=|\\~`{[]}:;\"'<,>.?/")]
        [DataRow("key_without_value =", "key_without_value", "")]
        public void ParseParameterLine(string line, string key, string value)
        {
            line = line + "\n";
            var ini = IniParser.Parse(line);

            Assert.AreEqual(ini.GetParameters(key)[0].Key, key);
            Assert.AreEqual(ini.GetParameters(key)[0].Value, value);
        }

        [TestMethod]
        [DataRow("", "")]
        [DataRow(";comment", ";comment")]
        [DataRow(";comment_with_special_character!@#$%^&*()_-+=|\\~`{[]}:;\"'<,>.?/", ";comment_with_special_character!@#$%^&*()_-+=|\\~`{[]}:;\"'<,>.?/")]
        public void ParseCommentLine(string line, string comment)
        {
            line = line + "\n";
            var ini = IniParser.Parse(line);

            Assert.AreEqual(ini.GetComments()[0].Value, comment);
        }

        [TestMethod]
        public void ParseSampleIniFile()
        {
            var ini = IniParserTests.ParsedSampleIni;

            Assert.AreEqual(ini.GetSections("usual")[0].GetParameters("usual_key2")[0].Value, "value2");
            Assert.AreEqual(ini.GetComments()[0].Value, "; Unnamed Section");
        }
    }
}
