using Microsoft.VisualStudio.TestTools.UnitTesting;
using VA = VisioAutomation;

namespace TestVisioAutomation.Text
{
    [TestClass]
    public class TextUtil_Tests : VisioAutomationTest
    {
        public bool Match(string pat, string text)
        {
            var regex = VA.TextUtil.GetRegexForWildcardPattern(pat,true);
            return regex.IsMatch(text);
        }

        [TestMethod]
        public void Text_Case1()
        {
            Assert.IsTrue(this.Match("*","") );
            Assert.IsTrue(this.Match("*", "AbC"));
            Assert.IsTrue(this.Match("A*", "Abc"));
            Assert.IsTrue(this.Match("*C", "Abc"));
            Assert.IsFalse(this.Match("A*", "bcA"));
            Assert.IsFalse(this.Match("*C", "bcA"));
            Assert.IsTrue(this.Match("A*C", "AbC"));
            Assert.IsFalse(this.Match("A*C", "AbA"));
            Assert.IsTrue(this.Match("A*B*C", "A---b---C"));
            Assert.IsFalse(this.Match("A*B*C", "A---b---A"));
            Assert.IsTrue(this.Match("A*B?C", "A---bXC"));
        }
    }
}