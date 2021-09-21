using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Yuu.Ini.Tests
{
    [TestClass]
    public class IniCommentTests
    {
        [TestMethod]
        public void ToIniString()
        {
            IniComment comment;
            string commentString;

            comment = new IniComment("; Unnamed Section");
            commentString = "; Unnamed Section";
            Assert.AreEqual(comment.ToString(), commentString);
        }
    }
}
