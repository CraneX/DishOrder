using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dishes.Tests
{
    [TestFixture]
    [Category("StringHelperTest")]
    public class StringHelperTest
    {
        public StringHelperTest()
        {
        }

        [TestFixtureSetUp]
        public void SetUpFixture()
        {
        }


        [TestCase("", "")]
        [TestCase(null, null)]
        [TestCase("xyz123 ", "xyz123")]
        [TestCase(" xyz 123 ", "xyz 123")]
        [TestCase(" xyz 123 ", "xyz 123")]
        [TestCase("  false", "false")]
        public void TestTrim(string text, string expectValue)
        {
            Assert.AreEqual(StringHelper.Trim(text), expectValue);
        }
    }
}
