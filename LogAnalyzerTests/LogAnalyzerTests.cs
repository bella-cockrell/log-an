using NUnit.Framework;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class LogAnalyzerTests
    {

        [Test]
        public void IsValidLogFileName_BadExtension_ReturnsFalse()
        {
            LogAnalyzer analyzer = new();

            bool result = analyzer.IsValidLogFileName("badfileextension.foo");

            Assert.False(result);
        }

        [Test]
        public void IsValidLogFileName_GoodExtensionLowerCase_ReturnsTrue()
        {
            LogAnalyzer analyzer = new();

            bool result = analyzer.IsValidLogFileName("goodfileextension.slf");

            Assert.True(result);
        }

        [Test]
        public void IsValidLogFileName_GoodExtensionUpperCase_ReturnsTrue()
        {
            LogAnalyzer analyzer = new();

            bool result = analyzer.IsValidLogFileName("goodfileextension.SLF");

            Assert.True(result);
        }
    }
}
