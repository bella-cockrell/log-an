using NUnit.Framework;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        private LogAnalyzer m_analyzer = null;

        [SetUp]
        public void Setup()
        {
            m_analyzer = new LogAnalyzer();

        }

        [Test]
        public void IsValidLogFileName_BadExtension_ReturnsFalse()
        {

            bool result = m_analyzer.IsValidLogFileName("badfileextension.foo");

            Assert.False(result);
        }

        [TestCase("goodfileextension.slf")]
        [TestCase("goodfileextension.SLF")]
        public void IsValidLogFileName_ValidExtensions_ReturnsTrue(string file)
        {

            bool result = m_analyzer.IsValidLogFileName(file);

            Assert.True(result);
        }
    }
}
