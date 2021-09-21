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

        [TestCase("goodfileextension.slf")]
        [TestCase("goodfileextension.SLF")]
        public void IsValidLogFileName_ValidExtensions_ReturnsTrue(string file)
        {
            LogAnalyzer analyzer = new();

            bool result = analyzer.IsValidLogFileName(file);

            Assert.True(result);
        }
    }
}
