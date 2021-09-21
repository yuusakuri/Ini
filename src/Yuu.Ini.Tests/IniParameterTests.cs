using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Yuu.Ini.Tests
{
    [TestClass]
    public class IniParameterTests
    {
        [TestMethod]
        public void ToIniString()
        {
            var parameter = new IniParameter("key", "value");
            string parameterString;

            parameterString = "key = value";
            Assert.AreEqual(parameter.ToString(), parameterString);
        }
    }
}
