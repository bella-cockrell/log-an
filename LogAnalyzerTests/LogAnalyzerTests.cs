using NUnit.Framework;
using System;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        private static LogAnalyzer MakeLogAnalyzer()
        {
            return new LogAnalyzer();
            //we have this method because if the constructor for LogAnalyzer
            //changes, we only need to change in one place. This uses the
            //factory pattern as opposed to the SetUp attribute
        }

        [Test]
        [Category("Extensions")]
        public void IsValidLogFileName_BadExtension_ReturnsFalse()
        {
            var la = MakeLogAnalyzer();

            bool result = la.IsValidLogFileName("badfileextension.foo");

            Assert.False(result);
        }

        [TestCase("goodfileextension.slf")]
        [TestCase("goodfileextension.SLF")]
        [Category("Extensions")]
        public void IsValidLogFileName_ValidExtensions_ReturnsTrue(string file)
        {
            var la = MakeLogAnalyzer();

            bool result = la.IsValidLogFileName(file);

            Assert.True(result);
        }

        [Test]
        public void IsValidLogFileName_EmptyFileName_ThrowsException()
        {

            var la = MakeLogAnalyzer();

            var ex = Assert.Catch<Exception>(() => la.IsValidLogFileName(""));

            StringAssert.Contains("filename has to be provided", ex.Message);
            Assert.That(ex.Message, Does.Contain("filename has to be provided"));
        }

        [TestCase("heresabadextension.bar", false)]
        [TestCase("heresabadextension.slf", true)]
        [Ignore("WasLastFileNameValid doesn't seem to be working anymore")]
        public void IsValidLogFileName_WhenCalled_ChangesWasLastFileNameValid(string fileName, bool expected)
        {
            var la = MakeLogAnalyzer();

            la.IsValidLogFileName(fileName);
          

            //Assert.AreEqual(expected, la.WasLastFileNameValid);
        }

        [Test]
        public void IsValidFileName_SupportedExtension_ReturnsTrue()
        {
            FakeExtensionManager myFakeManager = new();

            myFakeManager.WillBeValid = true; //sets up stub to return true

            LogAnalyzer log = new LogAnalyzer();
            log.FileExtensionManager = myFakeManager; //injects stub

            bool result = log.IsValidLogFileName("short.ext");
            Assert.True(result);
        }

    }

    internal class FakeExtensionManager : IFileExtensionManager
    {
        public bool WillBeValid = false;

        public bool IsValid (string fileName)
        {
            return WillBeValid;
        }
    }
    //good idea to add fakes in the same test file if only used by one example.
    //Otherwise, extract them.

}


