using NUnit.Framework;
using System;

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
        [Category("Extensions")]
        public void IsValidLogFileName_BadExtension_ReturnsFalse()
        {

            bool result = m_analyzer.IsValidLogFileName("badfileextension.foo");

            Assert.False(result);
        }

        [TestCase("goodfileextension.slf")]
        [TestCase("goodfileextension.SLF")]
        [Category("Extensions")]
        public void IsValidLogFileName_ValidExtensions_ReturnsTrue(string file)
        {

            bool result = m_analyzer.IsValidLogFileName(file);

            Assert.True(result);
        }

        [Test]
        public void IsValidLogFileName_EmptyFileName_ThrowsException()
        {

            var ex = Assert.Catch<Exception>(() => m_analyzer.IsValidLogFileName(""));

            StringAssert.Contains("filename has to be provided", ex.Message);
            Assert.That(ex.Message, Does.Contain("filename has to be provided"));
        }

        [Test]
        public void IsValidLogFileName_WhenCalled_ChangesWasLastFileNameValid()
        {
            m_analyzer.IsValidLogFileName("heresabadextension.bar");

            Assert.False(m_analyzer.WasLastFileNameValid);
        }
    }
}
